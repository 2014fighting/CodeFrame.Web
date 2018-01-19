/*
*name:manageCom
*author:wenqing
*封装一些后台管理模块中公共js
*/
; layui.define(function (exports) {
    var $ = layui.jquery;
    var manageCom = {

        getHeight:function () {
            return $(window).height() - $('fieldset').outerHeight(true)
                - $('.mytool').outerHeight(true);
    }
}
    exports('manageCom', manageCom);
});


