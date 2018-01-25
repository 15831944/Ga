var long_init = {
    checkRate: checkRate,
    IsNullOrEmpty: IsNullOrEmpty,
    load: load,
    disLoad: disLoad
};
(function ($) {
    //string转数字,不成功返回原值
    long_init.checkRate = function (val) {
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
    long_init.IsNullOrEmpty = function (val) {
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
    long_init.load = function () {
        $("<div class=\"datagrid-mask\"></div>").css({ display: "block", width: "100%", height: $(window).height() }).appendTo("body");
        $("<div class=\"datagrid-mask-msg\"></div>").html("正在加载，请稍候。。。").appendTo("body").css({ display: "block", left: ($(document.body).outerWidth(true) - 190) / 2, top: ($(window).height() - 45) / 2 });
    }
    //取消加载层  
    long_init.disLoad = function () {
        $(".datagrid-mask").remove();
        $(".datagrid-mask-msg").remove();
    }
})(jQuery);













































