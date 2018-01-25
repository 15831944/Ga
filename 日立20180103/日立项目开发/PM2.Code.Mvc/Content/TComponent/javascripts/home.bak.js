(function ($) {

    //'use strict';

    //#region 部件基类

    var Widget = function (args) {
        var me = this;
        me.container = null;
        me.grid = null;
        me.title = '';
        me.full = false;
        me.columns = null;
        me.tools = null;
        

        if (args) {
            args.title && (me.title = args.title);
            me.full = args.full ? true : false;
            args.tools && (me.tools = args.tools);
            args.columns && (me.columns = args.columns);
        };

        if (!me.tools) me.tools = [];
        me.tools.push({
            iconCls: 'icon-refresh',
            handler: function () {
                me.grid.datagrid('reload');
            }
        });

        me.container = $('<div class="widget-wrap"><div class="widget-container"></div></div>').appendTo('.wrapper');
        me.grid = $('<table>').appendTo(me.container.children());

        me.container.css({
            width: me.full ? '100%' : '50%',
            height: 450
        });

        me.grid.datagrid({
            fit: true,
            title: me.title,
            tools: me.tools,
            columns: me.columns
        });
    };

    Widget.prototype = {
        setFull: function () {
            this.container.css('width', '100%');
            this.grid.datagrid('resize');
        }
    };

    //#endregion

    //#region 部件类

    var Widgets = {};

    //#region 公司公告栏

    Widgets.Widget3000101 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '公司公告栏'
        }));
    };

    //#endregion

    //#region 我的发起

    Widgets.Widget3000102 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '我的发起'
        }));
    };

    //#endregion

    //#region 我的待批事宜

    Widgets.Widget3000103 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '我的待批事宜'
        }));
    };

    //#endregion

    //#region 作番内部精算提醒

    Widgets.Widget3000104 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '作番内部精算提醒'
        }));
    };

    //#endregion

    //#region 开票通知汇总表
     
    Widgets.Widget3000105 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '开票通知汇总表',
            full: true
        }));
    };

    //#endregion

    //#region 请款提醒

    Widgets.Widget3000106 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '请款提醒'
        }));
    };

    //#endregion

    //#region 已请款未收款列表

    Widgets.Widget3000107 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '已请款未收款列表'
        }));
    };

    //#endregion

    //#region 待开票清单

    Widgets.Widget3000108 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '待开票清单'
        }));
    };

    //#endregion

    //#region 已开票登记未请款一览表

    Widgets.Widget3000109 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '已开票登记未请款一览表'
        }));
    };

    //#endregion

    //#region 有验收计划但未处理

    Widgets.Widget3000110 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '有验收计划但未处理'
        }));
    };

    //#endregion

    //#region 采购合同返回跟踪提醒

    Widgets.Widget3000111 = function () {
        var me = this;
        $.extend(me, new Widget({
            title: '采购合同返回跟踪提醒'
        }));
    };

    //#endregion

    //#endregion

    //#region 页面控制类

    var Page = function () {
        var me = this,
            widgets = [];

        me.url = '/handler.ashx?folder=home&file=authority';

        var removeLoader = function () {
            var loader = $('.loader');
            loader.fadeTo('fast', 0, function () {
                loader.remove();
                loader = null;
            });
        };

        var pageWidth = function () {
            return $('body').outerWidth();
        };

        var addWidget = function (data) {
            $.each(data, function (index, value) {
                widgets.push(new Widgets['Widget' + value]());
            });
        };

        //#region 修正布局

        var fixWidget = function () {

            if (widgets.length == 0) return;

            var count = 0;
            $.each(widgets, function (index, value) {
                if (value.full) {
                    count = index;
                    return;
                };
            });

            if (count > 0 && count % 2 > 0) {
                widgets[count - 1].setFull();
            };

            if (count > 0 && (widgets.length - count - 1) % 2 > 0) {
                widgets[widgets.length - 1].setFull();
            };

            if (count == 0 && widgets.length % 2 > 0) {
                widgets[widgets.length - 1].setFull();
            }
        };

        //#endregion

        $.post(me.url, function (json) {
            addWidget($.parseJSON(json));
            fixWidget();
            removeLoader();
        });
    };

    //#endregion

    $(function () {
        new Page();
    });

}(jQuery));