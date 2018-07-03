/*
*name:manageCom
*author:wenqing
*封装一些后台管理模块中公共js
*/
; layui.define(function (exports) {
    var $ = layui.jquery, layer = layui.layer;
     
    var manageCom = {
        getHeight: function () {
            console.info($('.mytool').outerHeight(true));
            return $(window).height() -
                $('fieldset').outerHeight(true)
                - $('.mytool').outerHeight(true) - 30;
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
        },
        GenerateBtnByPower: function () {
            var menuId = self.frameElement.parentNode.getAttribute("lay-item-id");
            $.get('/Manage/RolePower/GetBtnPowerByMenuId', { "menuId": menuId },
                function (d) {
                    var toolBtnElm = "";
                    var rigthBtnElm = "";
                    $.each(d,
                        function (i, r) {
                            console.info(r.HasAuthority);
                            //默认生成工具栏按钮id  为 btn_BtnScript，在实现页面用事件注册方式写代码
                            //默认生成列表右侧按钮 lay-event  为 event_BtnScript 在页面实现根据事件写代码
                            if (r.HasAuthority||r.BtnScript=== "power") {
                                
                                if (r.BtnPosition === 1) {
                                    toolBtnElm +=
                                        '<button class="layui-btn layui-btn-sm" id="btn_' + r.BtnScript + '" >' +
                                        '<i class="layui-icon">' + r.BtnIcon + '</i>' + r.BtnName + '</button>';
                                }
                           
                                if (r.BtnPosition ===2) {
                                    rigthBtnElm += '<a class="layui-btn layui-btn-xs" lay-event="event_' + r.BtnScript + '"><i class="layui-icon">' + r.BtnIcon + '</i>' + r.BtnName + '</a>';
                                }

                            } else {
                                
                                if (r.BtnPosition === 1) {
                                    toolBtnElm +=
                                        '<button class="layui-btn layui-btn-sm layui-btn-disabled">' +
                                        '<i class="layui-icon">' + r.BtnIcon + '</i>' + r.BtnName + '</button>';
                                }
                                if (r.BtnPosition === 2) {
                                    rigthBtnElm += '<a class="layui-btn layui-btn-xs layui-btn-disabled" lay-event=""><i class="layui-icon">' + r.BtnIcon + '</i>' + r.BtnName + '</a>';

                                }
                            }
                           
                        });
                    $('.mytool').append(toolBtnElm);
                    $('#barDemo').append(rigthBtnElm);
                });
        }
    }
    exports('manageCom', manageCom);
});


