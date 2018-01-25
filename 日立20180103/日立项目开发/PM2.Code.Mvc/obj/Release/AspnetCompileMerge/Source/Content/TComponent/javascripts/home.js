(function ($) {

    'use strict';

    var urls = {
        3000101: { url: 'a.html', full: false },
        3000102: { url: '3000101.html', full: false },
        3000103: { url: '3000101.html', full: false },
        3000104: { url: '3000101.html', full: false },
        3000105: { url: '/AreasCode030/szrl116/Index', full: true },
        3000106: { url: '3000101.html', full: false },
        3000107: { url: '3000101.html', full: false },
        3000108: { url: '3000101.html', full: false },
        3000109: { url: '3000101.html', full: false },
        3000110: { url: '3000101.html', full: false },
        3000111: { url: '3000101.html', full: false }
    };

    var Widget = function () {

        var me = this;
        me.container = $('<div class="widget-wrap"><div class="widget-container"></div></div>').appendTo('.wrapper');
        me.frame = $('<iframe frameborder="0" width="100%" height="100%" scrolling="no"></iframe>').appendTo(me.container.children());

    };

    Widget.prototype = {
        full: false,
        setWidth: function (full) {
            if (full)
                this.container.css('width', '100%');
            else
                this.container.css('width', '50%');
            console.log(full);
        },
        setUrl: function (url) {
            this.frame.attr('src', url);
        }
    };

    var Page = function () {

        var me = this,
            widgets = [];

        var removeLoader = function () {
            var loader = $('.loader');
            loader.fadeTo('fast', 0, function () {
                loader.remove();
                loader = null;
            });
        };

        var addWidget = function (data) {
            $.each(data, function (index, value) {
                var widget = new Widget();
                widget.full = urls[value].full;
                widget.setWidth(urls[value].full);
                widget.setUrl(urls[value].url);
                widgets.push(widget);
            });
        }

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
                widgets[count - 1].setWidth(true);
            };

            if (count > 0 && (widgets.length - count - 1) % 2 > 0) {
                widgets[widgets.length - 1].setWidth(true);
            };

            if (count == 0 && widgets.length % 2 > 0) {
                widgets[widgets.length - 1].setWidth(true);
            }
        };

        //#endregion

        /*
        json数据模型（有权限的菜单ID数组）
        [ "3000101", "3000102", "3000103", "3000104", "3000105", "3000106", "3000107", "3000108", "3000109", "3000110", "3000111" ]
        */

        //$.post('/handler.ashx?folder=home&file=authority', function (json) {
        //    addWidget($.parseJSON(json));
        //    fixWidget();
        //    removeLoader();
        //});
        addWidget(["3000101", "3000102", "3000103", "3000104", "3000105", "3000106", "3000107", "3000108", "3000109", "3000110", "3000111"]);
        fixWidget();
        removeLoader();
    };

    $(function () {
        new Page();
    });

}(jQuery));