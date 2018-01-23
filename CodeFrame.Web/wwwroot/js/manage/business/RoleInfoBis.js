/*
*name:RoleInfoBis
*author:wenqing
*角色管理js
*/
; layui.use(['form', 'layedit', 'laydate', 'table', 'layer', 'manageCom'],
    function () {

        var form = layui.form
            , layer = layui.layer
            , laydate = layui.laydate
            , manage = layui.manageCom
            , table = layui.table;

        //日期
        laydate.render({
            elem: '#date'
            , type: 'datetime'
        });

        //监听提交
        form.on('submit(demo1)', function (data) {
            tableIns.reload({
                where: data.field
                , page: {
                    curr: 1 //重新从第 1 页开始
                }
            });

            return false;
        });

        $("#btnadd").on('click',
            function () {
                layer.open({
                    type: 2,
                    title: '新增角色',
                    shadeClose: true,
                    //shade: false,
                    maxmin: true, //开启最大化最小化按钮
                    area: ['893px', '600px'],
                    content: '/Manage/RoleInfo/AddRole")'
                });
            });
        $("#btnedit").on('click',
            function () {
                var checkStatus = table.checkStatus('demo');
                var checkdata = checkStatus.data;
                if (checkdata.length != 1) {
                    layer.msg("请选一条数据编辑！");
                    return;
                }
                layer.open({
                    type: 2,
                    title: '编辑角色',
                    shadeClose: true,
                    //shade: false,
                    maxmin: true, //开启最大化最小化按钮
                    area: ['893px', '600px'],
                    content: '/Manage/RoleInfo/EditRole/' + checkStatus.data[0].Id
                });
            });

        $("#btndel").on('click',
            function () {
                var checkStatus = table.checkStatus('demo');
                var checkdata = checkStatus.data;
                if (checkdata.length == 0) {
                    layer.msg("请选择要删除的数据支持批量删除！");
                    return;
                }
                layer.confirm('真的要删??', function (index) {
                    var postdata = [];
                    checkdata.forEach(function (value) {
                        postdata.push(value.Id);
                    });

                    //console.info(postdata);
                    $.ajax({
                        type: "post",
                        url: '/Manage/RoleInfo/RoleDelete")',
                        data: { ids: postdata },
                        success: function (data) {
                            console.info(data);
                            if (data.code === 0) {
                                layer.msg("删除成功！!");
                                //obj.del(); //删除对应行（tr）的DOM结构，并更新缓存
                                tableIns.reload();
                            } else {
                                layer.msg(data.msg);
                            }
                        }
                    });
                    layer.close(index);
                    //向服务端发送删除指令

                });
            });
        //展示已知数据
        tableIns = table.render({
            elem: '#demo',
            url: '/Manage/RoleInfo/GetRoleInfo/'
            , height: manage.getHeight()
            , cols: [[ //标题栏
                { checkbox: true, LAY_CHECKED: false } //默认全选
                , { field: 'Id', title: 'Id', width: 80, sort: true }
                , { field: 'RoleName', title: '角色名称', width: 220 }
                , { field: 'Describe', title: '描述', width: 150 }
                , { field: 'IsActive', title: '是否激活', width: 100 }

                , { field: 'UpdateTime', title: '修改时间', width: 180 }
                , { field: 'CreteTime', title: '创建时间', width: 180, sort: true }
                , { fixed: 'right', width: 210, align: 'center', toolbar: '#barDemo' }
            ]]
            //, skin: 'row' //表格风格
            , even: false
            , page: true //是否显示分页
            , limits: [5, 7, 10, 100]
            , limit: 10 //每页默认显示的数量
            , loading: true
        });

        //监听工具条
        table.on('tool(test)', function (obj) { //注：tool是工具条事件名，test是table原始容器的属性 lay-filter="对应的值"
            var data = obj.data; //获得当前行数据
            var layEvent = obj.event; //获得 lay-event 对应的值（也可以是表头的 event 参数对应的值）
            var tr = obj.tr; //获得当前行 tr 的DOM对象
            console.info(data);
            if (layEvent === 'detail') { //查看
                layer.open({
                    type: 2,
                    title: '新增角色信息',
                    shadeClose: true,
                    //shade: false,
                    maxmin: true, //开启最大化最小化按钮
                    area: ['893px', '600px'],
                    content: '/Manage/RoleInfo/EditRole/?Id=' + data.Id + '&type=2'
                });
            } else if (layEvent === 'del') { //删除
                layer.confirm('真的删除' + data.Id + '这行么', function (index) {
                    var postdata = [];
                    postdata.push(data.Id);
                    //console.info(postdata);
                    $.ajax({
                        type: "post",
                        url: '/Manage/RoleInfo/RoleDelete")',
                        data: { ids: postdata },
                        success: function (data) {
                            console.info(data);
                            if (data.code === 0) {
                                layer.msg("删除成功！!");
                                //obj.del(); //删除对应行（tr）的DOM结构，并更新缓存
                                tableIns.reload();
                            } else {
                                layer.msg(data.msg);
                            }
                        }
                    });
                    layer.close(index);
                    //向服务端发送删除指令

                });
            } else if (layEvent === 'edit') { //编辑
                layer.open({
                    type: 2,
                    title: '编辑角色信息',
                    shadeClose: true,
                    //shade: false,
                    maxmin: true, //开启最大化最小化按钮
                    area: ['893px', '600px'],
                    content: '/Manage/RoleInfo/EditRole/' + data.Id
                });
            }
        });

    });
