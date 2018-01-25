
var zuofanid = null;

var comboData = null;

var zip_1 = new Array;
var zip_2 = new Array;

var ComboGrid = function (target) {
    var me = this;

    me.pageSize = 10;
    me.data = null;
    me.selectIndex = null;

    me.combo = $(target).combogrid({
        panelWidth: 400,
        mode: 'local',
        idField: 'pj00402',
        textField: 'pj00402',
        columns: this.columns,
        pagination: true,
        keyHandler: {
            up: function () { me.selectRowUp(); },
            down: function () { me.selectRowDown(); },
            left: function () { },
            right: function () { },
            enter: function () { },
            query: function () { me.filter(); }
        },
        onShowPanel: function () { me.filter(); },
        onHidePanel: function () { me.data = null; }
    });

    me.grid = me.combo.combogrid('grid');

    me.pagination = me.grid.datagrid('getPager').pagination({
        showPageList: false,
        showRefresh: false,
        onSelectPage: function (pageIndex, pageSize) {
            me.combo.combogrid('textbox').focus();
            me.fillGrid(pageIndex);
        }
    });
};

ComboGrid.prototype = {
    columns: [[
        { field: 'pj00421', title: '编码' },
        { field: 'pj00402', title: '名称' },
        {
            field: 'pj00403', title: '性别',
            formatter: function (value, row, index) {
                return value == "1" ? "女" : "男";
            }
        },
        { field: 'pj00420', title: '电话' },
        { field: 'pj00415', title: '联系方式' }
    ]],
    filter: function () {
        var me = this;

        me.filterData();
        me.fillGrid(1);
    },
    fillGrid: function (pageIndex) {
        var me = this,
            rows = me.grid.datagrid('getRows'),
            start = me.pageSize * (pageIndex - 1);

        me.selectIndex = null;

        $.each(rows, function () {
            me.grid.datagrid('deleteRow', 0);
        });

        var data = me.data.slice(start, start + me.pageSize);

        $.each(data, function (index, value) {
            me.grid.datagrid('appendRow', value);
        });

        me.pagination.pagination({
            total: me.data.length,
            pageSize: me.pageSize,
            pageNumber: pageIndex
        });
    },
    filterData: function () {
        var me = this,
            key = me.combo.combogrid('getText');

        if (key == '' || key == ' ') {
            me.data = comboData;
        } else {
            me.data = $.grep(comboData, function (value) {
                return value.pj00402.indexOf(key) >= 0;
            });
        };
    },
    selectRowUp: function () {
        var me = this,
            rows = me.grid.datagrid('getRows');
        if (rows.length < 1) return;
        console.log(me.selectIndex);

        if (me.selectIndex !== null) {
            me.selectIndex--;
        } else {
            me.selectIndex = -1;
        }

        if (me.selectIndex < 0) me.selectIndex = rows.length - 1;

        me.grid.datagrid('selectRow', me.selectIndex);
    },
    selectRowDown: function () {
        var me = this,
            rows = me.grid.datagrid('getRows');
        if (rows.length < 1) return;
        if (me.selectIndex !== null) {
            me.selectIndex++;
        } else {
            me.selectIndex = rows.length;
        }

        if (me.selectIndex >= rows.length) me.selectIndex = 0;

        me.grid.datagrid('selectRow', me.selectIndex);
    }
};


$(function () {
    load();
    setTimeout(function () {
        disLoad();
    }, 800);
    GetForSome();
    //var $ipt = $("#sdbo001_input input").not("#bo00102").not("#bo00103");
    //$ipt.each(function (i) {
    //    var ipt_id = $(this).attr("id");
    //    try {
    //        if (ipt_id.length == 7) {
    //            $("#" + ipt_id + "").combogrid({
    //                panelWidth: 350,
    //                value: '',
    //                idField: 'pj00402',
    //                textField: 'pj00402',
    //                url: '/AreasCode030/sdbo001/List_sdpj004',
    //                remoteSort: false,
    //                rownumbers: true,
    //                pagination: true,
    //                scrollbarSize: 0,
    //                fit: true,
    //                //pageSize: 10,
    //                //pageList: [10, 20, 30],//可以设置每页记录条数的列表  
    //                //pagePosition: 'bottom',
    //                columns: [[
    //                    { field: 'pj00421', title: '编码'},
    //                    { field: 'pj00402', title: '名称'},
    //                    { field: 'pj00403', title: '性别' },
    //                    { field: 'pj00420', title: '电话'},
    //                    { field: 'pj00415', title: '联系方式'}
    //                ]]
    //            });
    //        }
    //    } catch (e) {

    //    }
    //});


    $.ajax({
        type: "POST",
        url: "/AreasCode030/sdbo001/List_sdpj004_2",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            comboData = data;

            var $ipt = $("#sdbo001_input input").not("#bo00102").not("#bo00103");
            $ipt.each(function (i) {

                var ipt_id = $(this).attr("id");
                try {
                    if (ipt_id.length == 7) {
                        new ComboGrid(this);
                    }
                } catch (e) {

                }
                ////$(this).click(function () {
                //$ipt.eq(i).combobox({
                //    valueField: 'pj00402',
                //    textField: 'pj00402',
                //    data: comdata
                //});
                //// })
            });
        }
    });

});























function combo_readonly(a) {
    var $ipt = $("#sdbo001_input input").not("#bo00102").not("#bo00103");
    $ipt.each(function (i) {
        var ipt_id = $(this).attr("id");
        try {
            if (ipt_id.length == 7) {
                $("#" + ipt_id + "").combo('readonly', a);
            }
        } catch (e) {
        }
    });
    $("#bo00102").combo('readonly', true);
    $("#bo00102").combo('readonly', true);
}





$("input[name='forsome']").click(function () {
    GetForSome();
});

//#region 1111
function GetForSome() {

    var forsome = $('input[name="forsome"]:checked ').val()
    $('#szrl001Tree').tree({
        url: '/AreasCode030/szrl001/TreeLoad',
        animate: true,
        onBeforeLoad: function (node, param) {
            $("#btn_save").linkbutton('disable');
            if (node == null)
                param.forsome = forsome;
        },
        onClick: function (node) {
            $(this).tree('expand', node.target);
            if (node.attributes) {
                var nodemessage = node.attributes.nodeType;//获取作番号
                if (nodemessage != "szrl001" && nodemessage != "szrl004") {
                    nodemessageid = nodemessage;
                    zuofanid = nodemessageid;
                    SetInfo();
                    //$("#sdbo001_input input").attr("disabled", true);//enable
                    combo_readonly(true);
                    $("#btn_edit").linkbutton('enable');
                    $("#btn_save").linkbutton('disable');
                }
            }
        },
        onCollapse: function (node) {
            $(this).tree('collapseAll', node.target);
        }
    });
}
//#endregion



function SetInfo() {
    if (zuofanid) {
        $("#sdbo004From").form({
            onLoadSuccess: function (_record) {//_record获取的数据
                GetInfoData(_record);
            },
            onLoadError: function () {

            }
        });
        var _url = "/AreasCode030/sdbo001/GetIndexInfo?zuofanid=" + zuofanid;
        $('#sdbo001From').form('load', _url);
    }
}
function GetInfoData(_record) {
}




$('#btn_save').linkbutton({
    onClick: function () {
        $('#sdbo001From').form('submit', {
            url: "/AreasCode030/sdbo001/Add",
            onSubmit: function (_param) {
                $(".zip_1").each(function () {
                    zip_1.push(this.value)
                });
                $(".zip_2").each(function () {
                    zip_2.push(this.value)
                });
                console.log(zip_1, zip_2);
                _param.bo00150 = zuofanid;
                _param.p1 = JSON.stringify(zip_1);
                _param.p2 = JSON.stringify(zip_2);
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
                    $("#btn_save").linkbutton('disable');
                    $("#btn_edit").linkbutton('enable');
                    combo_readonly(true);
                    //$("#sdbo001_input input").attr("disabled", true);
                    combo_readonly(true);
                    $.messager.alert('友情提示', '保存成功!', 'info');
                } else {
                    $.messager.alert('友情提示', obj.Message, 'error');
                }
                zip_1 = new Array();
                zip_2 = new Array();
            }
        });
    }
});

$('#btn_edit').linkbutton({
    onClick: function () {
        console.log("111");
        combo_readonly(false);
        //$("#sdbo001_input input").attr("disabled", false);
        combo_readonly(false);
        $("#btn_edit").linkbutton('disable');
        $("#btn_save").linkbutton('enable');
    }
});







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