// formatter
window.formatter_szrl033 = {
    radio_edit: function (value, row, index) {
        if (row.rl02401) {
            var jRd1 = $('<input/>').attr('type', 'radio').attr('name', 'acceptanceType' + index.toString()).val('0').prop('disabled', true),
                jRd2 = $('<input/>').attr('type', 'radio').attr('name', 'acceptanceType' + index.toString()).val('1').prop('disabled', true);

            var result;
            if (row.rl02303 && (row.rl02303 === 1 || row.rl02303 === 6)) {
                jRd1.attr('checked', true);
                jRd2.hide();
                row.rl03411 = 0;
                result = '<div class="container-innerouter">' + jRd1.prop("outerHTML") + '<label>内部</label></div>';
            }
            else {
                if (value == 0) {
                    jRd1.prop('checked', true).attr('checked', true);
                    row.rl03411 = 0;
                }
                else {
                    jRd2.prop('checked', true).attr('checked', true);
                    row.rl03411 = 1;
                }
                result = '<div class="container-innerouter">' + jRd1.prop("outerHTML") + '<label>内部</label>' + jRd2.prop("outerHTML") + '<label>外部</label>' + '</div>';
            }
            
            return result;
        }
        return '';
    },
    radio_index: function (value, row, index) {
        if (!rlform1101.isNull(row.rl03411)) {
            return value === 0 ? "内部" : "外部";
        }
        return '';
    },

    opereate_edit: function (value, row, index) {
        if (row.rl02401) {
            //var flag = $('#input_hd_acceptflag_edit_szrl033').val() === '1';
            return '<a href="#" class="btn-state1" onclick="startEdit(' + index + ', this)">编辑</a><a href="#" class="btn-state2" onclick="endEdit(' + index + ', this)" style="display:none;width: 50px;">修改</a><a href="#" class="btn-state2" onclick="cancelEdit(' + index + ', this)" style="display:none;margin-left:15px;">取消</a>'
        }
        return '';
    },

    attachfiles_edit: function (value, row, index) {
        if (row.rl02401) {
            // 附件ID
            var id = row.rl03413, count = row.AttachFileCount ? row.AttachFileCount.toString() : "0";
            if (window.editRow !== undefined) {
                // 附件信息
                $.ajax({
                    async: false,
                    url: '/AreasCode030/szrl033/Get_AttachFileCount?key=' + id,
                    type: 'post',
                    contentType: 'application/json;charset=utf-8',
                    success: function (data) {
                        count = data.FileCount;
                        row.AttachFileCount = count;
                    }
                });
            }
            return '<a href="#" onclick="viewAttachFiles(\'' + id + '\', this)" class="btn-attach-state1">' + count + '个附件</a><a href="#" onclick="doAttachFiles(\'' + id + '\', this)" class="btn-attach-state2" style="display:none;">添加附件</a>';
        }
        return '';
    },

    status_edit: function (value, row, index) {
        if (row.rl02401) {
            return value === 1 ? "已验收" : "未验收";
        }
        return '';
    },
    groupview_index: function (value, rows) {
        return value;
    }
}

/**
        * EasyUI DataGrid根据字段动态合并单元格
        * @param fldList 要合并table的id
        * @param fldList 要合并的列,用逗号分隔(例如："name,department,office");
        */
function mergeCellsByField(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    for (i = length; i >= 0; i--) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row][fldName];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                dg.datagrid('mergeCells', {
                    index: index,
                    field: fldName,
                    rowspan: span,
                    colspan: null
                });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
}

/// 主页加载完成
function onLoadSuccess_index_szrl033(data) {
    if (data.rows.length > 0) {
        mergeCellsByField("dg_index_szrl033", "rl00403,rl01807,rl01903");
    }
}

// 单元格合并
function onLoadSuccess_edit_szrl033(data) {
    if (data.rows.length > 0) {
        mergeCellsByField("dg_nav_edit_szrl033", "rl00403,rl01807,rl01903");
    }

    var id = $.getUrlParam('id');
    for (var i = 0; i < data.rows.length; i++) {
        if (data.rows[i].rl01902 === id) {
            $('#dg_nav_edit_szrl033').datagrid('selectRow', i);
            break;
        }
    }
}