

(function ($) {
    var me;
    var uploader = null;
    var uploader_ux_Win = null;
   
    var $wrap = $('#uploader'),
        $queue = $('<ul class="filelist"></ul>').appendTo($wrap.find('.queueList')), //图片容器
        $statusBar = $wrap.find('.statusBar'),     //状态栏[包括进度和控制按钮]
        $info = $statusBar.find('.info'),          //文件总体选择信息
        $upload = $wrap.find('.uploadBtn'),        //上传按钮
        $placeHolder = $wrap.find('.placeholder'), //没选择文件之前的内容
        $progress = $statusBar.find('.progress').hide();

    var WebUpLoaderClass = function () {
        me = this;
        
        //#region uploader
        //#region [全局设置]
        //当前正在上传的文件信息
        var _uFileQueued = null;
        WebUploader.Uploader.register({
            "before-send-file": "beforeSendFile",
            "before-send": "beforeSend",
            "after-send-file": "afterSendFile"
        }, {
            beforeSendFile: function (file) {
                _uFileQueued = me.GetFileQueued(file.id);
            },
            beforeSend: function (block) {
                var deferred = $.Deferred();
                if (_uFileQueued.file.isUpload)
                    deferred.reject();
                else {
                    if (_uFileQueued.file.chunks && _uFileQueued.file.chunks.length > 0) {
                        var _x = null;
                        var chunkSize = block.end - block.start;
                        for (var i = 0; i < _uFileQueued.file.chunks.length; i++) {
                            var o = _uFileQueued.file.chunks[i];
                            if (block.chunk == o.name) {
                                _x = o;
                                break;
                            }
                        }
                        if (_x && _x.size == chunkSize) {
                            deferred.reject();
                        } else {
                            deferred.resolve();
                        }
                    }else
                        deferred.resolve();
                }
                return deferred.promise();
            },
            afterSendFile: function (file) {
               
            }
        });
        //#endregion
        uploader = WebUploader.create({
            swf: "/Content/TComponent/webuploader/Uploader.swf",

            pick: {
                id: '#filePicker', //支持 class, 或者 dom 节点[不指定则不创建按钮]
                innerHTML: '点击选择文件',
                multiple: true     //是否启用多文件选取
            },
            auto: false,
            fileVal: 'HttpFile',
            method: 'POST',
            server: '/AreasCode019/FileUpload/UploadAsync',
            compress: false,

            disableGlobalDnd: true,
            dnd: '#dndArea',
            paste: '#uploader',
            
            chunked: true,
            chunkSize: 3 * 1024 * 1024,
            chunkRetry: 2,
            threads: 1,

            fileNumLimit: 100,
            fileSingleSizeLimit: 100 * 1024 * 1024, //100M

            prepareNextFile: false,
            duplicate: false

        });
        uploader.addButton({
            id: '#filePicker2',
            innerHTML: '继续添加'
        });

        //#region 选取文件
        uploader.on('fileQueued', function (file) {

            me.fileCount++;
            me.fileSize += file.size;
            if (me.fileCount === 1) {
                $placeHolder.addClass('element-invisible');
                $statusBar.show();
            }
            me.AddFile(file);
            //准备上传文件
            me.setState('ready');
            //文件验证进度
            me.updateTotalProgress();
            //计算文件MD5
            uploader.md5File(file)
                //显示计算进度
                .progress(function (percentage) {
                    var fileObj = $('#' + file.id);
                    var spanObj = fileObj.find('.progress_check>span').text(parseInt(percentage * 100));
                    
                })
                // 完成
                .then(function (md5) {
                    var fileObj = $('#' + file.id);
                    $.ajax({
                        type: "POST",
                        url: "/AreasCode019/FileUpload/UploadAsync",
                        async: false,
                        data: {
                            md5: md5,
                            md5name: md5 + "." + file.ext,
                            size: file.size,
                            OperationState: 'FileInfo'
                        },
                        dataType: "json",
                        success: function (data) {
                            if (data.success) {
                                me.FileQueueds.push({
                                    id: file.id,
                                    md5: md5,
                                    name: file.name,
                                    md5name: md5 + "." + file.ext,
                                    size: file.size,
                                    isUpload: data.Pamrms.isUpload,
                                    chunks: data.Pamrms.chunks
                                });
                                fileObj.find('.progress_check').attr('data-checkedcomplete', true).text('验证完成，等待上传').css('color', '#aaa');
                            }
                        },
                        error: function (data) { }
                    });
                });

        });
        //#endregion
        //#region 删除文件
        uploader.on('fileDequeued', function (file) {

            me.fileCount--;
            me.fileSize -= file.size;

            if (!me.fileCount) {
                me.setState('pedding');
            }

            me.RemoveFile(file);
            me.updateTotalProgress();

        });
        //#endregion
        //#region 开始上传|暂停上传
        $upload.on('click', function () {
            
            if ($(this).hasClass('disabled')) {
                return false;
            }
            if ($queue.find('.progress_check[data-checkedcomplete=false]').length > 0) {
                $.messager.alert('友情提示', "请等待文件验证完成!", 'warning');
                return false;
            }
            else {
                $queue.find('.progress_check').hide();
            }

            if (me.state === 'ready') {
                uploader.upload();
            } else if (me.state === 'paused') {
                uploader.upload();
            } else if (me.state === 'uploading') {
                uploader.stop();
            }

        });
        //#endregion
        //#region 文件上传前预设
        uploader.on("uploadBeforeSend", function (object, data, headers) {
            data.md5 = _uFileQueued.file.md5;
            data.chunk = object.chunk;
            data.chunks = object.chunks;
            data.chunkSize = object.end - object.start;
            data.md5name = _uFileQueued.file.md5name;
            data.name = _uFileQueued.file.name;
            data.size = _uFileQueued.file.size;
        });
        //#endregion
        //#region 当前文件[上传成功后调用]合并分块
        uploader.on('uploadSuccess', function (file, response) {
            var _yFileQueued = me.GetFileQueued(file.id);
            $.ajax({
                type: "POST",
                url: "/AreasCode019/FileUpload/UploadAsync",
                async: false,
                data: {
                    fk: me.fk,
                    md5: _yFileQueued.file.md5,
                    name: file.name,
                    md5name: _yFileQueued.file.md5name,
                    size: file.size,
                    OperationState: 'FileMerge'
                },
                dataType: "json",
                success: function (data) {
                    if (data.success) {
                        me.FileQueueds[_yFileQueued.index]["isUpload"] = true;
                        me.FileQueueds[_yFileQueued.index]["chunks"] = [];
                        $('.pop-window0 .pop-close').click();

                        var row = {
                            pk: data.Pamrms.pk00801,
                            pk00803: file.name,
                            pk00805: data.Pamrms.pk00805,
                            pj00402: data.Pamrms.pk00807
                        };

                        window.opener.sdpk007_ux_WinClass.Add(row);
                        
                    } else {
                        $.messager.alert('友情提示', data.Message, 'error');
                    }
                },
                error: function (data) { }
            });
        });
        //#endregion
        //#region 当前文件上传进度
        uploader.on("uploadProgress", function (file, percentage) {
            var $li = $('#' + file.id),
                $percent = $li.find('.progress span');

            $percent.css('width', percentage * 100 + '%');
            me.percentages[file.id][1] = percentage;
            me.updateTotalProgress();
        });

        //#endregion
        //#region 当前文件总监听器
        uploader.on('all', function (type, arg1, arg2) {
            var stats;
            switch (type) {
                case 'uploadFinished':
                    me.setState('confirm');
                    break;

                case 'startUpload':
                    me.setState('uploading');
                    break;

                case 'stopUpload':
                    me.setState('paused');
                    break;
            }
        });
        //#endregion

        $info.on('click', '.retry', function () {
            uploader.retry();
        });

        $info.on('click', '.ignore', function () {
        });
        //#endregion
        $upload.addClass('state-' + me.state);
        me.updateTotalProgress();
    }

    WebUpLoaderClass.prototype = {
       
        fk: undefined,    //关联模块ID
        fileCount: 0,     //添加文件总数量
        fileSize: 0,      //添加的文件总大小
        state: 'pedding', //当前文件状态: pedding(初始化), ready(准备上传), uploading(上传中), confirm(上传完成), paused(暂停中),done

        //[当前文件]计算验证MD5进度信息 { file.id: [file.size, file.percentage] }
        percentages: {},
        //上传文件队列
        FileQueueds: [],
        GetFileQueued : function (id) {
            for (var i = 0; i < me.FileQueueds.length; i++) {
                if(me.FileQueueds[i].id == id)
                    return { index: i, file: me.FileQueueds[i] };
            }
        },
        SetPk: function (fk) {
            me.fk = fk;
        },

        //#region 添加文件
        AddFile: function (file) {
            var $li = $('<li id="' + file.id + '">' +
                    '<p class="title">' + file.name + '</p>' +
                    '<p class="imgWrap"></p>' +
                    '<p class="progress"><span></span></p>' +
                    '<p class="progress_check" data-checkedcomplete="false">正在验证文件：<span>0</span>%</p>' +
                    '</li>'),

                $btns = $('<div class="file-panel">' +
                    '<span class="cancel">删除</span>' +
                    '<span class="rotateRight">向右旋转</span>' +
                    '<span class="rotateLeft">向左旋转</span></div>').appendTo($li),
                $prgress = $li.find('p.progress span'),
                $wrap = $li.find('p.imgWrap'),
                $info = $('<p class="error"></p>'),

                showError = function (code) {
                    switch (code) {
                        case 'exceed_size':
                            text = '文件大小超出';
                            break;

                        case 'interrupt':
                            text = '上传暂停';
                            break;

                        default:
                            text = '上传失败，请重试';
                            break;
                    }

                    $info.text(text).appendTo($li);
                };

            if (file.getStatus() === 'invalid') {
                showError(file.statusText);
            } else {
                //#region 文件预览
                $wrap.text('预览中');
                var ratio = window.devicePixelRatio || 1,
                //缩略图大小
                thumbnailWidth = 110 * ratio,
                thumbnailHeight = 110 * ratio;

                uploader.makeThumb(file, function (error, src) {
                    var img;
                    if (error) {
                        $wrap.text('不能预览');
                        var png = "file-text-icon.png";
                        switch (file.ext.toLowerCase())
                        {
                            case "doc":
                            case "docx":
                                png = "doc_files.png";
                                break;
                            case "txt":
                                png = "txt_files.png";
                                break;
                            case "zip":
                                png = "zip_files.png";
                                break;
                            case "rar":
                                png = "rar_files.png";
                                break;
                            case "xls":
                            case "xlsx":
                                png = "excel.png";
                                break;
                            case "rar":
                                png = "rar_files.png";
                                break;
                        }
                        var image = "<img src='/Content/Areas/AreasCode019/FileUpload/image/" + png + "'>";
                        $wrap.empty().append($(image));
                        return;
                    }
                    img = $('<img src="' + src + '">');
                    $wrap.empty().append(img);

                }, thumbnailWidth, thumbnailHeight);

                me.percentages[file.id] = [file.size, 0];
                file.rotation = 0;
                //#endregion
            }
            file.on('statuschange', function (cur, prev) {
                if (prev === 'progress') {
                    $prgress.hide().width(0);
                } else if (prev === 'queued') {
                    $li.off('mouseenter mouseleave');
                    $btns.remove();
                }

                // 成功
                if (cur === 'error' || cur === 'invalid') {
                    showError(file.statusText);
                    me.percentages[file.id][1] = 1;
                } else if (cur === 'interrupt') {
                    showError('interrupt');
                } else if (cur === 'queued') {
                    $info.remove();
                    $prgress.css('display', 'block');
                    me.percentages[file.id][1] = 0;
                } else if (cur === 'progress') {
                    $info.remove();
                    $prgress.css('display', 'block');
                } else if (cur === 'complete') {
                    $prgress.hide().width(0);
                    $li.append('<span class="success"></span>');
                }
                $li.removeClass('state-' + prev).addClass('state-' + cur);
            });
            $li.on('mouseenter', function () {
                $btns.stop().animate({ height: 30 });
            });
            $li.on('mouseleave', function () {
                $btns.stop().animate({ height: 0 });
            });
            
            //#region 文件旋转按钮|删除按钮
            $btns.on('click', 'span', function () {
                
                var index = $(this).index(),
                    deg;
                switch (index) {
                    case 0:
                        uploader.removeFile(file);
                        return;
                    case 1:
                        file.rotation += 90;
                        break;
                    case 2:
                        file.rotation -= 90;
                        break;
                }

                //旋转CSS
                deg = 'rotate(' + file.rotation + 'deg)';
                $wrap.css({
                    '-webkit-transform': deg,
                    '-mos-transform': deg,
                    '-o-transform': deg,
                    'transform': deg
                });

            });
            //#endregion

            $li.appendTo($queue);
        },
        //#endregion
        //#region 删除文件
        RemoveFile: function (file)
        {
            var $li = $('#' + file.id);
            delete me.percentages[file.id];
            me.updateTotalProgress();
            $li.off().find('.file-panel').off().end().remove();

            if (me.FileQueueds && me.FileQueueds.length > 0)
            {
                me.FileQueueds.splice(me.GetFileQueued(file.id).index, 1);
            }
        },
        //#endregion
        //#region 设置文件状态
        setState: function (val) {
            var file, stats;
            if (val === me.state) {
                return;
            }

            $upload.removeClass('state-' + me.state);
            $upload.addClass('state-' + val);
            me.state = val;

            switch (me.state) {
                case 'pedding':
                    $placeHolder.removeClass('element-invisible');
                    $queue.hide();
                    $statusBar.addClass('element-invisible');
                    uploader.refresh();
                    break;

                case 'ready':
                    $placeHolder.addClass('element-invisible');
                    $('#filePicker2').removeClass('element-invisible');
                    $queue.show();
                    $statusBar.removeClass('element-invisible');
                    uploader.refresh();
                    break;

                case 'uploading':
                    $('#filePicker2').addClass('element-invisible');
                    $progress.show();
                    $upload.text('暂停上传');
                    break;

                case 'paused':
                    $.each(uploader.getFiles(), function (idx, row) {
                        if (row.getStatus() == "progress") {
                            row.setStatus('interrupt');
                        }
                    })
                    $progress.show();
                    $upload.text('继续上传');
                    break;

                case 'confirm':
                    $progress.hide();
                    $('#filePicker2').removeClass('element-invisible');
                    $upload.text('开始上传');

                    stats = uploader.getStats();
                    if (stats.successNum && !stats.uploadFailNum) {
                        me.setState('finish');
                        return;
                    }
                    break;
                case 'finish':
                    stats = uploader.getStats();
                    if (stats.successNum) {
                    } else {
                        // 没有成功的图片，重设
                        me.state = 'done';
                        location.reload();
                    }
                    break;
            }

            me.updateStatus();
        },
        updateStatus: function () {
            var text = '', stats;
            if (me.state === 'ready') {
                text = '选中' + me.fileCount + '个文件，共' +
                        WebUploader.formatSize(me.fileSize) + '。';
            } else if (me.state === 'confirm') {
                stats = uploader.getStats();
                if (stats.uploadFailNum) {
                    text = '已成功上传' + stats.successNum + '个文件，' +
                        stats.uploadFailNum + '个文件上传失败，<a class="retry" href="#">重新上传</a>失败文件或<a class="ignore" href="#">忽略</a>'
                }

            } else {
                stats = uploader.getStats();
                text = '共' + me.fileCount + '个（' +
                        WebUploader.formatSize(me.fileSize) +
                        '），已上传' + stats.successNum + '个';

                if (stats.uploadFailNum) {
                    text += '，失败' + stats.uploadFailNum + '个';
                }
            }

            $info.html(text);
        },
        //#endregion
        //#region 更新进度条
        updateTotalProgress: function () {
            var loaded = 0,
                total = 0,
                spans = $progress.children(),
                percent;

            $.each(me.percentages, function (k, v) {
                total += v[0];
                loaded += v[0] * v[1];
            });
            percent = total ? loaded / total : 0;
            spans.eq(0).text(Math.round(percent * 100) + '%');
            spans.eq(1).css('width', Math.round(percent * 100) + '%');
            me.updateStatus();
        }
        //#endregion

    }

    window.WebUpLoader = null;
    $(document).ready(function (e) {
        window.WebUpLoader = new WebUpLoaderClass();
        
    });

})(jQuery);
