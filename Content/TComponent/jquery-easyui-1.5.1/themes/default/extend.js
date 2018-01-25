(function ($) {

    'use strict';

    $(document).ready(function () { window.pm2 = new PM2UI(); });

    //#region PM2UI

    var PM2UI = function () {

        var me = this;

        me.body = $('body').layout();
        me.header = me.body.layout('panel', 'north');
        me.content = me.body.layout('panel', 'center');

    };

    PM2UI.prototype = {



    };

    //#endregion

    //#region easyui-layout

    $.extend($.fn.layout.defaults, {

        fit: true

    });

    $.extend($.fn.layout.paneldefaults, {

        border: false,
        height: 'auto'

    });

    //#endregion

    //#region easyui-panel

    $.extend($.fn.panel.defaults, {



    });

    //#endregion

    //#region easyui-tabs

    $.extend($.fn.tabs.defaults, {

        fit: true,
        border: false,
        tabPosition: 'bottom',
        tabHeight: 30,
        pill: true

    });

    //#endregion

    //#region easyui-textbox

    $.extend($.fn.textbox.defaults, {

        height: 24,
        width: 250,
        labelAlign: 'right',
        iconWidth: 28

    });

    //#endregion

    //#region easyui-numberbox

    $.extend($.fn.numberbox.defaults, {

        height: 24,
        width: 250,
        labelAlign: 'right'

    });

    //#endregion

    //#region easyui-numberbox

    $.extend($.fn.numberspinner.defaults, {

        height: 24,
        width: 250,
        labelAlign: 'right'

    });

    //#endregion

    //#region easyui-combobox

    $.extend($.fn.combobox.defaults, {

        height: 24,
        width: 150,
        labelAlign: 'right',
        iconWidth: 22

    });

    //#endregion

    $.extend($.fn.combotree.defaults, {
        height: 24,
        width: 150,
        labelAlign: 'right',
        iconWidth: 28
    });

    //#region easyui-searchbox

    $.extend($.fn.searchbox.defaults, {

        height: 24,
        width: 250,
        labelAlign: 'right',
        iconWidth: 22

    });

    //#endregion

    //#region easyui-datebox

    $.extend($.fn.datebox.defaults, {

        height: 24,
        width: 250,
        labelAlign: 'right',
        iconWidth: 22

    });

    //#endregion

    $.extend($.fn.switchbutton.defaults, {
        height: 24,
        width: 48
    });

})(jQuery);