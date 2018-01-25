
(function ($) {

    window.Easy_GridPanel = function () {

        var me = this;
        var args = {
            id: undefined,      //控件ID
            isPagination: true, //是否启用分页 True: 是
            isLoad: false,      //True: 自动加载

            //默认配置信息
            configuration : { }
            
        };
        $.extend(args, arguments[0]);

        var _ux_Grid = null;
        //#region me.GridPanel
        var Init = (function () {
            _ux_Grid = $('#' + args.id);
            var _ux_Grid_configuration = {
                idField: undefined,
                fit: true,
                border: false,

                url: undefined,
                loadMsg: '数据加载中,请稍后...',
                method: 'post',
                rownumbers: true,
                singleSelect: true,
                checkOnSelect: false,
                selectOnCheck: false,

                pagination: args.isPagination,
                pageSize: 100,
                pageList: [100],

                columns: [],
                onBeforeLoad: function (param) {
                    return args.isLoad;
                }
            };
            $.extend(_ux_Grid_configuration, args.configuration);

            _ux_Grid.datagrid(_ux_Grid_configuration);
            if (args.isPagination) {
                _ux_Grid.datagrid('getPager').pagination({
                    showPageList: false,
                    layout: ['list', 'sep', 'first', 'prev', 'links', 'next', 'last', 'sep', 'refresh'],
                    displayMsg: "当前页从 {from} 到 {to} 条记录.共 {total} 条记录."
                });
            }
            me.GridPanel = _ux_Grid;

        })();
        //#endregion

        //#region 数据加载
        me.Load = function (_params) {
            args.isLoad = true;
            _ux_Grid.datagrid('load', _params);
           
        };
        //#endregion
        
    }
    
}(jQuery));

