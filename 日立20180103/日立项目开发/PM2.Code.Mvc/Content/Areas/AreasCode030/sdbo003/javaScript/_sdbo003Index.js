﻿/*
 *********全局变量**************
 */
var whetherchange = false;//是否发生了变更
var zuofanid = null;//作番id
var _versioNnumber = null;//版本号
var _changeType = "";//变更类型
var _measureUnits = null;//klbde单位
var _save082 = null;
var _save083 = null;
var _save084 = null;
var klbde_ux_Grid_del_id = new Array();
var aj_ux_Grid_del_id = new Array();
var _s_n_ux_grid_del_id = new Array();
var KLBDE_sum = 0;
var versioNnumber_combo = false;
//A~J明细导入目录代码
var products = null;
//var products = [
//    { id: 'A', text: '工事用消耗資材' },
//    { id: 'C', text: '現場臨時員労務費' },
//    { id: 'D2', text: '仮設事務費' },
//    { id: 'F', text: '監督費(賃率・旅費)' },
//    { id: 'G', text: '工具損料' },
//    { id: 'H', text: '保険料　(受注金額*0.18%)' },
//    { id: 'J1', text: '雑費' },
//    { id: 'J2', text: '办公用品/事務用品費' },
//    { id: 'J3', text: '城建税及び附加等' },
//    { id: 'J4', text: '差旅费/交通費' },
//    { id: 'J5', text: '通讯费/通信費' },
//    { id: 'J6', text: '交際費(受注額*0.2%)' },
//    { id: 'J8', text: '福利费/福利費' },
//    { id: 'M', text: '保管運搬費' },
//    { id: 'N', text: '企画設計費(機器納入設計企画)' }

//];



/*
 *********全局变量**************
 */
function showcontent(language) {
    $('#content').html('Introduction to ' + language + ' language');
}

$(function () {
    forbidden("disable");
    GetForSome();
});
$("input[name='forsome']").click(function () {
    GetForSome();
});
//获取作番导航
function GetForSome() {
    var forsome = $('input[name="forsome"]:checked ').val()
    $('#szrl001Tree').tree({
        url: '/AreasCode030/szrl001/TreeLoad',
        animate: true,
        onBeforeLoad: function (node, param) {
            if (node == null)
                param.forsome = forsome;
            param.budgetimple = "1";
        },
        onClick: function (node) {

            $(this).tree('expand', node.target);
            if (node.attributes) {
                var nodemessage = node.attributes.nodeType;//获取作番号
                if (nodemessage != "szrl001" && nodemessage != "szrl004") {
                    zuofanid = nodemessage;
                    versioNnumber_combo = true;
                    Init_com();
                    SetInfo();
                }
            }
        },
        onCollapse: function (node) {
            $(this).tree('collapseAll', node.target);
        }
    });
    GetMeasureUnits();
    GetAjMenu();
}
function SetInfo() {
    whetherchange = false;
    setTimeout(function () {
        if (zuofanid) {
            $("#szrl082From").form({
                onLoadSuccess: function (_record) {//_record获取的数据
                    for (var key in _record) {
                        $('p[name=' + key + ']').html(_record[key]);
                        //$('td[name=' + key + ']').html(_record[key]);
                    }
                    GetInfoData(_record);
                },
                onLoadError: function () {
                }
            });
            var _url = "/AreasCode030/sdbo003/GetIndexInfo?zuofanid=" + zuofanid + "&rl02503=" + "0" + "&versioNnumber=" + _versioNnumber;//0 初回
            $('#szrl082From').form('load', _url);
        }
    }, 300);
}
function GetInfoData(_record) {
    
    load();
    partial_4_clear();
    maketochange(false);
    _versioNnumber = _record.rl08203;
    _changeType = _record.rl08234;
    $("#rl08237").text(_record.rl08237);
    $("#rl08238").text(_record.rl08238);
    $("#rl08239").text(_record.rl08239);
    $("#rl08240").text(_record.rl08240);
    $("#rl08225").val(_record.rl02535);
    $("#_012").text(_record.rl02520 >= 800000 ? "预算查定" : "预算查定不要");
    $("#_014").text(_record.rl01835 == 3 ? "简易计税" : "一般计税");
    $("#_015").text(_record.rl01835 + "%");
    $("#_029").text("SHPCS-R-P10-018-1");
    $("#_030").text("2016年5月15改定版");
    $("#rl08227").text(_record.rl08227 + "%");
    $("#rl08244").text(_record.rl08244 + "%");
    $("#rl08245").text(_record.rl08245 + "%");
    $("#_006").text(_record.rl02503 == "0" ? "初回" : _record.rl02503);
    setTimeout(function () {
        InitializationButton(_record);
        sdpk007_ux_fun(zuofanid);
        GetpvInfo();
        GetKLBDEInfo();
        GetAJInfo();
        Set_sp(_record);
        special_notes_ux_grid();
        partial_1();
        maketochange(!IsNullOrEmpty(_record.rl08234));
        $("#rl08235").val(_record.rl08235);
        cannotModifiedWhileUpdating();
        disLoad();
    }, 500);
    klb_sum_ux_grid();
}




//穿透到受注传票
$('#_007').linkbutton({
    onClick: function () {
        var _rl02503 = $(".rl02503").text();
        if (_rl02503 == "初回") {
            _rl02503 = '0';
        }
        var _url = "/AreasCode030/szrl025/Index?zuofanid=" + zuofanid + "&versionNumber=" + _rl02503;
        window.open(_url);
    }
});

$(function () {
    $(".textright").each(function () {
        var tdnum = $(this).text();
        if (!isNaN(tdnum) && tdnum) {
            var tdnewnum = toThousands(tdnum);
            $(this).text(tdnewnum);
        }
    });
});
//金钱加千位符
function toThousands(num) {
    return (num || 0).toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,');
}

function GetpvInfo() {
    var $grid = $("#_pv_klbde_ux_Grid");
    $grid.datagrid({
        url: "/AreasCode030/sdbo003/GetpvcnbInfo?zuofanid=" + zuofanid + "&versionnumber=" + _versioNnumber,//1234
        method: 'POST',
        //title: '版本明细对比',
        fit: false,
        //iconCls: 'icon-save',//图标  
        height: 600,
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: true,
        idField: "rl08301",
        sortable: true,
        remoteSort: false,
        scrollbarSize: 0,
        pagePosition: 'bottom',
        columns: [[
            { field: 'f_rl08302', title: '一级目录' },
            { field: 'f_rl08303', title: '二级目录' },
            { field: 'f_rl08304', title: '材料编码' },
            { field: 'f_rl08305', title: '件品名及摘要' },
            { field: 'f_rl08306', title: '报价名称' },
            {
                field: 'f_rl08307', title: '数量',
                formatter: RgNaN_ux_grid
            },
            { field: 'f_rl08315', title: '单位' },
            {
                field: 'f_rl08308', title: '税込金額——単価(税込）',
                formatter: RgNaN_ux_grid
            },
            {
                field: 'f_rl08309', title: '税込金額——小計（税込）',
                formatter: RgNaN_ux_grid
            },
            {
                field: 'f_rl08310', title: '税込金額——計（税込）',
                formatter: RgNaN_ux_grid
            },
            { field: 'f_rl08311', title: '税率' },
            {
                field: 'f_rl08312', title: '税抜金額——単価(税抜）',
                formatter: RgNaN_ux_grid
            },
            {
                field: 'f_rl08313', title: '税抜金額——小計（税抜）',
                formatter: RgNaN_ux_grid
            },
            {
                field: 'f_rl08314', title: '税抜金額——計（税抜）',
                formatter: RgNaN_ux_grid
            },
            { field: 'b_rl08302', title: '一级目录' },
            { field: 'b_rl08303', title: '二级目录' },
            {
                field: 'b_rl08304', title: '材料编码',
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08305', title: '件品名及摘要',
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08306', title: '报价名称',
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08307', title: '数量',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08315', title: '单位',
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08308', title: '税込金額——単価(税込）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08309', title: '税込金額——小計（税込）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08310', title: '税込金額——計（税込）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08311', title: '税率',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08312', title: '税抜金額——単価(税抜）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08313', title: '税抜金額——小計（税抜）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            },
            {
                field: 'b_rl08314', title: '税抜金額——計（税抜）',
                formatter: RgNaN_ux_grid,
                styler: Rgcolor_ux_grid
            }
        ]],
        onLoadSuccess: function (obj) {
            //console.log(obj);
        }
    });
}
function Rgcolor_ux_grid(value, row, index) {
    if (row.f_rl08302 == null && row.f_rl08303 == null) {
        if (row.f_rl08304 == null && row.b_rl08304 != null) {
            return 'color:red';
        }
        if (Number(row.f_rl08307) * Number(row.f_rl08308) != Number(row.b_rl08307) * Number(row.b_rl08308)) {
            return 'color:red';
        }
    }
    return 'color:black';
}
function RgNaN_ux_grid(val, rowData, rowIndex) {
    return checkRate(val);
}

function GetKLBDEInfo() {
    var $grid = $("#klbde_ux_Grid");
    $grid.datagrid({
        url: "/AreasCode030/sdbo003/GetKLBDEInfo?zuofanid=" + zuofanid + "&versionnumber=" + _versioNnumber,
        method: 'POST',
        //title: 'KLBDE明细',
        fit: false,
        //iconCls: 'icon-save',//图标  
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: true,
        idField: "rl08301",
        sortable: true,
        remoteSort: false,
        scrollbarSize: 0,
        pagePosition: 'bottom',
        toolbar: [
            {
                id: "k_add",
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    openTopWindow();

                }
            }
            ,
            '-',
            {
                id: "k_remove",
                text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    var $grid = $('#klbde_ux_Grid');
                    var row = $grid.datagrid('getSelected');
                    var _voucherId = row.rl08301;
                    if (row.rl08304) {
                        var rowIndex = $grid.datagrid('getRowIndex', row);
                        $grid.datagrid("deleteRow", rowIndex);
                        arry_evaluate(_voucherId, klbde_ux_Grid_del_id);
                    } else {
                        $.messager.alert('友情提示', "此条不可删除!", 'error');
                    }
                }
            }
            ,
            '-',
            {
                id: "k_import",
                text: '导入',
                iconCls: 'icon-add',
                handler: function () {
                    import_klbde();
                }
            }
        ],
        columns: [[
            { field: 'rl08302', title: '一级目录', width: 150 },
            { field: 'rl08303', title: '二级目录', width: 150 },
            { field: 'rl08304', title: '材料编码', width: 150 },
            { field: 'rl08305', title: '件品名及摘要', width: 150 },
            { field: 'rl08306', title: '报价名称', width: 150 },
            {
                field: 'rl08307', title: '数量', width: 150,
                editor: { type: 'numberbox', options: { precision: 1 } },
                formatter: RgNaN_ux_grid

            },
            {
                field: 'rl08315', title: '单位', width: 150,
                formatter: function (value) {
                    for (var i = 0; i < _measureUnits.length; i++) {
                        if (_measureUnits[i].pa01301 == value) return _measureUnits[i].pa01302;
                    }
                    return value;//1234
                },
                editor: {
                    type: 'combobox',
                    options: {
                        valueField: 'pa01301',
                        textField: 'pa01302',
                        data: _measureUnits,
                        required: true
                    }
                }
            },
            {
                field: 'rl08308', title: '税込金額——単価(税込）', width: 150, editor: { type: 'numberbox', options: { precision: 1 } },
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08309', title: '税込金額——小計（税込）', width: 150,
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08310', title: '税込金額——計（税込）', width: 150,
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08311', title: '税率', width: 150, editor: { type: 'numberbox', options: { precision: 1 } },
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08312', title: '税抜金額——単価(税抜）', width: 150, editor: { type: 'numberbox', options: { precision: 1 } },
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08313', title: '税抜金額——小計（税抜）', width: 150,
                formatter: RgNaN_ux_grid
            },
            {
                field: 'rl08314', title: '税抜金額——計（税抜）',
                formatter: RgNaN_ux_grid
            }

        ]],
        onLoadSuccess: function (obj) {
            var data = obj.rows;
            KLBDE_sum = 0;
            for (var i = 0; i < data.length; i++) {
                if (data[i].rl08302 != null) {
                    KLBDE_sum += data[i].rl08310;//KLBDE总金额
                }
            }
        }
    });
    grid_edit_del($grid)
}

function import_klbde() {
    var content = '<iframe src="/AreasCode030/sdbo003/KlbdeImport" width="100%" height="99%" frameborder="0" scrolling="no"></iframe>';
    $('#importContainer_klbde').dialog({
        title: '导入向导',
        width: 900,
        height: 600,
        closed: false,
        cache: false,
        content: content,
        modal: true
    });
}



function DeleteVoucher_083(row) {

    $.post("/AreasCode030/sdbo003/DeleteVoucher_083", {
        data: JSON.stringify(row)

    }, function (obj) {
        var data = $.parseJSON(obj);
        if (data.success) {
            GetKLBDEInfo();
            $.messager.alert('友情提示', data.Message, 'info');

        }
        else {
            $.messager.alert('友情提示', data.Message, 'error');
        }
    });
}
function DeleteVoucher_084(row) {
    $.ajax({
        url: "/AreasCode030/sdbo003/DeleteVoucher_084",
        type: "POST",
        data: JSON.stringify({
            _szrl084s: row
        }),
        success: function (obj) {
            var data = $.parseJSON(obj);
            if (data.success) {
                $.messager.alert('友情提示', data.Message, 'info');
            }
            else {
                $.messager.alert('友情提示', data.Message, 'error');
            }

        }
    });
}

//提交或者更新klbde导入
function dg_submit(_row_change) {
    $.ajax({
        url: "/AreasCode030/sdbo003/SaveVoucher_083",
        type: "POST",
        data: {
            vParams: JSON.stringify(_row_change)
        },
        success: function (data) {

        }
    });
}


function openTopWindow() {
    $('#_klbde_Win').window('open');  // open a window   
    $('#szrl083_ux_Grid').datagrid('reload', {});
    $("#szrl083_ux_Grid").datagrid({
        url: "/AreasCode030/sdbo003/GetSzrl11Info",
        //url: "/AreasCode030/sdbo003/GetSzrl11Info?zuofanid=''&rl11211=''",
        data: {
            zuofanid: zuofanid,
            rl11211: ''
        },
        width: 800,
        height: 480,
        method: 'POST',
        //title: '材料库',
        fit: true,
        //iconCls: 'icon-save',//
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: false,
        idField: "rl11201",
        sortable: true,
        remoteSort: false,
        rownumbers: true,
        pagination: true,
        scrollbarSize: 0,
        pageSize: 10,
        pageList: [10, 20, 30],//可以设置每页记录条数的列表  
        pagePosition: 'bottom',
        onClickRow: function (rowIndex, record) {
            _seRrecord = record;
        },
        toolbar: [

            {
                id: "cd_first",
                text: '<input id="cd_first" name="cd_first" class="easyui-combobox"/>',
                handler: function () {
                    $('#cd_first').combobox({
                        url: '/AreasCode030/sdbo003/LevelMenu',
                        valueField: 'rl11211',
                        textField: 'rl11204',
                        onChange: function (newValue, oldValue) {
                            var url = "/AreasCode030/sdbo003/LevelMenu2?_levelmenu=" + newValue;
                            $('#cd_two').combobox('clear');
                            $('#cd_two').combobox('reload', url);
                        }
                    });
                }
            }
            ,
            '-',
            {
                id: "cd_two",
                text: '<input id="cd_two" class="easyui-combobox" name="cd_two" value="">',
                handler: function () {
                    var _cd_first = $('#cd_first').combobox('getValue');
                    $('#cd_two').combobox({
                        url: '/AreasCode030/sdbo003/LevelMenu2?_levelmenu=' + _cd_first,
                        valueField: 'rl11211',
                        textField: 'rl11204'
                    });
                }
            }
            ,
            '-',
            {
                id: "cd_cx",
                iconCls: 'icon-search',
                text: '查询',
                handler: function () {
                    var _cd_two = $('#cd_two').combobox('getValue');
                    if (_cd_two == "") return false;
                    $('#szrl083_ux_Grid').datagrid('load', {
                        zuofanid: zuofanid,
                        rl11211: _cd_two
                    });
                }
            },
            '-',
            {
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    var _rows = $('#szrl083_ux_Grid').datagrid('getSelections');
                    var _cd_first = $('#cd_first').combobox('getText');
                    var _cd_two = $('#cd_two').combobox('getText');
                    SaveVoucher(_rows, _cd_first, _cd_two);
                }
            }
        ],
        columns: [[
            { field: 'rl11204', title: '名称', width: 150 }
        ]],
        onBeforeEdit: function (index, row) {
            row.editing = true;
            // updateActions(index);
        }
    });

    //$('#DIV_toolbar').appendTo('#szrl083_ux_Grid');  
}

function GetSzrl11Info(parameter) {
    $.ajax({
        type: "POST",
        url: "/AreasCode030/sdbo003/GetSzrl11Info",
        data: parameter,
        success: function (data) {
            var converData = $.parseJSON(data);
            $("#szrl083_ux_Grid").datagrid("loadData", converData);

        }
    });

}

//新增行
function klbde_ux_Grid_appenrow(_row, _cd_first, _cd_two) {
    $('#klbde_ux_Grid').datagrid('insertRow', {
        index: 0,
        row: {
            rl08302: _cd_first,
            rl08303: _cd_two,
            rl08304: _row.rl11203,
            rl08305: _row.rl11204,
            rl08306: _row.rl11204,
            rl08307: '0',
            rl08308: '0',
            rl08309: '0',
            rl08310: '0',
            rl08311: '0',
            rl08312: '0',
            rl08313: '0',
            rl08314: '0'
        }
    });
    $('#klbde_ux_Grid').datagrid('selectRow', 0);
    $('#klbde_ux_Grid').datagrid('beginEdit', 0);
}
//保存选择的材料明细
function SaveVoucher(_rows, _cd_first, _cd_two) {
    for (var i = 0; i < _rows.length; i++) {
        var _row = _rows[i];
        klbde_ux_Grid_appenrow(_row, _cd_first, _cd_two);
    }
    $('#szrl083_ux_Grid').datagrid('clearSelections');
    $('#_klbde_Win').window('close');  // open a window   
}

//获取计量单位的json字符串
function GetMeasureUnits() {
    $.ajax({
        url: "/AreasCode030/szrl111/GetMeasureUnits",
        type: "POST",
        success: function (data) {
            _measureUnits = data;
        }
    });
}
//获取aj菜单
function GetAjMenu() {
    $.ajax({
        url: "/AreasCode030/sdbo003/AjMenu",
        type: "POST",
        success: function (data) {
            products = data;
            console.log(products);
        }
    });
}




/*
*************************A~J明细导入******************************************
*/



function GetAJInfo() {
    var $grid = $('#aj_ux_Grid');
    $grid.datagrid({
        //title: 'AJ明细导入',
        //iconCls: 'icon-edit',
        singleSelect: true,
        fitColumns: true,
        type: "POST",
        idField: 'rl08401',
        url: '/AreasCode030/sdbo003/GetajInfo?rl08415=' + zuofanid + "&rl08416=" + _versioNnumber,
        columns: [[
            {
                field: 'rl08402', title: '目录代码', 
                formatter: function (value) {
                    for (var i = 0; i < products.length; i++) {
                        if (products[i].rl11203 == value) {
                            return products[i].rl11203;
                        }
                    }
                    return value;

                },
                editor: {
                    type: 'combobox',
                    options: {
                        valueField: 'rl11203',
                        textField: 'rl11203',
                        data: products,
                        required: true
                    }
                }
            },
            { field: 'rl08403', title: '一级目录' , align: 'right'/*, editor: { type: 'numberbox', options: { precision: 1 } }*/ },
            { field: 'rl08404', title: '材料编码', align: 'right'/*, editor: 'numberbox'*/ },
            { field: 'rl08405', title: '件品名及摘要'/*, editor: 'text'*/ },
            { field: 'rl08406', title: '数量'/*, editor: 'text'*/ },
            { field: 'rl08407', title: '单位'/*, editor: 'text'*/ },
            { field: 'rl08408', title: '件品名及摘要'/*, editor: 'text'*/ },
            { field: 'rl08408', title: '税込金額——単価(税込）'},
            { field: 'rl08409', title: '税込金額——小計（税込）'},
            { field: 'rl08410', title: '税込金額——計（税込）', editor: { type: 'numberbox', options: { precision: 1 } } },
            { field: 'rl08411', title: '税率' },
            { field: 'rl08412', title: '税抜金額——単価(税抜）' },
            { field: 'rl08413', title: '税抜金額——小計（税抜）' },
            { field: 'rl08414', title: '税抜金額——計（税抜）'/*, editor: { type: 'numberbox', options: { precision: 1 } }*/ }
        ]],
        toolbar: [
            {
                id: "a_add",
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    insert();
                }
            }
            ,
            '-',
            {
                id: "a_remove",
                text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    var row = $grid.datagrid('getSelected');
                    var _voucherId = row.rl08401;

                    var rowIndex = $grid.datagrid('getRowIndex', row);
                    $grid.datagrid("deleteRow", rowIndex);
                    arry_evaluate(_voucherId, aj_ux_Grid_del_id);


                    //var row = $('#aj_ux_Grid').datagrid('getSelected');
                    ////var _voucherId = row.VoucheId;
                    ////var _circulationNumber = row.CirculationNumber;
                    //DeleteVoucher_084(row);
                }
            }
            ,
            '-',
            {
                id: "a_import",
                text: '导入',
                iconCls: 'a-add',
                handler: function () {
                    import_aj();
                }
            }
        ],
        onBeforeEdit: function (index, row) {
            row.editing = true;
            // updateActions(index);
        },
        onAfterEdit: function (index, row) {
            row.editing = false;
            updateActions(index);
        },
        onCancelEdit: function (index, row) {
            row.editing = false;
            updateActions(index);
        }
    });
    grid_edit_del($grid)
}
function import_aj() {
    var content = '<iframe src="/AreasCode030/sdbo003/AJImport" width="100%" height="99%" frameborder="0" scrolling="no"></iframe>';
    $('#importContainer_aj').dialog({
        title: '导入向导',
        width: 900,
        height: 600,
        closed: false,
        cache: false,
        content: content,
        modal: true
    });
}

function updateActions(index) {
    $('#aj_ux_Grid').datagrid('updateRow', {
        index: index,
        row: {}
    });
}
function getRowIndex(target) {
    var tr = $(target).closest('tr.datagrid-row');
    return parseInt(tr.attr('datagrid-row-index'));
}
function editrow(target) {
    $('#aj_ux_Grid').datagrid('beginEdit', getRowIndex(target));
}
function deleterow(target) {
    $.messager.confirm('Confirm', '您确认想要删除此次明细吗?', function (r) {
        if (r) {
            $('#aj_ux_Grid').datagrid('deleteRow', getRowIndex(target));
        }
    });
}
function saverow(target) {
    $('#aj_ux_Grid').datagrid('endEdit', getRowIndex(target));
}
function cancelrow(target) {
    $('#aj_ux_Grid').datagrid('cancelEdit', getRowIndex(target));
}
function insert() {
    //var row = $('#aj_ux_Grid').datagrid('getSelected');
    //if (row) {
    //    var index = $('#aj_ux_Grid').datagrid('getRowIndex', row);
    //} else {
    //    index = 0;
    //}
    $('#aj_ux_Grid').datagrid('insertRow', {
        index: 0,
        row: {
            rl08411: '0'
        }
    });
    $('#aj_ux_Grid').datagrid('selectRow', 0);
    $('#aj_ux_Grid').datagrid('beginEdit', 0);
}



/*
*************************A~J明细导入******************************************
*/



/*

*******************计划进度编制*************************
*/
function Set_sp(_record) {
    var _th_count = $("#_schedulePlanning_ux_Grid tr:first-child > th").length;
    if (_th_count != 1) {
        for (var i = 0; i < _th_count - 1; i++) {
            $("#_schedulePlanning_ux_Grid tr > th:last-child,#_schedulePlanning_ux_Grid tr > td:last-child").remove();
            if ($("#_schedulePlanning_select_Grid").find('th').eq(-1).text() != "年/月") {
                $("#_schedulePlanning_select_Grid tr > th:last-child,#_schedulePlanning_select_Grid tr > td:last-child").remove();
            }
        }
    }
    if (_record.rl08502 != null) {

        var _rl08502s = _record.rl08502.split(';');
        var _rl08503s = _record.rl08503.split(';');
        var _rl08504s = _record.rl08504.split(';');
        var _rl08505 = _record.rl08505;
        if (_rl08502s.length > 1) {
            for (var i = 0; i < _rl08502s.length - 1; i++) {
                var _now_date = _rl08502s[i];
                var _td_1 = _rl08503s[i];
                var _td_2 = _rl08504s[i];
                $th = "<th style='white-space: nowrap;'>" + _now_date + "</th>";
                $col_1 = "<td style='white-space: nowrap;'> <input for='sp_ux_text' class=\"easyui-numberbox\" type=\"text\" name=\"name\" value=\"" + _td_1 + "\"  style=\"border:0;\" readonly=\"readonly\" data-options=\"suffix:'%'\"  /> </td>";
                $col_2 = "<td style='white-space: nowrap;'> <input for='sp_ux_text' class=\"easyui-numberbox\" type=\"text\" name=\"name\" value=\"" + _td_2 + "\"  style=\"border:0;\" readonly=\"readonly\" data-options=\"suffix:'%'\" /> </td>";
                $col_3 = "<td style='white-space: nowrap;'> <input for='sp_ux_text' class=\"easyui-numberbox\" type=\"text\" name=\"name\" value=\"\"  style=\"border:0;\" readonly=\"readonly\" data-options=\"suffix:'%'\" /> </td>";
                $("#_schedulePlanning_ux_Grid>thead>tr").append($th);
                $("#_schedulePlanning_ux_Grid>tbody>tr:eq(0)").append($col_1);
                $('#_schedulePlanning_ux_Grid>tbody>tr:eq(1)').append($col_2);
                $('#_schedulePlanning_ux_Grid>tbody>tr:eq(2)').append($col_3);
                if (i < 1) {
                    $('#_schedulePlanning_ux_Grid>tbody>tr:eq(2)').find('td:eq(1)').text(_rl08505);
                }
                //对表纸的计划进度赋值 :此处和上面的代码  有空时进行封装
                if (i < 18) {
                    $("#_schedulePlanning_select_Grid>thead>tr").append($th);
                    $("#_schedulePlanning_select_Grid>tbody>tr:eq(0)").append($col_1);
                    $('#_schedulePlanning_select_Grid>tbody>tr:eq(1)').append($col_2);
                    $('#_schedulePlanning_select_Grid>tbody>tr:eq(2)').append($col_3);
                    if (i < 1) {
                        $('#_schedulePlanning_select_Grid>tbody>tr:eq(2)').find('td:eq(1)').text(_rl08505);
                    }
                }
                mergeCell();
            }
        }
        //$('[for="sp_ux_text"]').each(function () {
        //    $(this).numberbox({
        //        suffix:'%'
        //    });
        //});
    }
}


$('#_schedulePlanning_ux_Grid_insert').linkbutton({
    onClick: function () {
        var _th_last_text = $("#_schedulePlanning_ux_Grid tr > th:last-child").text();
        var _now_date = "";
        if (_th_last_text == "年/月") {
            var myDate = new Date();
            var year = myDate.getFullYear().toString().slice(-2);
            var month = myDate.getMonth() + 1;
            _now_date = year + "年" + month + "月";
        }
        else {
            var get_year = Number(_th_last_text.substring(0, _th_last_text.indexOf("年")));
            var get_month = Number(_th_last_text.substring(_th_last_text.indexOf("年") + 1, _th_last_text.indexOf("月")));
            if (get_month == 12) {
                get_year = get_year + 1;
                get_month = 1;
            }
            else {
                get_month = get_month + 1;
            }
            _now_date = get_year + "年" + get_month + "月";
        }
        $th = $("<th style='white-space: nowrap;'>" + _now_date + "</th>");
        $col = $("<td style='white-space: nowrap;'> <input class=\"easyui-numberbox\" type=\"text\" name=\"name\" value=\"\"  style=\"border:0;\" data-options=\"suffix:'%'\"  />  </td>");
        $("#_schedulePlanning_ux_Grid>thead>tr").append($th);
        $("#_schedulePlanning_ux_Grid>tbody>tr").append($col);
        mergeCell();
    }
});
$('#_schedulePlanning_ux_Grid_remove').linkbutton({
    onClick: function () {
        var _th_count = $("#_schedulePlanning_ux_Grid tr:first-child > th").length;
        if (_th_count == 1) {
            return false;
        }
        $("#_schedulePlanning_ux_Grid tr > th:last-child,#_schedulePlanning_ux_Grid tr > td:last-child").remove();
    }
});
//进度计划编制最后一行为不可编辑
function mergeCell() {
    $('#_schedulePlanning_ux_Grid tr:last').find('td').addClass('end').find('input').attr("readonly", "readonly");
    $('#_schedulePlanning_select_Grid tr:last').find('td').addClass('end').find('input').attr("readonly", "readonly");
}
//提交
function saveSzrl085() {
    var $tds_rl08502 = $("#_schedulePlanning_ux_Grid tr:first-child > th");
    var $tds_rl08503 = $("#_schedulePlanning_ux_Grid").find('tr').eq(1).find('td').find('input');
    var $tds_rl08504 = $("#_schedulePlanning_ux_Grid").find('tr').eq(2).find('td').find('input');
    _save082 = "";
    _save083 = "";
    _save084 = "";
    $($tds_rl08502).each(function (i) {
        if (i != 0) {
            _save082 = _save082 + $(this).text() + ";";
        }
    });
    $($tds_rl08503).each(function (i) {
        _save083 = _save083 + $(this).val() + ";";
    });
    $($tds_rl08504).each(function (i) {
        _save084 = _save084 + $(this).val() + ";";
    });

    // console.log(rl08502, rl08503, rl08504);
}

//_save083




//此方法已被停用
function _ux_grid_del() {
    $.ajax({
        url: "/AreasCode030/sdbo003/ux_del?p1=" + klbde_ux_Grid_del_id + "&p2=" + aj_ux_Grid_del_id + "&p3=" + _s_n_ux_grid_del_id,
        //url: null,
        type: "POST",
        success: function (obj) {
            var data = $.parseJSON(obj);
            if (data.success) {
                return false;
            }
            else {
                $.messager.alert("友情提示", obj.Message, "error");
            }
        }
    });
}
/*
点击保存时使用此方法可以关闭所有grid行编辑
*,并抓取所有发生变化的行 以json序列化方式提取
* 此方法极不稳定 应抓取所有数据,后台过滤并修改
*/
function get_json_sfy($grid) {
    try {
        /*
        此方法不可获得编辑信息,方法重写
        编辑功能已经实现
        判断klbde是否与当前版本值相同,弱不相同,则为变更
        */
        if (whetherchange == true) {//如果发生了变更
            var k_data = $grid.datagrid('getRows');
            var _rowsdata = [];
            for (var i = 0; i < k_data.length; i++) {
                if ($grid.attr('id') == 'klbde_ux_Grid') {
                    $grid.datagrid('endEdit', i);
                    if (($grid.datagrid('getRows')[i].rl08302 == null && $grid.datagrid('getRows')[i].rl08303 == null) || ($grid.datagrid('getRows')[i].rl08302 != null && $grid.datagrid('getRows')[i].rl08303 != null)) {
                        k_data[i].rl08319 = $grid.datagrid('getRows')[i].rl08301;
                        k_data[i].rl08301 = '';
                        k_data[i].rl08302 = '';
                        k_data[i].rl08303 = '';
                        k_data[i].rl08310 = '0';
                        k_data[i].rl08314 = '0';
                        if (k_data[i].rl08308 == '') {
                            k_data[i].rl08308 = '0';
                        }
                        if (k_data[i].rl08312 == '') {
                            k_data[i].rl08312 = '0';
                        }
                        _rowsdata.push(k_data[i]);
                        console.log(k_data[i]);
                    }
                }
                else if ($grid.attr('id') == 'aj_ux_Grid') {
                    $grid.datagrid('endEdit', i);
                    k_data[i].rl08401 = '';
                    k_data[i].rl08404 = '0';
                    k_data[i].rl08405 = '0';
                    k_data[i].rl08406 = '0';
                    k_data[i].rl08407 = '0';
                    k_data[i].rl08408 = '0';
                    k_data[i].rl08409 = '0';
                    k_data[i].rl08412 = '0';
                    k_data[i].rl08413 = '0';
                    _rowsdata.push(k_data[i]);
                }
                else if ($grid.attr('id') == '_special_notes_ux_grid') {
                    $grid.datagrid('endEdit', i);
                    $grid.datagrid('getRows')[i].rl08601 = '';
                }
                else {
                    $grid.datagrid('endEdit', i);
                }
            }
            console.log(_rowsdata);
            if (pd_json_sfy($grid, _rowsdata) == "-1") {
                return "-1";
            }
            return JSON.stringify(_rowsdata);
        } else {
            var k_l = $grid.datagrid('getRows').length;//获取所有行
            if (k_l > 0) {
                for (var i = 0; i < k_l; i++) {
                    if ($grid.attr('id') == 'klbde_ux_Grid') {
                        $grid.datagrid('endEdit', i);
                        if (($grid.datagrid('getRows')[i].rl08302 == null && $grid.datagrid('getRows')[i].rl08303 == null) || ($grid.datagrid('getRows')[i].rl08302 != null && $grid.datagrid('getRows')[i].rl08303 != null)  ) {
                            $grid.datagrid('getRows')[i].rl08302 = '';
                            $grid.datagrid('getRows')[i].rl08303 = '';
                            if ($grid.datagrid('getRows')[i].rl08308 == '') {
                                $grid.datagrid('getRows')[i].rl08308 = '0';
                            }
                            if ($grid.datagrid('getRows')[i].rl08312 == '') {
                                $grid.datagrid('getRows')[i].rl08312 = '0';
                            }
                            $grid.datagrid('getRows')[i].rl08310 = '0';
                            $grid.datagrid('getRows')[i].rl08314 = '0';
                        }
                    }
                    if ($grid.attr('id') == 'aj_ux_Grid') {
                        $grid.datagrid('endEdit', i);
                        $grid.datagrid('getRows')[i].rl08404 = '0';
                        $grid.datagrid('getRows')[i].rl08405 = '0';
                        $grid.datagrid('getRows')[i].rl08406 = '0';
                        $grid.datagrid('getRows')[i].rl08407 = '0';
                        $grid.datagrid('getRows')[i].rl08408 = '0';
                        $grid.datagrid('getRows')[i].rl08409 = '0';
                        $grid.datagrid('getRows')[i].rl08412 = '0';
                        $grid.datagrid('getRows')[i].rl08413 = '0';

                    }
                    if ($grid.attr('id') == '_special_notes_ux_grid') {
                        var s_l = $grid.datagrid('getData').total - 1;
                        $grid.datagrid('endEdit', s_l - i);
                    }
                    else {
                        $grid.datagrid('endEdit', i);
                    }
                }
                var _row_change = $grid.datagrid('getChanges');
                if (pd_json_sfy($grid, _row_change) == "-1") {
                    return "-1";
                }
                return JSON.stringify(_row_change);
            }
        }
    } catch (e) {
        console.log(e);
    }
}
function pd_json_sfy($grid, _row_change) {
    for (var i = 0; i < _row_change.length; i++) {
        if ($grid.attr("id") == "klbde_ux_Grid") {
            if (_row_change[i].rl08315 == "" || _row_change[i].rl08315 == null) {
                return "-1";
            }
        }
        if ($grid.attr("id") == "aj_ux_Grid") {
            console.log(_row_change);
            if (_row_change[i].rl08402 == "" || _row_change[i].rl08402 == null || _row_change[i].rl08410 == null || _row_change[i].rl08410 == "") {
                return "-1";
            }
        }
    }
}
/**
 * 实例化福建模块
 * 作番Id
 */
function sdpk007_ux_fun(zuofanid) {
    try {
        if (zuofanid) {
            window.sdpk007_ux_WinClass.Init(zuofanid, true);
            window.sdpk007_ux_WinClass.Load();
        }
        else {
            window.sdpk007_ux_WinClass.Init('-1', true);
            window.sdpk007_ux_WinClass.Load();
        }
    } catch (e) {
        console.log(e);
        window.sdpk007_ux_WinClass.Init('-1', true);
        window.sdpk007_ux_WinClass.Load();
    }
}
/**
 *
此处报错 需要修改 
/
 */
function klb_sum_ux_grid() {
    $("#_klb_sum_ux_grid table tr").each(function (i) {
        var $tr = $("#_klb_sum_ux_grid table tbody tr");
        var isnull_input = $tr.eq(i).find("td").eq(-2).find("input").eq(0).textbox("getValue");
        if (isnull_input == "") {
            $tr.eq(i).find("td").eq(-1).find("input").eq(0).textbox("setValue", "");
        }
    });
}
function special_notes_ux_grid() {
    var $grid = $('#_special_notes_ux_grid');
    $grid.datagrid({
        url: "/AreasCode030/sdbo003/SpecialNotes?zuofanid=" + zuofanid + "&version_number=" + _versioNnumber,
        method: 'POST',
        title: '特记事项',
        autoSave: true,
        fit: false,
        iconCls: 'icon-save',//图标  
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: true,
        idField: "rl08601",
        sortable: true,
        remoteSort: false,
        scrollbarSize: 0,
        pagePosition: 'bottom',
        onClickCell: function (rowIndex, field, record) {

        },

        toolbar: [
            {
                text: '添加',
                id: 's_add',
                iconCls: 'icon-add',
                handler: function () {
                    special_notes_ux_grid_appenrow();
                }
            }
            ,
            '-',
            {
                id: "s_remove",
                text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    var row = $grid.datagrid('getSelected');
                    var _voucherId = row.rl08601;
                    var rowIndex = $grid.datagrid('getRowIndex', row);
                    $grid.datagrid("deleteRow", rowIndex);
                    arry_evaluate(_voucherId, _s_n_ux_grid_del_id);
                }
            }
        ],
        columns: [[
            { field: 'rl08605', title: '事项', width: 150, editor: "text" },
            { field: 'rl08606', title: '文字说明', width: 150, editor: "text" },
            { field: 'rl08607', title: '数量', width: 150, editor: { type: 'numberbox', options: { precision: 1 } } },
            { field: 'rl08608', title: '单位', width: 150, editor: "text" }
        ]]
    });
    grid_edit_del($grid);
}
function grid_edit_del($grid) {
    $grid.datagrid({
        onDblClickRow: function (index, row) {
            if ($grid.selector == "#klbde_ux_Grid") {
                if (row.rl08304) {
                    $grid.datagrid('beginEdit', index);
                }
            }
            //else if ($grid.selector == '#aj_ux_Grid') {
            //    if (row.rl08404) {
            //        $grid.datagrid('beginEdit', index);
            //    }
            //}
            else {
                $grid.datagrid('beginEdit', index);
            }
        },
        onBeforeEdit: function (index, row) {
            var data = $grid.datagrid('getData').total;
            for (var i = 0; i < data; i++) {
                if (i != index) {
                    $grid.datagrid('endEdit', i);
                }
            }
        }
    });
}
//对数组进行判断性赋值{ a:id,b:数组}
function arry_evaluate(a, b) {
    if (a) {
        for (var i = 0; i < b.length; i++) {
            if (b[i] == a) {

            } else {
                b.push(a);
            }
        }
        if (b.length == 0) {
            b.push(a);
        }
    }
}
function special_notes_ux_grid_appenrow() {
    var t1 = ["敷地面積", "階数・建築高さ", "延床面積", "ダクト", "空調・衛生配管"];
    var t2 = ["m²", "m", "m²", "m²", "Ton"];
    //var t1 = ["空調・衛生配管", "ダクト", "延床面積", "階数・建築高さ", "敷地面積"];
    //var t2 = ["Ton", "m²", "m²", "m", "m²"];
    try {
        var $grid = $("#_special_notes_ux_grid");
        var grid_legth = $grid.datagrid('getData').total;
        grid_legth = isNaN(grid_legth) ? 0 : grid_legth;
        if (grid_legth < 9) {
            $grid.datagrid('insertRow', {
                index: grid_legth,
                row: {
                    rl08605: grid_legth > 4 ? "" : t1[grid_legth],
                    rl08606: "",
                    rl08607: "0",
                    rl08608: grid_legth > 4 ? "" : t2[grid_legth]
                }
            });
            $grid.datagrid('selectRow', grid_legth);
            $grid.datagrid('beginEdit', grid_legth);
            //   $('#aj_ux_Grid').datagrid('endEdit', getRowIndex(target));//保存
        }
    } catch (e) {
        console.log(e);
    }
    function saveLoadGrid($grid, index) {

    }
}



function schedulePlanning_select_Grid() {

}
/**************按钮控制*************************************start*************************/
$("#btnRecognize").linkbutton({
    onClick: function () {//承认
        $.ajax({
            // url: "/AreasCode030/sdbo003/Recognize&zuofanid=" + zuofanid + "&versionnumber=000000",
            url: "/AreasCode030/sdbo003/Recognize",
            data: {
                zuofanid: zuofanid,
                versionnumber: _versioNnumber,
                changeType: _changeType
            },
            type: "POST",
            success: function (obj) {
                var data = $.parseJSON(obj);
                if (data.success) {
                    $.messager.alert("友情提示", data.Message, "info");
                    SetInfo();
                    return false;
                }
                else {
                    $.messager.alert("友情提示", data.Message, "error");
                }
            }
        });
    }
});

$("#btnInsert").linkbutton({
    onClick: function () {//新增
        forbidden("disable");
        $("#btnSave").linkbutton('enable');
        textdatabox(false);
        btnGrid("enable");

    }
});
$("#btnUpdate").linkbutton({
    onClick: function () {//更新
        whetherchange = true; //发生了变更,修改此状态
        $("#rl08201").val("");//情况实行预算id 
        _save081 = "";
        $("#rl08501").val("");
        $("#btnUpdate").hide();
        $("#btnCorrection").show();
        $("#btnFinalize").show();
        $("#btnInternalCorrection").show();
        $("#btnInsert").hide();
        $("#btnModify").hide();
        $("#btnRemove").hide();
        $("#brnExcelExport").hide();
        linkbutton_enable("btnCorrection");
        linkbutton_enable("btnFinalize");
        linkbutton_enable("btnInternalCorrection");
        maketochange(true);
    }
});
$("#btnModify").linkbutton({
    onClick: function () {//编辑
        forbidden("disable");
        $("#btnSave").linkbutton('enable');
        textdatabox(false);
        btnGrid("enable");
        if (Number(_versioNnumber) == 0) {
            $("#_schedulePlanning_ux_Grid").find('tr').eq(1).find('td').find('input').each(function () {
                $(this).removeAttr("readonly");
            });
            $("#_schedulePlanning_ux_Grid").find('tr').eq(2).find('td').find('input').each(function () {
                $(this).removeAttr("readonly");
            });
        }
    }
});
$("#btnRemove").linkbutton({
    onClick: function () {//删除

        $.messager.confirm('确认', '您确认想要删除此次实行预算吗？', function (r) {
            if (r) {
                $.ajax({
                    url: "/AreasCode030/sdbo003/Remove",
                    type: "post",
                    data: {
                        zuofanid: zuofanid,
                        versionnumber: _versioNnumber
                    },
                    success: function (data) {
                        var obj = $.parseJSON(data);
                        if (obj.success) {
                            $.messager.alert('友情提示', obj.Message, 'info');
                            Init_com();
                            //SetInfo();

                            return false;
                        }
                        else {
                            $.messager.alert('友情提示', obj.Message, 'error');
                            return false;
                        }
                    }
                });
            }
        });



    }
});
//计划进度编辑按钮
$("#_schedulePlanning_ux_Grid_edit").linkbutton({
    onClick: function () {
        $("#_schedulePlanning_ux_Grid").find('tr').eq(2).find('td').find('input').each(function (i) {
            $(this).removeAttr("readonly");
        });
    }
});
//计划进度保存按钮
$("#_schedulePlanning_ux_Grid_save").linkbutton({
    onClick: function () {
        btn_saveSzrl085();
    }
});
//保存计划进度
function btn_saveSzrl085() {
    saveSzrl085();
    if (!save083_save084(_save084)) {
        $.messager.alert('友情提示', "実行出来高必须为100%!", 'error');//123
        return false;
    }
    $.ajax({
        url: "/AreasCode030/sdbo003/btn_saveSzrl085",
        post: "POST",
        data: {
            p1: zuofanid,
            p2: _versioNnumber,
            p3: _save082,
            p4: _save083,
            p5: _save084,
            p6: $("#rl08501").val(),
            p7: _changeType
        },
        success: function (obj) {
            var data = $.parseJSON(obj);
            if (data.success) {
                $.messager.alert("友情提示", data.Message, "info");
                SetInfo();
                return false;
            }
            else {
                $.messager.alert("友情提示", data.Message, "error");
                return false;
            }
        }
    });
}


$('#btnSave').linkbutton({
    onClick: function () {//保存
        var rl08206 = $("#rl08206").datebox('getValue');
        var rl08207 = $("#rl08207").datebox('getValue');
        var rl08208 = $("#rl08208").datebox('getValue');
        if (rl08206 == "") {
            $.messager.alert('友情提示', '请填写予算審議会開催日!', 'info');
            return false;
        }
        if (rl08207 == "") {
            $.messager.alert('友情提示', '请填写機材手配日!', 'info');
            return false;
        }
        if (rl08208 == "") {
            $.messager.alert('友情提示', '请填写着工予定日!', 'info');
            return false;
        }
        saveSzrl085();
        var _klbde_row_change = get_json_sfy($("#klbde_ux_Grid"));
        var _aj_row_change = get_json_sfy($("#aj_ux_Grid"));
        var _sg_row_change = get_json_sfy($("#_special_notes_ux_grid"));
        if (_klbde_row_change == "-1") {
            $.messager.alert('友情提示', "请选择KLBDE明细导入的单位!", 'error');//123
            return false;
        }
        if (_aj_row_change == "-1") {
            $.messager.alert('友情提示', "请正确填写A~J明细!", 'error');//123
            return false;
        }

        if (!save083_save084(_save083)) {
            $.messager.alert('友情提示', "請求出来高必须为100%!", 'error');//123
            return false;
        }
        if (!save083_save084(_save084)) {
            $.messager.alert('友情提示', "実行出来高必须为100%!", 'error');//123
            return false;
        }

        var _tx_save = Tx_save();//判断现在金额是否大于修改前金额
        if (_tx_save) {
            $.messager.confirm('确认对话框', '存在B类发包合同,是否继续保存？', function (r_1) {
                if (r_1) {
                    //$.messager.confirm('确认对话框', '您想要退出该系统吗？', function (r_2) {
                    //    if (r_2) {

                    //    }
                    //});
                    $('#_tx_Win').window('open');
                    $("#szrl019_ux_Grid").datagrid({
                        url: "/AreasCode030/sdbo003/GetSzrl019Info?zuofanid=" + zuofanid,
                        method: 'POST',
                        title: '关闭的营业合同',
                        fit: true,
                        iconCls: 'icon-save',//图标  
                        loadMsg: "正在加载，请稍等...",
                        fitColumns: true,
                        singleSelect: true,
                        idField: "rl01901",
                        sortable: true,
                        remoteSort: false,
                        rownumbers: true,
                        pagination: true,
                        scrollbarSize: 0,
                        pageSize: 10,
                        pageList: [10, 20, 30],//可以设置每页记录条数的列表  
                        pagePosition: 'bottom',
                        columns: [[
                            { field: 'rl01903', title: '合同名称' }
                        ]],
                        onDblClickRow: function (rowIndex, record) {
                            $.messager.confirm('确认对话框', '此合同已经关闭,是否打开？', function (r_3) {
                                if (r_3) {
                                    $.messager.alert('友情提示', "打开了!", 'info');
                                    return false;
                                }
                            });
                            _seRrecord = record;
                        },
                        onLoadSuccess: function (obj) {
                            var data = obj.rows;
                            if (data.length == 0) {

                                $.messager.confirm('确认对话框', '没有关闭的合同,是否继续保存？', function (r_4) {
                                    if (r_4) {
                                        refer(_klbde_row_change, _aj_row_change, _sg_row_change);
                                    }
                                    else {
                                        $('#_tx_Win').window('close');
                                        SetInfo();
                                        return false;
                                    }
                                });
                            }
                        }
                    });
                }
                else {
                    $('#_tx_Win').window('close');
                    Init_com();
                    SetInfo();
                    return false;
                }
            });
        } else {
            refer(_klbde_row_change, _aj_row_change, _sg_row_change);
        }
    }
});
function refer(_klbde_row_change, _aj_row_change, _sg_row_change) {
    $('#szrl082From').form('submit', {
        url: "/AreasCode030/sdbo003/Add",
        onSubmit: function (param) {
            //验证必填项是否为空
            param.p1 = _klbde_row_change;
            param.p2 = _aj_row_change;
            param.p3 = _save082;
            param.p4 = _save083;
            param.p5 = _save084;
            param.p6 = $("#rl08501").val();
            param.p7 = zuofanid;
            param.p8 = _sg_row_change;
            param.p9 = JSON.stringify(klbde_ux_Grid_del_id);
            param.p10 = JSON.stringify(aj_ux_Grid_del_id);
            param.p11 = JSON.stringify(_s_n_ux_grid_del_id);
            param.p12 = _versioNnumber;
            param.p13 = _changeType;
            param.p14 = $("#rl08235").val();
            param.p15 = $("#_kp").textbox("getValue");
            param.p16 = $("#rl08202").text();

        },
        success: function (data) {
            var obj = $.parseJSON(data);
            $('#_tx_Win').window('close');
            if (obj.success) {
                SetInfo();
                klbde_ux_Grid_del_id = new Array();
                aj_ux_Grid_del_id = new Array();
                _s_n_ux_grid_del_id = new Array();
                $.messager.alert('友情提示', "保存成功!", 'info');//123
                return false;
            } else {

                klbde_ux_Grid_del_id = new Array();
                aj_ux_Grid_del_id = new Array();
                _s_n_ux_grid_del_id = new Array();
                $.messager.alert('友情提示', obj.Message, 'error');
                SetInfo();
                return false;
            }
        }

    });
}
function Tx_save() {
    if (!IsNullOrEmpty(_changeType) && _changeType != "内部修正") {
        var _k_grid = $("#klbde_ux_Grid");
        var _k_obj = _k_grid.datagrid('getData');
        var _k_data = _k_obj.rows;
        var _k_sum_n = 0;//先在的klbde的总金额
        var _black = 0;//是否存在B类合同 存在+1
        for (var i = 0; i < _k_obj.total; i++) {
            if (_k_data[i].rl08302 != null) {
                if (_k_data[i].rl08302.indexOf("B") > -1) {
                    _black += 1;
                }
            }
            if (_k_data[i].rl08302 != null && _k_data[i].rl08303 != null) {
                _k_sum_n += (_k_data[i].rl08307) * (_k_data[i].rl08308);
                if (_k_data[i].rl08304.indexOf("B") > -1) {
                    _black += 1;
                }
            }
        }
        if (_k_sum_n > KLBDE_sum) {
            if (_black > 0) {
                return true;
            }
        }
        return false;
    }
}
function save083_save084(a) {
    if (a) {
        var save_arry = a.split(';');
        var _nan_100 = 0;
        for (var i = 0; i < save_arry.length - 1; i++) {
            _nan_100 = _nan_100 + Number(save_arry[i]);
        }
        if (_nan_100 == 100) {
            return true;
        }
    }
    return false;
}

$("#btnCancel").linkbutton({//取消
    onClick: function () {
        SetInfo();
        _versioNnumber = $("#versioNnumber").combo("getText");
        del_vn(_versioNnumber);
        //$('#versioNnumber').combobox('selectedIndex', $("#versioNnumber").length - 1);
        var val = $("#versioNnumber").combobox("getData");
        for (var item in val[0]) {
            if (item == "rl08203") {
                $("#versioNnumber").combobox("select", val[0][item]);
            }
        }


    }
});
$("#brnExcelExport").linkbutton({
    onClick: function () {
        window.location.href = "/AreasCode030/sdbo003/ExcelExport";
    }
});
//初始化按钮
function InitializationButton(_record) {
    Init_linkbutton();
    forbidden("disable");
    textdatabox(true);
    btnGrid("disable");
    if (_record.rl08201) {
        if (_record.rl08241 == 0) {
            linkbutton_enable('btnRemove');
            linkbutton_enable('btnModify');
            linkbutton_enable('btnRecognize');
        }
        else {
            linkbutton_enable('btnUpdate');
        }
        linkbutton_enable('brnExcelExport');
    }
    else {
        linkbutton_enable('btnInsert');
    }
}
//禁用和启用所有按钮
function forbidden(a) {
    $("#btnRecognize").linkbutton(a);
    $("#btnInsert").linkbutton(a);
    $("#btnModify").linkbutton(a);
    $("#btnRemove").linkbutton(a);
    $("#btnSave").linkbutton(a);
    $("#btnRecognize").linkbutton(a);
    $("#btnCancel").linkbutton(a);
    $("#brnExcelExport").linkbutton(a);
    $("#btnPrint").linkbutton(a);
    $("#btnUpdate").linkbutton(a);
}
//对textbox 和databox进行全区禁用与启用
function textdatabox(a) {
    $("[for-edit='textbox']").each(function (i) {
        $("[for-edit='textbox']").eq(i).textbox('readonly', a);
    });
    $("[for-edit='datebox']").each(function (i) {
        $("[for-edit='datebox']").eq(i).combo('readonly', a);
    });
}
//Grid上面的按钮禁用与启用
function btnGrid(a) {
    $("#k_add").linkbutton(a);
    $("#k_remove").linkbutton(a);
    $("#k_import").linkbutton(a);
    $("#a_add").linkbutton(a);
    $("#a_remove").linkbutton(a);
    $("#a_import").linkbutton(a);
    $("#s_add").linkbutton(a);
    $("#s_remove").linkbutton(a);
    cannotModifiedWhileUpdating();

}
function cannotModifiedWhileUpdating() {
    if (Number(_versioNnumber) > 0) {
        $("#k_import").linkbutton("disable");
        $("#k_remove").linkbutton("disable");
        $("#a_remove").linkbutton("disable");
        $("#a_import").linkbutton("disable");
    } 
}



//点击 订正 改定 内部修正 时触发
// 文本编辑权限未做控制

//订正
$("#btnCorrection").linkbutton({
    onClick: function () {
        linkbutton_disable("btnCorrection");
        linkbutton_disable("btnFinalize");
        linkbutton_disable("btnInternalCorrection");
        linkbutton_enable("btnSave");
        linkbutton_enable("btnCancel");
        versioNnumber_combo = true;
        _versioNnumber = $("#versioNnumber").combo("getText");
        var _now_vn = Number(_versioNnumber.substring(0, 2)) + 1;
        //_versioNnumber = pad(_now_vn, 2) + _versioNnumber.substring(2, 4) + _versioNnumber.substring(4, 6);//版本号
        _versioNnumber = pad(_now_vn, 2) + _versioNnumber.substring(2, 4) + "00";//版本号
        _changeType = "订正";//变更类型
        append_vn(_versioNnumber);
        $("#changePropert").text("订正");
        setTimeout(function () {
            linkbutton_disable("btnCorrection");
            linkbutton_disable("btnFinalize");
            linkbutton_disable("btnInternalCorrection");
            linkbutton_enable("btnSave");
            linkbutton_enable("btnCancel");
            disLoad();
        }, 2300);
        partial_1();
        textdatabox(false);
        partial_4();
        //$("#_009").text(_versioNnumber.substring(0, 2));

        /*
        *权限
        */
    }
});
//改定
$("#btnFinalize").linkbutton({
    onClick: function () {
        linkbutton_disable("btnCorrection");
        linkbutton_disable("btnFinalize");
        linkbutton_disable("btnInternalCorrection");
        linkbutton_enable("btnSave");
        linkbutton_enable("btnCancel");
        versioNnumber_combo = true;
        _versioNnumber = $("#versioNnumber").combo("getText");
        var _now_vn = Number(_versioNnumber.substring(2, 4)) + 1;
        //_versioNnumber = _versioNnumber.substring(0, 2) + pad(_now_vn, 2) + _versioNnumber.substring(4, 6);
        _versioNnumber = _versioNnumber.substring(0, 2) + pad(_now_vn, 2) + "00";
        _changeType = "改定";//变更类型
        append_vn(_versioNnumber);

        $("#changePropert").text("改定");
        setTimeout(function () {
            linkbutton_disable("btnCorrection");
            linkbutton_disable("btnFinalize");
            linkbutton_disable("btnInternalCorrection");
            linkbutton_enable("btnSave");
            linkbutton_enable("btnCancel");
            disLoad();
        }, 2300);
        partial_1();
        textdatabox(false);
        partial_4();

    }
});
//内部修正
$("#btnInternalCorrection").linkbutton({
    onClick: function () {
        linkbutton_disable("btnCorrection");
        linkbutton_disable("btnFinalize");
        linkbutton_disable("btnInternalCorrection");
        linkbutton_enable("btnSave");
        linkbutton_enable("btnCancel");
        load();
        versioNnumber_combo = true;
        _versioNnumber = $("#versioNnumber").combo("getText");
        var _now_vn = Number(_versioNnumber.substring(4, 6)) + 1;
        _versioNnumber = _versioNnumber.substring(0, 2) + _versioNnumber.substring(2, 4) + pad(_now_vn, 2);
        _changeType = "内部修正";//变更类型
        append_vn(_versioNnumber);
        setTimeout(function () {
            linkbutton_enable("btnSave");
            linkbutton_enable("btnCancel");
            disLoad();
        }, 2300);
        $("#changePropert").text("内部修正");
        partial_1();
        // partial_4();
        /*
        内部修正 那些可以编辑
        */
        InternalCorrection(false);
        disLoad();
    }
});
//点击内部修正   a: true or false ;              是否可编辑 enable disable
function InternalCorrection(a) {
    var _key = "disable";
    if (a == false) {
        _key = "enable";
    }
    $("#k_add").linkbutton(_key);
    $("#a_add").linkbutton(_key);
    $("#s_add").linkbutton(_key);
}
function FinalizeSchedule() {
    var _s_1 = $("#rl08219").val();
    var _s_2 = $("#_pv_rl08219").text();
    if (_s_1 == _s_2) {
        linkbutton_disable("btnSave");
        $.messager.alert('友情提示', "受注金额未发生变化,不可做订正!", 'error');
    }
    else {
        /*修改计划进度百分比*/
        var $tds_rl08503 = $("#_schedulePlanning_ux_Grid").find('tr').eq(1).find('td').find('input');
        var $tds_rl08504 = $("#_schedulePlanning_ux_Grid").find('tr').eq(2).find('td').find('input');
        $($tds_rl08503).each(function (i) {
            if ($(this).val() != undefined) {
                $(this).val(($(this).val() * (_s_1 / _s_2)).toFixed(2));
            }
        });
        $($tds_rl08503).each(function (i) {
            if ($(this).val() != undefined) {
                $(this).val(($(this).val() * (_s_1 / _s_2)).toFixed(2));
            }
        });
    }

}

//补全字符串
function pad(num, n) {
    return Array((n - ('' + num).length + 1)).join(0) + num;
}
function append_vn(a) {
    $('#versioNnumber').combobox('appendRow', {
        "value": a,
        "rl08203": a,
        "group": "",
        "selected": true
    });
}
function del_vn(a) {
    $('#versioNnumber').combobox('deleteRow', a);
}
function linkbutton_enable(a) {
    $("#" + a + "").linkbutton("enable");
}
function linkbutton_disable(a) {
    $("#" + a + "").linkbutton("disable");
}
function Init_linkbutton() {
    $("#btnCorrection").hide();
    $("#btnFinalize").hide();
    $("#btnInternalCorrection").hide();
    $("#btnUpdate").show();
    $("#btnInsert").show();
    $("#btnModify").show();
    $("#btnRemove").show();
    $("#brnExcelExport").show();
}








/**************按钮控制*************************************end*************************/


function klbde_import_appenrow(_row) {
    console.log(_row);
    $('#klbde_ux_Grid').datagrid('insertRow', {
        index: 0,
        row: {
            rl08302: _row.rl08302,
            rl08303: _row.rl08303,
            rl08304: _row.rl08304,
            rl08305: _row.rl08305,
            rl08306: _row.rl08306,
            rl08307: _row.rl08307,
            rl08308: _row.rl08308,
            rl08309: _row.rl08309,
            rl08310: _row.rl08310,
            rl08311: _row.rl08311,
            rl08312: _row.rl08312,
            rl08313: _row.rl08313,
            rl08314: _row.rl08314,
            rl08315: _row.rl08315
        }
    });
    //$('#klbde_ux_Grid').datagrid('selectRow', 0);
    // $('#klbde_ux_Grid').datagrid('beginEdit', 0);
}

function aj_import_appenrow(_row) {
    $('#aj_ux_Grid').datagrid('insertRow', {
        index: 0,
        row: {
            rl08402: _row.rl08402,
            rl08403: '',
            rl08410: _row.rl08410,
            rl08411: '0',
            rl08414: _row.rl08414
        }
    });
    //$('#klbde_ux_Grid').datagrid('selectRow', 0);
    // $('#klbde_ux_Grid').datagrid('beginEdit', 0);
}

function Init_com() {
    $('#versioNnumber').combobox({
        url: '/AreasCode030/sdbo003/VersioNnumber?zuofanid=' + zuofanid,
        valueField: 'rl08203',
        textField: 'rl08203',
        onLoadSuccess: function () {  //加载完成后,设置选中第一项  
            var val = $(this).combobox("getData");
            for (var item in val[0]) {
                if (item == "rl08203") {
                    $(this).combobox("select", val[0][item]);
                }
            }
            _versioNnumber = $('#versioNnumber').combobox("getValue");
        },
        onChange: function (newValue, oldValue) {
            load();
            _versioNnumber = newValue;
            if (versioNnumber_combo == false) {
                SetInfo();
            }
            versioNnumber_combo = false;
            if (newValue != $(this).combobox("getData")[0].rl08203) {
                setTimeout(function () {
                    load();
                    linkbutton_disable("btnUpdate");
                    linkbutton_disable("btnRecognize");
                    linkbutton_disable("btnInsert");
                    linkbutton_disable("btnModify");
                    linkbutton_disable("btnRemove");
                    linkbutton_disable("btnSave");
                    linkbutton_disable("btnCancel");
                    linkbutton_disable("brnExcelExport");
                    disLoad();
                }, 2000);
            }
            disLoad();
        }
    });

}
//点击变更,带for='conceal'标签是否显示和隐藏
function maketochange(a) {
    $("[for='conceal']").each(function (i) {
        if (a) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });
}
//表纸显示訂正改定内部修正
function partial_1() {
    _versioNnumber = $("#versioNnumber").combo("getText");
    $("#_009").text(_versioNnumber.substring(0, 2));
    $("#_010").text(_versioNnumber.substring(2, 4));
    $("#_011").text(_versioNnumber.substring(4, 6));
}
function partial_3() {
    $('#rl08206').combo('readonly', false);
    $("#rl08207").combo('readonly', false);
    $('#rl08208').combo('readonly', false);
}
//分页4变更
function partial_4() {
    //获取最新版本的传票 给予赋值


    var fn_data = [];
    $.ajax({
        url: '/AreasCode030/sdbo003/Get_partial?zuofanid=' + zuofanid,
        type: "POST",
        success: function (data) {
            fn_data.push(data);

            $("#_pv_rl08214").text($("#rl08214").textbox("getText"));
            $("#_pv_rl08215").text($("#rl08215").textbox("getText"));
            $("#_pv_rl08213").text($("#rl01813").textbox("getText"));
            $("#_pv_rl08216").text($("#rl08216").textbox("getText"));
            $("#_pv_rl08217").text($("#rl08217").textbox("getText"));
            $("#_pv_rl08218").text($("#rl08218").textbox("getText"));
            $("#_pv_rl08219").text($("#rl08219").textbox("getText"));
            $("#_pv_rl08220").text($("#rl08220").textbox("getText"));
            $("#_pv_rl08221").text($("#rl08221").textbox("getText"));
            $("#_pv_rl08222").text($("#rl08222").textbox("getText"));
            $("#_pv_rl08223").text($("#rl08223").textbox("getText"));
            $("#_pv_rl08224").text($("#rl08224").textbox("getText"));
            partial_4_clear_2();
            if (fn_data.length > 0) {
                console.log("1");
                $("#rl08214").textbox("setValue", "0");
                $("#rl08215").textbox("setValue", "0");
                $("#rl01813").textbox("setValue", fn_data[0].rl01813);
                $("#rl08216").textbox("setValue", "0");
                $("#rl08217").textbox("setValue", fn_data[0].rl08217);
                $("#rl08218").textbox("setValue", fn_data[0].rl08218);
                $("#rl08219").textbox("setValue", fn_data[0].rl08219);
                $("#rl08220").textbox("setValue", "");
                $("#rl08221").textbox("setValue", "");
                $("#rl08222").textbox("setValue", "");
                $("#rl08223").textbox("setValue", "");
                $("#rl08224").textbox("setValue", "");
            }
            $('#rl08214').textbox('readonly', false);
            $('#rl08215').textbox('readonly', false);
            $('#rl08216').textbox('readonly', false);
        }
    });
}
function partial_4_clear() {
    $("#_pv_rl08214").text("");
    $("#_pv_rl08215").text("");
    $("#_pv_rl08213").text("");
    $("#_pv_rl08216").text("");
    $("#_pv_rl08217").text("");
    $("#_pv_rl08218").text("");
    $("#_pv_rl08219").text("");
    $("#_pv_rl08220").text("");
    $("#_pv_rl08221").text("");
    $("#_pv_rl08222").text("");
    $("#_pv_rl08223").text("");
    $("#_pv_rl08224").text("");
}


function partial_4_clear_2() {
    $("#rl08214").textbox("setValue", "");
    $("#rl08215").textbox("setValue", "");
    $("#rl01813").textbox("setValue", "");
    $("#rl08216").textbox("setValue", "0");
    $("#rl08217").textbox("setValue", "");
    $("#rl08218").textbox("setValue", "");
    $("#rl08219").textbox("setValue", "");
    $("#rl08220").textbox("setValue", "");
    $("#rl08221").textbox("setValue", "");
    $("#rl08222").textbox("setValue", "");
    $("#rl08223").textbox("setValue", "");
    $("#rl08224").textbox("setValue", "");
}
function partial_5() {
    $('.rl08227')
}
//变更后是否可编辑
function change_authority() {
    $("#rl08214").textbox('readonly', a);
    $("#rl08215").textbox('readonly', a);
    $("#rl01813").textbox('readonly', a);
    $("#rl08216").textbox('readonly', a);
    $("#rl08217").textbox('readonly', a);
    $("#rl08218").textbox('readonly', a);
    $("#rl08219").textbox('readonly', a);
    $("#rl08220").textbox('readonly', a);
    $("#rl08221").textbox('readonly', a);
    $("#rl08222").textbox('readonly', a);
    $("#rl08223").textbox('readonly', a);
    $("#rl08224").textbox('readonly', a);
}
//string转数字,不成功返回原值
function checkRate(val) {
    try {
        var re = /^[0-9]+.?[0-9]*$/;
        if (!re.test(val)) {
            return val;
        }
        return Number(val).toFixed(2);
    } catch (e) {
        console.log(e);
        return val;
    }
}
//判断是否为空
function IsNullOrEmpty(val) {
    try {
        if (val == null || val == "" || val == undefined) {
            return true;
        }
        return false;
    } catch (e) {
        console.log(e);
        return true;
    }
}



//弹出加载层
function load() {
    $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
    $("<div class=\"datagrid-mask-msg\"></div>").html("正在加载，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
}
//取消加载层  
function disLoad() {
    $(".datagrid-mask").remove();
    $(".datagrid-mask-msg").remove();
}

function progress() {
    var win = $.messager.progress({
        title: 'Please waiting',
        msg: 'Loading data...'
    });
    setTimeout(function () {
        $.messager.progress('close');
    }, 5000)
}