
(function ($) {

    //#region sdpk007_ux_Grid
    var sdpk007_ux_Grid_Init = function () {

        var me = this;
        var args = {
            isLoad: false,
            pk: "-1"     //单据主键
        };
        $.extend(args, arguments[0]);

        var sdpk007_ux_Grid;
        me.SetPK = function (pk) {
            args.pk = pk;
            return me;
        };
        //#region 新增
        me.Add = function (_row) {
            sdpk007_ux_Grid.datagrid('appendRow', _row);
            return me;
        };
        //#endregion
        //#region 删除
        me.Remove = function () {
            var records = sdpk007_ux_Grid.datagrid('getChecked');
            if (records && records.length > 0) {

                var pa00801s = [];
                $.each(records, function (index, record) {
                    pa00801s.push(record.pk);
                });

                $.ajax({
                    type: "POST",
                    url: "/AreasCode019/sdpk007/Remove",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(pa00801s),
                    dataType: "json",
                    success: function (data) {
                        if (data.success) {
                            $.each(pa00801s, function (index, pk) {
                                var index = sdpk007_ux_Grid.datagrid('getRowIndex', pk);
                                sdpk007_ux_Grid.datagrid('deleteRow', index);
                            });

                        } else {
                            $.messager.alert('友情提示', data.Message, 'error');
                        }
                    },
                    error: function (data) {

                    }
                });

            } else
                $.messager.alert('提示信息', '请选择要删除的数据!', 'warning');
            return me;
        };
        //#endregion
        //#region 加载
        me.Load = function () {
            args.isLoad = true;
            sdpk007_ux_Grid.datagrid('load', {
                pk: args.pk
            });
            return me;
        };
        //#endregion
        //#region Init
        var Init = (function () {
            sdpk007_ux_Grid = $('#' + args.GridID);//$('#sdpk007_ux_Grid');
            sdpk007_ux_Grid.datagrid({
                idField: 'pk',
                fit: true,
                border: false,

                url: '/AreasCode019/sdpk007/GetModels',
                loadMsg: '数据加载中,请稍后...',
                method: 'post',
                rownumbers: true,
                singleSelect: true,
                checkOnSelect: false,
                selectOnCheck: false,

                pagination: true,
                pageSize: 100,
                pageList: [100],
                columns: [[
                    { field: "ck", checkbox: true },
                    { field: 'pk00803', title: '附件名称', width: 300 },
                    { field: 'pk00805', title: '创建时间', width: 180, align: 'center' },
                    { field: 'pj00402', title: '创建人', width: 130 }

                ]],
                onDblClickRow: function (rowIndex, record) {
                    args.onGrid_Click(rowIndex, record);
                },
                onBeforeLoad: function (param) {
                    return args.isLoad;
                }
            });
            var pager = sdpk007_ux_Grid.datagrid('getPager');
            pager.pagination({
                //total: 100,
                showPageList: false,
                layout: ['list', 'sep', 'first', 'prev', 'links', 'next', 'last', 'sep', 'refresh'],
                displayMsg: "当前页从 {from} 到 {to} 条记录.共 {total} 条记录."
            });

        })();
        //#endregion
    }
    //#endregion
    //#region 页面控制
    var _sdpk007_ux_WinClass = function () {

        var me = this;
        var args = {
            GridID: 'sdpk007_ux_Grid',
            onGrid_Click: function (rowIndex, record) { }
        };
        $.extend(args, arguments[0]);

        //#region 控件
        var sdpk007_ux_Grid;
        var sdpk007_ux_AddBt, sdpk007_ux_ReadBt, sdpk007_ux_DelBt;
        //#endregion
        me.Init = function (pk, isEnable) {
            sdpk007_ux_Grid.SetPK(pk);
            var x = 'enable';
            if (!isEnable)
                x = 'disable';
            sdpk007_ux_AddBt.linkbutton(x);
            sdpk007_ux_DelBt.linkbutton(x);
        };
        me.Add = function (_row) {
            sdpk007_ux_Grid.Add(_row);
            return me;
        };
        me.Load = function () {
            sdpk007_ux_Grid.Load();
            return me;
        };

        var Init = (function () {
            sdpk007_ux_Grid = new sdpk007_ux_Grid_Init(args);
            sdpk007_ux_AddBt = $('#sdpk007_ux_AddBt');
            sdpk007_ux_ReadBt = $('#sdpk007_ux_ReadBt');
            sdpk007_ux_DelBt = $('#sdpk007_ux_DelBt');
            //#region 附件新增
            sdpk007_ux_AddBt.linkbutton({
                onClick: function () {
                    if (me.pk == "-1") {
                        $.messager.alert('提示信息', '请设置关联单据主键!', 'warning');
                        return;
                    }
                    window.open('/AreasCode019/FileUpload/ChildAction/' + args.pk);

                }
            });
            //#endregion
            //#region 附件删除
            sdpk007_ux_DelBt.linkbutton({
                onClick: function () {
                    sdpk007_ux_Grid.Remove();
                }
            });
            //#endregion
            //#region 查看附件
            sdpk007_ux_ReadBt.linkbutton({
                onClick: function () {

                }
            });
            //#endregion
        })();

    };
    //#endregion
    window.sdpk007_ux_WinClass = new _sdpk007_ux_WinClass();

}(jQuery));

