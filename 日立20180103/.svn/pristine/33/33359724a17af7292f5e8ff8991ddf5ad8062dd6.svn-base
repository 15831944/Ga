/**
 * 给时间框控件扩展一个清除的按钮
 */
$.fn.datebox.defaults.cleanText = '清空';

(function ($) {
    var buttons = $.extend([], $.fn.datebox.defaults.buttons);
    buttons.splice(1, 0, {
        text: function (target) {
            return $(target).datebox("options").cleanText
        },
        handler: function (target) {
            $(target).datebox("setValue", "");
            $(target).datebox("hidePanel");
        }
    });
    $.extend($.fn.datebox.defaults, {
        buttons: buttons
    });
    $.fn.serializeJson = function () {
        var serializeObj = {};
        $(this.serializeArray()).each(function () {
            serializeObj[this.name] = this.value;
        });
        return serializeObj;
    };  
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    };
})(jQuery);

$(function () {
    window.rlform1101 = {
        isNull: function (obj) {
            return obj === null || obj === undefined;
        },
        isNullOrWhitespace: function (text) {
            return rlform1101.isNull(text) || text.replace(/(^s*)|(s*$)/g, "").length === 0;
        },
        isFunc: function (func) {
            return typeof (func) == 'function';
        },
        isTrue: function (flag) {
            return flag === true;
        },
        messenger: {
            _showAlert: function (message, title, type) {
                title = rlform1101.isNullOrWhitespace(title) ? '消息' : title;
                $.messager.alert(title, message, type);
            },
            showMessage: function (message, title) {
                title = rlform1101.isNullOrWhitespace(title) ? '提示信息' : title;
                this._showAlert(message, title, 'info');
            },
            showError: function (message) {
                this._showAlert(message, '错误信息', 'error');
            },
            confirm: function (message, action) {
                message = rlform1101.isNullOrWhitespace(message) ? '是否删除？' : message;
                $.messager.confirm('确认消息', message, function (r) {
                    if (r) {
                        if (rlform1101.isFunc(action)) {
                            action();
                        }
                    }
                });
            }
        },
        openWindow: function (url) {
            window.open(url);
        },
        getControlSelector: function (cId, htmltype, type) {
            return htmltype + '.easyui-' + type + "[id=" + cId + "]";
        },
        disableControl: function (cId, isDisabled) {
            var ctrls = ['datebox', 'datetimebox', 'textbox', 'numberspinner', 'combobox'];
            var cId = "[id=" + cId + "]";
            for (var i = 0; i < ctrls.length; i++) {
                var selectors = [
                    getControlSelector(cId, 'input', ctrls[i]),
                    getControlSelector(cId, 'a', 'linkbutton'),
                    getControlSelector(cId, 'select', 'combobox')
                ];
                for (var k = 0; k < selectors.length; k++) {
                    if ($(selectors[i]).length > 0) {
                        $(selectors[i]).linkbutton('disable');
                        $(selectors[i]).combobox('disable');
                        break;
                    }
                }
            }
        },
        disableForm: function (formId, isDisabled) {
            var attr = "disable";
            if (!isDisabled) {
                attr = "enable";
            }

            var jCtrls = [$("form[id='" + formId + "'] :text"),
            $("form[id='" + formId + "'] textarea"),
            $("form[id='" + formId + "'] select"),
            $("form[id='" + formId + "'] :radio"),
            $("form[id='" + formId + "'] :checkbox")];
            for (var i = 0; i < jCtrls.length; i++) {
                if (isDisabled) {
                    jCtrls[i].attr("disabled", isDisabled);
                }
                else {
                    jCtrls[i].removeAttr('disabled');
                }
            }

            $("#" + formId + " select.easyui-combobox").each(function () {
                if (this.id) {
                    $("#" + this.id).combobox(attr);
                }
            });

            $("#" + formId + " input.easyui-datebox").each(function () {
                if (this.id) {
                    $("#" + this.id).datebox(attr);
                }
            });

            $("#" + formId + " input.easyui-numberbox").each(function () {
                if (this.id) {
                    $("#" + this.id).numberbox(attr);
                }
            });
        },
        isDisabledCtrl: function (selector) {
            var jCtrls = $(selector);
            if (jCtrls.length == 0) {
                return false;
            }
            return $(jCtrls[0]).attr('disabled') === 'disabled';
        },
        submitForm: function (formId, submitUrl, verifyAction, successAction, errorAction) {
            var action = (function (aFormId, aSubmitUrl, aVerifyAction, aSuccessAction, aErrorAction) {
                return function () {
                    $('#' + aFormId).form('submit', {
                        url: aSubmitUrl,
                        onSubmit: function () {
                            var flag;
                            if (rlform1101.isFunc(aVerifyAction)) {
                                flag = aVerifyAction();
                                if (flag === false) {
                                    return false;
                                }
                            }
                            flag = $(this).form('validate');
                            return flag;
                        },
                        success: function (data) {
                            var result = $.parseJSON(data);
                            if (result.success && rlform1101.isFunc(aSuccessAction)) {
                                aSuccessAction(result);
                            }
                            else {
                                var msg = result.Message ? result.Message : '提交出错！';
                                rlform1101.messenger.showError(msg);
                                if (rlform1101.isFunc(aErrorAction)) {
                                    aErrorAction(result);
                                }
                            }
                        }
                    });
                }
            })(formId, submitUrl, verifyAction, successAction, errorAction);
            action();
        },
        submitForm2: function (formId, submitUrl, verifyAction, successAction, errorAction, saveSubmitData) {
            var action = (function (aFormId, aSubmitUrl, aVerifyAction, aSuccessAction, aErrorAction, aSaveSubmitData) {
                return function () {
                    var flag = false;
                    if (rlform1101.isFunc(aVerifyAction)) {
                        flag = aVerifyAction();
                        if (flag === false) {
                            return;
                        }
                    }
                    var jMyform = $('#' + aFormId);
                    flag = jMyform.form('validate');
                    if (flag === true) {
                        var newData = jMyform.serializeJson();
                        var jModelInput = $('#input_hd_modelinfo_current');

                        var data = newData;
                        if (rlform1101.isFunc(aSaveSubmitData)) {
                            aSaveSubmitData(data);
                        }
                        //if (jModelInput.length === 1) {
                        //    var modelStr = jModelInput.val();
                        //    if (!rlform1101.isNullOrWhitespace(modelStr)) {
                        //        var modelData = $.parseJSON(modelStr);
                        //        data = $.extend({}, modelData, newData);
                        //    }
                        //}
                        rlform1101.post(aSubmitUrl, data, aSuccessAction, aErrorAction);
                    }
                }
            })(formId, submitUrl, verifyAction, successAction, errorAction, saveSubmitData);
            action();
        },
        bindClick: function (id, action) {
            $('#' + id).click(function () {
                if ($(this).linkbutton('options').disabled == false) {
                    action(this);
                }
            });
        },
        post: function (url, params, successAction, errorAction) {
            $.post(url, params, function (result) {
                result = $.parseJSON(result);
                if (!result.success) {
                    if (rlform1101.isFunc(errorAction)) {
                        errorAction(result);
                    }
                    else {
                        rlform1101.messenger.showError(result.Message);
                    }
                }
                else {
                    if (rlform1101.isFunc(successAction)) {
                        successAction(result);
                    }
                    else {
                        rlform1101.messenger.showMessage(result.Message);
                    }
                }
            });
        },
        syncPost: function (url, params, successAction, errorAction) {
            $.ajax({
                async: false,
                url: url,
                type: 'post',
                contentType: 'application/json;charset=utf-8',
                data: params,
                success: function (result) {
                    result = $.parseJSON(result);
                    if (!result.success) {
                        if (rlform1101.isFunc(errorAction)) {
                            errorAction(result);
                        }
                        else {
                            rlform1101.messenger.showError(result.Message);
                        }
                    }
                    else {
                        if (rlform1101.isFunc(successAction)) {
                            successAction(result);
                        }
                        else {
                            rlform1101.messenger.showMessage(result.Message);
                        }
                    }
                },
                error: function () {
                    alert('error');
                }
            });
        },
        showModelDialog: function (config) {
            var defaultConfig = {
                title: 'dialog',
                width: 800,
                height: 500,
                href: ''
            };
            config = $.extend({}, defaultConfig, config);
            $('#selectMaterialDirContainer').dialog({
                title: '选择目录',
                width: 800,
                height: 500,
                closed: false,
                cache: false,
                href: url,
                modal: true
            });
        }
    };
});

/** * 对Date的扩展，将 Date 转化为指定格式的String * 月(M)、日(d)、12小时(h)、24小时(H)、分(m)、秒(s)、周(E)、季度(q)
    可以用 1-2 个占位符 * 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) * eg: * (new
    Date()).pattern("yyyy-MM-dd hh:mm:ss.S")==> 2006-07-02 08:09:04.423      
 * (new Date()).pattern("yyyy-MM-dd E HH:mm:ss") ==> 2009-03-10 二 20:09:04      
 * (new Date()).pattern("yyyy-MM-dd EE hh:mm:ss") ==> 2009-03-10 周二 08:09:04      
 * (new Date()).pattern("yyyy-MM-dd EEE hh:mm:ss") ==> 2009-03-10 星期二 08:09:04      
 * (new Date()).pattern("yyyy-M-d h:m:s.S") ==> 2006-7-2 8:9:4.18      
 */
Date.prototype.formatDt = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1, //月份         
        "d+": this.getDate(), //日         
        "h+": this.getHours() % 12 == 0 ? 12 : this.getHours() % 12, //小时         
        "H+": this.getHours(), //小时         
        "m+": this.getMinutes(), //分         
        "s+": this.getSeconds(), //秒         
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度         
        "S": this.getMilliseconds() //毫秒         
    };
    var week = {
        "0": "/u65e5",
        "1": "/u4e00",
        "2": "/u4e8c",
        "3": "/u4e09",
        "4": "/u56db",
        "5": "/u4e94",
        "6": "/u516d"
    };
    if (/(y+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    if (/(E+)/.test(fmt)) {
        fmt = fmt.replace(RegExp.$1, ((RegExp.$1.length > 1) ? (RegExp.$1.length > 2 ? "/u661f/u671f" : "/u5468") : "") + week[this.getDay() + ""]);
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(fmt)) {
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        }
    }
    return fmt;
}

String.prototype.trim = function (char, type) {
    if (char) {
        if (type == 'left') {
            return this.replace(new RegExp('^\\' + char + '+', 'g'), '');
        } else if (type == 'right') {
            return this.replace(new RegExp('\\' + char + '+$', 'g'), '');
        }
        return this.replace(new RegExp('^\\' + char + '+|\\' + char + '+$', 'g'), '');
    }
    return this.replace(/^\s+|\s+$/g, '');
};

function rlFormatter1101_have(value, row, index) {
    return value == true ? '有' : '无';
}

function rlFormatter1101_yes(value, row, index) {
    return value == true ? '是' : '否';
}

function rlFormatter1101_date(value, row, index) {
    if (value != '' && value != null && value != undefined) {
        var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
        return date.formatDt('yyyy-MM-dd');
    }
    return '';
}

function rlFormatter1101_able(value, row, index) {
    return value === true ? '可用' : rlform1101.isNull(value) ? '' : '不可用';
}

function rlFormatter1101_ent(value, row, index) {
    var arr = value.split(';'), arr2 = [];
    for (var i in arr) {
        if (!rlform1101.isNullOrWhitespace(arr[i])) {
            arr2.push(arr[i]);
        }
    }
    return arr2.join(';');
}
