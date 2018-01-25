(function ($) {

    var me = null;
    //#region Init
    var loginFrom;
    var loginButton;
    //#endregion

    var Client = function () {

        me = this;
        //#region Init
        loginFrom = $('#loginFrom');
        loginButton = $('#loginButton');
        //#endregion
        Init();

        //#region 登录
        loginButton.linkbutton({
            onClick: function () {
                me.From_Submit();
            }
        });

        //#endregion

    };

    var Init = function () {
    }

    Client.prototype = {
        //#region 保存提交
        From_Submit: function () {
            loginFrom.form('submit', {
                onSubmit: function (_param) {
                    var isValid = $(this).form('validate');
                    if (!isValid) {
                        $.messager.alert('友情提示','请填写用户名密码!','info');
                    }
                    return isValid;
                },
                success: function (data) {
                    $.messager.progress('close');
                    var obj = $.parseJSON(data);
                    if (obj.success) {
                        window.location.href = '/Home/Index';

                    } else {
                        $.messager.alert('友情提示', obj.Message, 'error');
                    }

                }
            });
            return me;
        },
        //#endregion

    };

    $(document).ready(function () { new Client(); });

})(jQuery);