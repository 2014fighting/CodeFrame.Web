/**
  项目JS主入口
  定义了一个app模块 并依赖 layer  form  element
   
**/
layui.define(['layer', 'form', "element","tab"], function (exports) {
    var element = layui.element,
        layer = layui.layer,
        tab = layui.tab,
        form = layui.form;

    //一些事件监听
    element.on('tab(manageTab)', function (data) {

    });
    element.tabAdd('manageTab', {
        title: '选项卡的标题'
        , content: '选项卡的内容' //支持传入html
        , id: '选项卡标题的lay-id属性值'
    });
    element.on('nav(test)', function (elem) {
        console.log(elem); //得到当前点击的DOM对象
    });
    var myapp= {
        hello: function(name) {
    layer.msg('Hello my name is '+name);
        }

    }
    exports('app', myapp); //注意，这里是模块输出的核心，模块名必须和use时的模块名一致
});    