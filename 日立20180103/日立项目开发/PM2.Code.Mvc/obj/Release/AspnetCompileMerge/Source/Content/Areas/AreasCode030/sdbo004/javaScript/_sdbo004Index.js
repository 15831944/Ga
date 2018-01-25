(function ($) {
    var zuofanid = null;
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
                 
                    
                }
            }
        },
        onCollapse: function (node) {
            $(this).tree('collapseAll', node.target);
        }
    });
    function SetInfo() {
        if (zuofanid) {
            $("#sdbo004From").form({
                onLoadSuccess: function (_record) {//_record获取的数据
                    GetInfoData(_record);
                },
                onLoadError: function () {

                }
            });
            var _url = "/AreasCode030/sdbo004/GetIndexInfo?zuofanid=" + zuofanid;
            $('#sdbo004From').form('load', _url);
        }
    }
    function GetInfoData(_record) {

    }





}(jQuery));



