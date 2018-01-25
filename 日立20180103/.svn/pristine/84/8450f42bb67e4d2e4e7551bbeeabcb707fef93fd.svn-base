/**
 * mail:caoguanghuicgh@163.com
 * Page:http://www.easyui.info
 * 如有疑问请在本页留言交流
 * 
 * 扩展combobox方法集合
 */
$.extend($.fn.combobox.methods, {
    /**
     * 版本要求1.3.4+
     * 向combobox的下拉列表中追加一项数据
     * 带分组的话，会到对应分组最后追加，如果是新分组，则追加到最后
     */
    appendRow: function (jq, param) {
        return jq.each(function () {
            var state = $.data(this, 'combobox');
            var opts = state.options;
            var data = state.data;
            var groups = state.groups || [];
            var panel = $(this).combo('panel');
            var g = param[opts.groupField];
            var s = param[opts.textField];
            var v = param[opts.valueField] + '';
            var groupExist = false;
            var insertPos = 0;
            var selected = $(this).combobox('getValues');
            for (var i = 0; i < data.length; i++) {
                // value is exist ,do nothing, just return
                if (data[i][[opts.valueField]] === v) return
            }
            if (g != null) {
                if ($.inArray(g, groups) != -1) {
                    var getted = false;
                    for (var i = 0; i < data.length; i++) {
                        var rowGroup = data[i][opts.groupField];
                        if (rowGroup == g) {
                            getted = true;
                        } else {
                            if (getted) {
                                data.splice(i, 0, param);
                                insertPos = i;
                                break;
                            }
                        }
                    }
                    insertRow(this, insertPos, g, s);
                } else {
                    groups.push(g);
                    insertRow(this, data.length, g, s, true);
                    data.push(param);
                }
            } else {
                insertRow(this, data.length, g, s);
                data.push(param);
            }
            if (param['selected'] && $.inArray(v, selected) == -1) {
                selected.push(v);
            }
            if (opts.multiple) {
                $(this).combobox('setValues', selected);
            } else {
                $(this).combobox('setValues', selected.length ? [selected[selected.length - 1]] : []);
            }
            function insertRow(target, pos, group, text, gi) {
                panel.children().each(function () {
                    if ($(this).hasClass('combobox-group')) return true;
                    var id = this.id;
                    var idx = parseInt(id.substring(state.itemIdPrefix.length + 1));
                    if (idx >= pos) {
                        $(this).attr('id', state.itemIdPrefix + '_' + (idx + 1));
                    }
                });
                var dd = [];
                if (gi) {
                    dd.push('<div id="' + (state.groupIdPrefix + '_' + (state.groups.length - 1)) + '" class="combobox-group">');
                    dd.push(opts.groupFormatter ? opts.groupFormatter.call(target, group) : group);
                    dd.push('</div>');
                }
                var cls = 'combobox-item' + (param.disabled ? ' combobox-item-disabled' : '') + (group ? ' combobox-gitem' : '');
                dd.push('<div id="' + (state.itemIdPrefix + '_' + pos) + '" class="' + cls + '">');
                dd.push(opts.formatter ? opts.formatter.call(target, param) : text);
                dd.push('</div>');
                $(dd.join('')).insertAfter(panel.find('>div#' + state.itemIdPrefix + '_' + (pos - 1)));
            }
        });
    },
    /**
     * 版本要求1.3.4+
     * 根据valueFiled的值删除combobox下拉列表某一项
     */
    deleteRow: function (jq, param) {
        return jq.each(function () {
            var state = $.data(this, 'combobox');
            var opts = state.options;
            var data = state.data;
            var groups = state.groups || [];
            var panel = $(this).combo('panel');
            var selected = $(this).combobox('getValues');
            var len = data.length;
            var idx = -1;
            while (len--) {
                var row = data[len];
                if (param == row[opts.valueField]) {
                    idx = len;
                    break;
                }
            }
            if (idx == -1) return;
            var deleteGroup = false;
            if (data[idx][opts.groupField]) {
                len = data.length;
                var gCount = 0;
                while (len--) {
                    var row = data[len];
                    if (data[idx][opts.groupField] == row[opts.groupField]) {
                        gCount++;
                    }
                }
                if (gCount == 1) {
                    var glen = groups.length;
                    while (glen--) {
                        if (data[idx][opts.groupField] == groups[glen]) {
                            groups.splice(glen, 1);
                        }
                    }
                    deleteGroup = true;
                }
            }
            data.splice(idx, 1);
            var item = panel.find('>div#' + state.itemIdPrefix + '_' + idx);
            if (deleteGroup) item.prev().remove();
            item.remove();
            var isSelected = false;
            for (var i = 0; i < selected.length; i++) {
                if (selected[i] == param) {
                    isSelected = true;
                    selected.splice(i, 1);
                }
            }
            if (isSelected) {
                if (opts.multiple) {
                    $(this).combobox('setValues', selected);
                } else {
                    $(this).combobox('clear');
                }
            }
            panel.children().each(function () {
                if ($(this).hasClass('combobox-group')) return true;
                var id = this.id;
                var _idx = parseInt(id.substring(state.itemIdPrefix.length + 1));
                if (_idx > idx) {
                    $(this).attr('id', state.itemIdPrefix + '_' + (idx - 1));
                }
            });
        });
    },
    /**
     * 版本要求....遇坑自行百度
     * 选择指定选项
     */
    selectedIndex: function (jq, index) {
        if (!index)
            index = 0;
        var data = $(jq).combobox('options').data;
        var vf = $(jq).combobox('options').valueField;
        $(jq).combobox('setValue', eval('data[index].' + vf));
    }
});
