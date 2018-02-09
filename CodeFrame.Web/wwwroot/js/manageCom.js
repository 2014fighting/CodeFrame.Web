/*
*name:manageCom
*author:wenqing
*封装一些后台管理模块中公共js
*/
; layui.define(function (exports) {
    var $ = layui.jquery;
    var manageCom = {
        getHeight: function () {
            return $(window).height() -
                $('fieldset').outerHeight(true) -
                $('.mytool').outerHeight(true);
        },
        selectInint: function (selectName/*name选择器*/, data/*enumData.js数据*/, defaulVal/*默认值*/) {
            data.forEach(function (item, index) {
                console.info(!!defaulVal);
                $("select[name='" + selectName + "']").append("<option value=" + item.value + ">" + item.text + "</option>");
            });
            //赋值
            if (!!defaulVal) {
                $("select[name='" + selectName + "']").val(defaulVal);
            }
        },
        getUrlParam: function (name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        }
    }
    exports('manageCom', manageCom);
});


