(function ($) {

    var me = null;
    var sdpj003_ux_Win;
    //#region ctor
    var sdpj003_ux_WinClass = function () {
        me = this;
        sdpj003_ux_Win = $('#sdpj003_ux_Win');
        Init();
    };
    //#endregion
    var Init = function () {

        //#region sdpj003_ux_Win_Init
        sdpj003_ux_Win.window({
            title: '部门基本信息',
            width: 600,
            height: 500,
            top: '15%',
            border: 'thick',
            openAnimation: 'show',
            closeAnimation: 'slide',

            closed: true,
            //closable: false,
            collapsible: false,
            minimizable: false,
            maximizable: false,

            modal: true,
            resizable: false,
            inline: false,
            constrain: true,

            onResize: function () {
                $(this).window('hcenter');
            }

        });
        //#endregion
    }
    sdpj003_ux_WinClass.prototype = {
        Win_Show: function () {
            isLoad = true;
            sdpj003_ux_Win.window('open');
            me.Tree_Load();
            return me;
        }
    }

    window.sdpj003uxWinClass = null;
    $(document).ready(function (e) {
        sdpj003uxWinClass = new sdpj003_ux_WinClass();
    });

})(jQuery);

