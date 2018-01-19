/*
*name:layuiExtend
*author:wenqing
*layui 组件扩展
*https://faysunshine.com/layui/formSelects/index.html
*/
; layui.define(function (exports) {
    var $ = layui.jquery;

    var formSelects= {
        options: {
            layFilter: '',
            left: '【',
            right: '】',
            separator: '',
        },
        $dom: null,
        arr: [],
        on(options) {//开启
            if (!options || !options.layFilter) {
                alert('请传入lay-filter');
                return;
            }
            layui.use(['form', 'jquery'], function () {
                var form = layui.form, $ = layui.jquery;
                $.extend(true, formSelects.options, options);
                formSelects.$dom = $('select[lay-filter="' + formSelects.options.layFilter + '"]').next();
                formSelects.$dom.find('dl').css('display', 'none');
                form.on('select(' + formSelects.options.layFilter + ')', function (data) {
                    var $choose = formSelects.exchange(data);
                    //如果所选有值, 放到数组中
                    if ($choose) {
                        var include = false;
                        for (var i in formSelects.arr) {
                            if (formSelects.arr[i] && formSelects.arr[i].val == $choose.val) {
                                formSelects.arr.splice(i, 1);
                                include = true;
                            }
                        }
                        if (!include) {
                            formSelects.arr.push($choose);
                        }
                    }
                    //调整渲染的Select显示
                    formSelects.show();
                    //取消收缩效果
                    formSelects.$dom.find('dl').css('display', 'block');
                    //这行代码是用于展示数据结果的
                    //formatJson(formSelects.arr);
                });

                $(document).on('click', 'select[lay-filter="' + formSelects.options.layFilter + '"] + div input', () => {
                    formSelects.show();
                });
                $(document).on('click', 'body:not(select[lay-filter="' + formSelects.options.layFilter + '"] + div)', (e) => {
                    var showFlag = $(e.target).parents('.layui-form-select').prev().attr('lay-filter') == formSelects.options.layFilter;
                    var thisFlag = formSelects.$dom.find('dl').css('display') == 'block';
                    if (showFlag) {//点击的input框
                        formSelects.$dom.find('dl').css('display', thisFlag ? 'none' : 'block');
                    } else {
                        if (thisFlag) {
                            formSelects.$dom.find('dl').css('display', 'none');
                        }
                    }
                });
            });
        },
        show() {
            formSelects.$dom.find('.layui-this').removeClass('layui-this');
            var input_val = '';
            for (var i in formSelects.arr) {
                var obj = formSelects.arr[i];
                if (obj) {
                    input_val += formSelects.options.separator + formSelects.options.left + obj.name + formSelects.options.right;
                    formSelects.$dom.find('dd[lay-value="' + obj.val + '"]').addClass('layui-this');
                }
            }
            if (formSelects.options.separator && formSelects.options.separator.length > 0 && input_val.startsWith(formSelects.options.separator)) {
                input_val = input_val.substr(formSelects.options.separator.length);
            }
            formSelects.$dom.find('.layui-select-title input').val(input_val);
        },
        exchange(data) {
            if (data.value) {
                return {
                    name: $(data.elem).find('option[value=' + data.value + ']').text(),
                    val: data.value
                }
            }
        }
    };

    var layuiExtend = { formSelects: formSelects };
    exports('layuiExtend', layuiExtend);
});