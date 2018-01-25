﻿var zuofanid = $("#rl02501").val();
var updateCountFirst = $("#rl02503").val();//当前版本更新次数
var staite = null;
var versionNumber = null;//版本号  用于实行预算穿透受注传票



function showcontent(language) {
    $('#content').html('Introduction to ' + language + ' language');
}
$(function () {
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
        },
        onClick: function (node) {
            $("#BtnGroup a").linkbutton('disable');
            $(this).tree('expand', node.target);
            if (node.attributes) {
                var nodemessage = node.attributes.nodeType;//获取作番号
                if (nodemessage != "szrl001" && nodemessage != "szrl004") {
                    nodemessageid = nodemessage;
                    SetInfo(nodemessageid);
                    otherstbs("disable");
                }
            }
        },
        onCollapse: function (node) {
            $(this).tree('collapseAll', node.target);
        }
    });
}




function otherstbs(swicth) {
    setTimeout(function () {
        if (swicth == "disable") {
            $('#icon_add').linkbutton("disable");
            $('#icon_remove').linkbutton("disable");
            window.sdpk007_ux_WinClass.Init(zuofanid, false);
        }
        else {
            $('#icon_add').linkbutton("enable");
            $('#icon_remove').linkbutton("enable");
            window.sdpk007_ux_WinClass.Init(zuofanid, true);
        }
    }, 1000);

}

function SetInfo(nodemessageid) {
    if (nodemessageid) {

        $('#szrl025From').form({

            onLoadSuccess: function (_record) {
                GetInfoData(_record);
            },
            onLoadError: function () {
                //PaperSheet
            }
        });
        var _url = "/AreasCode030/szrl025/GetIndexInfo/" + nodemessageid;
        $('#szrl025From').form('load', _url);
    }
}




function GetInfoData(_record) {
    var data = _record.Pamrms;
    zuofanid = _record.rl02501;
    if (zuofanid) {
        window.sdpk007_ux_WinClass.Init(zuofanid, true);
        window.sdpk007_ux_WinClass.Load();
    }
    else {
        window.sdpk007_ux_WinClass.Init('-1', true);
        window.sdpk007_ux_WinClass.Load();
    }
    $("#rl01806").text(data.szrl018.rl01806);//作番编号
    if (_record.rl02505 == 0) {
        $('.rl02505').eq(0).attr('checked', 'checked');
    }
    else {
        $('.rl02505').eq(1).attr('checked', 'checked');
    }
    if (_record.rl02506 == 0) {
        $('.rl02506').eq(0).attr('checked', 'checked');
    }
    else {
        $('.rl02506').eq(1).attr('checked', 'checked');
    }
    $("#rl01807").text(data.szrl018.rl01807);
    $("#rl02508").text(_record.rl02508);
    $("#rl01811").text(data.szrl018.rl01811);
    $("#rl01835").text(data.szrl018.rl01835 + "%");
    $("#rl01813").text(data.szrl018.rl01813);
    $("#rl01802").text(data.szrl018.rl01802);
    $("#rl01807").text(data.szrl018.rl01807);
    $("#rl02521").text(Number(_record.rl02521).toFixed(2));
    $("#z1821").text(Number(_record.rl02521 * data.szrl018.rl01835 / 100).toFixed(2));
    $("#rl02524").text(Number(_record.rl02524).toFixed(2));
    $("#rl02522").text(Number(_record.rl02522).toFixed(2));
    $("#z1922").text(Number(_record.rl02522 * data.szrl018.rl01835 / 100).toFixed(2));
    $("#rl02525").text(Number(_record.rl02525).toFixed(2));
    $("#rl02523").text(Number(_record.rl02523).toFixed(2));
    $("#z2023").text(Number(_record.rl02523 * data.szrl018.rl01835 / 100).toFixed(2));
    $("#rl02526").text(Number(_record.rl02526).toFixed(2));
    var rl02535 = _record.rl02535;
    if (!rl02535) {
        //作番下查询无信息 所有按钮禁用 只可点击新增
        // $("#tb1 input").attr("disabled", true);
        $("#BtnGroup a").linkbutton('disable');
        $("input").attr("disabled", true);
        $("#btnInsert").linkbutton('enable');

    }
    else {
        $("input").attr("disabled", true);
        $("#BtnGroup a").linkbutton('disable');
        if (_record.rl02532 == 0) {
            //未审核
            $("#btnRecognize").linkbutton('enable');
            $("#btnModify").linkbutton('enable');
            $("#btnRemove").linkbutton('enable');
            $("#btnExcel").linkbutton('enable');
            $("#btnPrint").linkbutton('enable');

        }
        if (_record.rl02532 == 1) {
            //已审核
            $("#btnUpdate").linkbutton('enable');
            $("#btnExcel").linkbutton('enable');
            $("#btnPrint").linkbutton('enable');

        }
    }
    szrl026dg();
    $("#tb1 td input").attr("disabled", true);
    $("#ct1").text(data.szrl018.rl01802);
    $("#ct2").text(data.szrl018.rl01806);
    $("#ct3").text(_record.rl02511);
    $("#ct4").text(data.szrl018.rl01835 + "%");
    $(".rl02505").attr("disabled", true);
    $('#rl02527').textbox('textbox').attr('readonly', true);
    $('#rl02511').combo('readonly');
   // $('#rl02502').switchbutton('disable');
    $('#rl02502').combo('readonly', true);
}


$(function () {
    $(".textright").each(function () {
        var tdnum = $(this).text();
        if (!isNaN(tdnum) && tdnum) {
            var tdnewnum = toThousands(tdnum);
            $(this).text(tdnewnum);
        }
    });
    otherstbs("disable");
    $("#BtnGroup a").linkbutton('disable');
});
//金钱加千位符
function toThousands(num) {
    return (num || 0).toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1,');
}

//点击更新,修改版本次数
function UpdateCount() {
    if (updateCountFirst == "初回") {
        updateCountFirst = "0";
    }
    var updateCount = Number(updateCountFirst) + 1;
    updateCount = PrefixInteger(updateCount, 3);
    var dtnow = nowtime();
    $('#rl02503').textbox('setValue', updateCount);
    $('#rl02504').textbox('setValue', dtnow);
}
//自动补数
function PrefixInteger(num, length) {
    return (Array(length).join('0') + num).slice(-length);
}
//获取当前日期  yyyy-mm-dd
function nowtime() {

    var now = new Date()
    y = now.getFullYear()
    m = now.getMonth() + 1
    d = now.getDate()
    m = m < 10 ? "0" + m : m
    d = d < 10 ? "0" + d : d
    return y + "-" + m + "-" + d
}


$(function () {
    SetPro();
});
function SetPro() {
    var value = $('.easyui-progressbar').progressbar('getValue');
    if (value < 100) {
        value += Math.floor(value + 10);
        $('.easyui-progressbar').progressbar('setValue', value).delay(1000);
    }
}




//#region 按钮控制
$('#btnUpdate').linkbutton({
    onClick: function () {
        if (!zuofanid) {
            $.messager.alert('友情提示', '请选择作番!', 'error');
            return false;
        }
        if (updateCountFirst == "初回") {
            return false;
        }
        updateCountFirst = $("#rl02503").val();//当前版本更新次数
        UpdateCount();
        var nowdate = nowtime();
        $("#rl02504_2").text(nowdate);
        $("#rl02504").val(nowdate);
        document.getElementsByName("rl02505")[1].checked = "checked";
        $("input").attr("disabled", false);
        $("#BtnGroup a").linkbutton('disable');
        $("#btnSave").linkbutton('enable');
        $("#btnExcel").linkbutton('enable');
        $("#btnPrint").linkbutton('enable');
        $("#tb1 td input").attr("disabled", true);
        $('#rl02527').textbox('textbox').attr('readonly', false);
        $('#rl02511').combo('readonly', false);
       // $('#rl02502').switchbutton('enable');
        //$('#rl02502').combo('readonly', false);


        //$('#tt').tabs('enableTab', 1);
        //$('#tt').tabs('enableTab', 2);
        otherstbs("enable");
        staite = "更新";
        $("#rl02503").textbox({ disabled: true });
        $("#rl02504").textbox({ disabled: true });
        $("#rl02509").textbox({ disabled: true });
        $('input:radio[name="rl02505"]').prop('disabled', true);
        //$('#rl02502').switchbutton('disable');
        $('#rl02502').combo('readonly', true);
    }
});

$('#btnRecognize').linkbutton({
    onClick: function () {
        $("input").attr("disabled", false);
        $('#rl02527').textbox('textbox').attr('readonly', false);
        $('#rl02511').combo('readonly', false);
       // $('#rl02502').switchbutton('enable');
        $('#rl02502').combo('readonly', false);
        //ajax 修改审核状态
        fn_btnRecognize();

    }
});
$('#btnInsert').linkbutton({
    onClick: function () {
        $("input").attr("disabled", false);
        $("#BtnGroup a").linkbutton('disable');
        $("#btnSave").linkbutton('enable');
        $("#btnExcel").linkbutton('enable');
        $("#btnPrint").linkbutton('enable');
        $("#tb1 td input").attr("disabled", true);
        $('#rl02527').textbox('textbox').attr('readonly', false);
        $('#rl02511').combo('readonly', false);
       // $('#rl02502').switchbutton('enable');
        $('#rl02502').combo('readonly', false);
        //$('#tt').tabs('enableTab', 1);
        //$('#tt').tabs('enableTab', 2);
        otherstbs("enable");
        $("#rl02503").textbox({ disabled: true });
        $("#rl02504").textbox({ disabled: true });
        $('input:radio[name="rl02505"]').prop('disabled', true);
    }
});
$('#btnModify').linkbutton({
    onClick: function () {
        $("input").attr("disabled", false);
        $("#BtnGroup a").linkbutton('disable');
        $("#tb1 td input").attr("disabled", true);
        $('#rl02527').textbox('textbox').attr('readonly', false);
        $('#rl02511').combo('readonly', false);
       // $('#rl02502').switchbutton('enable');
        $('#rl02502').combo('readonly', false);
        $("#btnSave").linkbutton('enable');
        $("#btnExcel").linkbutton('enable');
        $("#btnPrint").linkbutton('enable');
        //$('#tt').tabs('enableTab', 1);
        //$('#tt').tabs('enableTab', 2);
        otherstbs("enable");
        $("#rl02503").textbox({ disabled: true });
        $("#rl02504").textbox({ disabled: true });
        $('input:radio[name="rl02505"]').prop('disabled', true);
    }
});
$('#btnRemove').linkbutton({
    onClick: function () {
        $.messager.confirm('确认', '您确认想要删除此次受注传票吗？', function (r) {
            if (r) {
                $.ajax({
                    url: "/AreasCode030/szrl025/Remove",
                    type: "post",
                    data: {
                        Forsomenum: zuofanid
                    },
                    success: function (data) {
                        var obj = $.parseJSON(data);
                        if (obj.success) {
                            $.messager.alert('友情提示', obj.Message, 'info');
                            SetInfo(zuofanid);
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

$('#btnSave').linkbutton({
    onClick: function () {
        $("input").attr("disabled", false);
        $("#BtnGroup a").linkbutton('disable');
        $("#btnRecognize").linkbutton('enable');
        $("#btnModify").linkbutton('enable');
        $("#btnExcel").linkbutton('enable');
        $("#btnPrint").linkbutton('enable');
        $('#rl02527').textbox('textbox').attr('readonly', false);
        $('#rl02511').combo('readonly', false);
        //$('#rl02502').switchbutton('enable');
        $('#rl02502').combo('readonly', false);
        $("#rl02503").textbox({ disabled: false });
        $("#rl02504").textbox({ disabled: false });
        $('input:radio[name="rl02505"]').prop('disabled', false);


        $('#szrl025From').form('submit', {
            url: "/AreasCode030/szrl025/Add",
            onSubmit: function (_param) {
                //附加不可抓取的参数
                _param.rl02508 = $("#rl02508").text();
                _param.rl02521 = $("#rl02521").text();
                _param.rl02522 = $("#rl02522").text();
                _param.rl02523 = $("#rl02523").text();
                _param.rl02524 = $("#rl02524").text();
                _param.rl02525 = $("#rl02525").text();
                _param.rl02526 = $("#rl02526").text();
                _param.rl02527 = $("#rl02527").text();
                var isValid = $(this).form('validate');
                if (!isValid) {
                    $.messager.alert('友情提示', '请填写必填选项!', 'info');
                }
                return isValid;
            },
            success: function (data) {
                $.messager.progress('close');
                var obj = $.parseJSON(data);
                if (obj.success) {
                    $.messager.alert('友情提示', '保存成功!', 'info');
                    if (updateCountFirst == "初回") {
                        updateCountFirst = 0;
                    }
                    updateCountFirst = Number(updateCountFirst) + 1;
                    SetInfo(zuofanid);
                    setTimeout(function () {
                        $("#BtnGroup a").linkbutton('disable');
                        $("#btnRecognize").linkbutton('enable');
                        $("#btnModify").linkbutton('enable');
                        $("#btnExcel").linkbutton('enable');
                        $("#btnPrint").linkbutton('enable');
                        $("#btnRemove").linkbutton('enable');
                    }, 1200);
                } else {
                    $.messager.alert('友情提示', obj.Message, 'error');

                    SetInfo(zuofanid);
                    setTimeout(function () {
                        //$('#tt').tabs('disableTab', 1);
                        //$('#tt').tabs('disableTab', 2);
                        otherstbs("disable");
                    }, 1000);
                }

            }
        });
    }
});





//#endregion

function fn_btnRecognize() {
    $('#szrl025From').form('submit', {
        url: "/AreasCode030/szrl025/Recognize",
        onSubmit: function (_param) {
            if (!zuofanid) {
                $.messager.alert('友情提示', '请选择作番!', 'error');
                return false;
            }
        },
        success: function (data) {
            var obj = $.parseJSON(data);
            if (obj.success) {
                $.messager.alert('友情提示', '已承认!', 'info');
                if (updateCountFirst == "初回") {
                    updateCountFirst = 0;
                }
                updateCountFirst = Number(updateCountFirst) + 1;


                $("input").attr("disabled", true);
                $("#BtnGroup a").linkbutton('disable');
                $("#btnUpdate").linkbutton('enable');
                $("#btnExcel").linkbutton('enable');
                $("#btnPrint").linkbutton('enable');
                $('#rl02527').textbox('textbox').attr('readonly', true);
                $('#rl02511').combo('readonly');
               // $('#rl02502').switchbutton('disable');
                $('#rl02502').combo('readonly', true);
                otherstbs("disable");
            } else {
                $.messager.alert('友情提示', obj.Message, 'error');
            }
        }
    });
}


/*   详情*/
$('#szrl026Win').window({
    width: 900,
    height: 600,
    modal: true
});




function openTopWindow() {
    if (!zuofanid) {
        $.messager.alert('友情提示', "请选择作番", 'error');
        return false;
    }
    $('#szrl026Win').window('open');  // open a window   
    szrl019dg(0);
}

var szrl026dg = function () {
    var zfid = $("#rl02501").val();
    $("#szrl026_ux_Grid").datagrid({
        url: "/AreasCode030/szrl025/Selectdg?rl02501=" + zuofanid + "&versionNumber=" + versionNumber,
        //data: {
        //    rl02501: zuofanid
        //},
        method: 'POST',
        title: '受注传票明细',
        fit: false,
        iconCls: 'icon-save',//图标  
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: true,
        idField: "VoucheId",
        sortable: true,
        remoteSort: false,
        //pagination: true,
        //rownumbers: true,
        scrollbarSize: 0,
        //pageSize: 10,
        //pageList: [10, 20, 30],//可以设置每页记录条数的列表  
        pagePosition: 'bottom',
        toolbar: [
            {
                id: "icon_add",
                text: '添加',
                iconCls: 'icon-add',
                handler: function () {
                    openTopWindow();

                }
            }
            ,
            '-',
            {
                id: "icon_remove",
                text: '删除',
                iconCls: 'icon-remove',
                handler: function () {
                    var row = $('#szrl026_ux_Grid').datagrid('getSelected');
                    var _voucherId = row.VoucheId;
                    var _circulationNumber = row.CirculationNumber;
                    DeleteVoucher(_voucherId, _circulationNumber);
                }
            }
        ],
        columns: [[
            { field: 'NumberId', title: '序号', width: 150 },
            { field: 'IsChange', title: '是否变更', width: 150 },
            { field: 'ContractSerialNum', title: '合同序列号', width: 150, align: 'left' },
            { field: 'ContractAmount', title: '合同金额', width: 150, align: 'left' },
            { field: 'AllocationAmount', title: '手配金额', width: 150, align: 'left' },
            { field: 'TaxFreeMoney', title: '不含税金额', width: 150 },
            { field: 'Tax', title: '税额', width: 150, align: 'left' },
            { field: 'ContractNumber', title: '合同书编号', width: 150, align: 'left' },
            { field: 'ContractName', title: '合同名称', width: 150, align: 'left' },
            { field: 'ContractDate', title: '合同书签订日', width: 150 },
            { field: 'DateDelivery', title: '交货期', width: 150, align: 'left' },
            { field: 'CirculationNumber', title: '发行回数', width: 150, align: 'left' },
            { field: 'DateIssue', title: '発行日', width: 150, align: 'left' },
            { field: 'BudgetState', title: '预算状态', width: 150, align: 'left' }
        ]]
    });
}



function DeleteVoucher(_voucherId, _circulationNumber) {
    $.ajax({
        url: "/AreasCode030/szrl025/DeleteVoucher",
        data: {
            VoucherId: _voucherId,
            CirculationNumber: _circulationNumber
        },
        type: "post",
        success: function (obj) {
            var data = $.parseJSON(obj);
            if (data.success) {
                $.messager.alert('友情提示', "删除成功!", 'info');
                $('#szrl026_ux_Grid').datagrid('reload');
            }
            else {
                $.messager.alert('友情提示', data.Message, 'error');
            }
        }
    });
}









var _seRrecord = null;
var szrl019dg = function (isChange) {
    $("#szrl019_ux_Grid").datagrid({
        url: "/AreasCode030/szrl025/SelectContract?rl02501=" + zuofanid + "&isChange=" + isChange,
        method: 'POST',
        title: '营业合同',
        fit: false,
        iconCls: 'icon-save',//图标  
        loadMsg: "正在加载，请稍等...",
        fitColumns: true,
        singleSelect: true,
        idField: "VoucheId",
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
                text: '保存',
                iconCls: 'icon-save',
                handler: function () {
                    SaveVoucher();
                }
            }
        ],
        columns: [[
            { field: 'IsChange', title: '是否变更', width: 150 },
            { field: 'ContractSerialNum', title: '合同序列号', width: 150, align: 'left' },
            { field: 'ContractAmount', title: '合同金额', width: 150, align: 'left' },
            { field: 'TaxFreeMoney', title: '不含税金额', width: 150 },
            { field: 'Tax', title: '税额', width: 150, align: 'left' },
            { field: 'ContractNumber', title: '合同书编号', width: 150, align: 'left' },
            { field: 'ContractName', title: '合同名称', width: 150, align: 'left' },
            { field: 'ContractDate', title: '合同书签订日', width: 150 },
            { field: 'DateDelivery', title: '交货期', width: 150, align: 'left' },
            { field: 'CirculationNumber', title: '发行回数', width: 150, align: 'left' }
        ]]
      
    });
}


//保存选择的合同
function SaveVoucher() {
    if (_seRrecord == null) {
        $.messager.alert('友情提示', "请选择合同", 'error');
        return false;
    }
    if (_seRrecord.IsChange == "变更") {
        _seRrecord.IsChange = 1;
    }
    else if (_seRrecord.IsChange == "取消") {
        _seRrecord.IsChange = 2;
    }
    else {
        _seRrecord.IsChange = 0;
    }
    $.ajax({
        type: "POST",
        url: "/AreasCode030/szrl025/SaveVoucher",
        async: false,
        data: {

            formid: _seRrecord.VoucheId,
            Circulation: $("#rl02503").val(),
            isChange: _seRrecord.IsChange
        },
        success: function (data) {
            var obj = $.parseJSON(data);
            if (obj.success) {
                //重新赋值标签1
                $.messager.alert('友情提示', "保存成功", 'info');
                $('#szrl026_ux_Grid').datagrid('reload');
                $('#szrl026Win').window('close');
            }
            else {
                $.messager.alert('友情提示', obj.Message, 'error');
            }
        }
    });

}


$('#btnExcel').linkbutton({
    onClick: function () {
        //var Print_tab = $('#tt').tabs('getSelected');
        //var Print_index = $('#tt').tabs('getTabIndex', Print_tab);
        //if (Print_index == 0) {
        //    //导出受注传票Excel
        //    window.location.href = "/AreasCode030/szrl025/ExportExcel?rl02501=" + zuofanid;
        //}
        //else if (Print_index == 1) {
        //    var ct1 = $("#ct1").text();
        //    var ct2 = $("#ct2").text();
        //    var ct3 = $("#ct3").text();
        //    var ct4 = $("#ct4").text();
        //    window.location.href = "/AreasCode030/szrl025/ExportExcel2?rl02501=" + zuofanid + "&ct1=" + ct1 + "&ct2=" + ct2 + "&ct3=" + ct3 + "&ct4=" + ct4;
        //}
        //else {
        //    return false;
        //}
        var ct1 = $("#ct1").text();
        var ct2 = $("#ct2").text();
        var ct3 = $("#ct3").text();
        var ct4 = $("#ct4").text();
        //window.location.href = "/AreasCode030/szrl025/ExportExcel?id=" + zuofanid + "&ct1=" + ct1 + "&ct2=" + ct2 + "&ct3=" + ct3 + "&ct4=" + ct4;
        var _url = "/AreasCode030/szrl025/ExportExcel?id=" + zuofanid + "&ct1=" + ct1 + "&ct2=" + ct2 + "&ct3=" + ct3 + "&ct4=" + ct4;
        window.open(_url);
    }
});




//打印
$('#btnPrint').linkbutton({
    onClick: function () {
        var Print_tab = $('#tt').tabs('getSelected');
        var Print_index = $('#tt').tabs('getTabIndex', Print_tab);
        if (Print_index == 0) {
            printdiv("szrl025From");
        }
        else if (Print_index == 1) {
            // printdiv("szrl026From");
        }
        else {
            return false;
        }
    }
});

function printdiv(printpage) {
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var newstr = document.all.item(printpage).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
}


//(function () {

//})();