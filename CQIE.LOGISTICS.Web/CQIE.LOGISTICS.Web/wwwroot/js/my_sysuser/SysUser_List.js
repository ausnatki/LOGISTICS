

layui.use(['table', 'dropdown'], function () {
    var table = layui.table;
    var dropdown = layui.dropdown;
    var form = layui.form;
    // 创建渲染实例
    table.render({
        elem: '#test',
        url: '/SysUser/GetAll', // 此处为静态模拟数据，实际使用时需换成真实接口
        toolbar: '#toolbarDemo',
        defaultToolbar: ['filter', 'exports', 'print', {
            title: '提示',
            layEvent: 'LAYTABLE_TIPS',
            icon: 'layui-icon-tips'
        }],
        height: 'full-35', // 最大高度减去其他容器已占有的高度差
        css: [ // 重设当前表格样式
            '.layui-table-tool-temp{padding-right: 145px;}'
        ].join(''),
        cellMinWidth: 80,
        totalRow: true, // 开启合计行
        page: true,
        cols: [[
            { type: 'checkbox', fixed: 'left' },
            { field: 'uid', fixed: 'left', width: '15%', title: 'ID', sort: true },
            { field: 'name', width: '20%', title: '用户' },
            { field: 'email', title: '邮箱 <i class="layui-icon layui-icon-tips layui-font-14" lay-event="email-tips" title="该字段开启了编辑功能" style="margin-left: 5px;"></i>', fieldTitle: '邮箱', hide: 0, width: '20%', expandedMode: 'tips', edit: 'text' },
            { field: 'iphone', width: '20%', title: '性别' },
            { fixed: 'right', title: '操作', width: '25%', minWidth: 125, toolbar: '#barDemo' }
        ]],
        done: function () {
            var id = this.id;
            // 下拉按钮测试
            dropdown.render({
                elem: '#dropdownButton', // 可绑定在任意元素中，此处以上述按钮为例
                data: [{
                    id: 'add',
                    title: '添加'
                }, {
                    id: 'update',
                    title: '编辑'
                }, {
                    id: 'delete',
                    title: '删除'
                }],
                // 菜单被点击的事件
                click: function (obj) {
                    var checkStatus = table.checkStatus(id)
                    var data = checkStatus.data; // 获取选中的数据
                    switch (obj.id) {
                        case 'add':
                            axios({
                                url: '/SysUser/Add',
                                method: 'GET'
                            }).then(result => {
                                layer.open({
                                    title: '添加',
                                    type: 1,
                                    area: ['50%', '50%'],
                                    content: result.data,
                                    success: function (layero, that) {
                                        var form = layui.form;
                                        var layer = layui.layer;

                                        /*     提交事件*/
                                        form.on('submit(Submit_Add)', function (data) {
                                            var field = data.field; // 获取表单字段值

                                            // 在打开新对话框之前关闭所有已打开的对话框
                                            layer.closeAll('dialog');

                                            /* 使用确认对话框*/
                                            layer.confirm('确定要添加信息吗?', {
                                                icon: 3,
                                                title: '提示'
                                            }, function (index) {
                                                /* 执行 AJAX 请求*/
                                                axios({
                                                    url: '/SysUser/Add',
                                                    method: 'POST',
                                                    data: field
                                                }).then(result => {
                                                    /*解析JSON字符串*/
                                                    var jsonData = JSON.parse(result.data);
                                                    handleResponse(jsonData);
                                                    layer.close(index); // 在处理响应后关闭确认对话框
                                                }).catch(error => {
                                                    /*请求失败处理*/
                                                    var jsonData = JSON.parse(error.data);
                                                    handleResponse(jsonData);
                                                });
                                            });

                                            return false; // 阻止默认 form 跳转
                                        });

                                        /*提取的处理响应逻辑*/
                                        function handleResponse(result) {
                                            if (result.success == true) {
                                                layer.msg(result.message, { icon: 1 });

                                                /* 延迟2秒后执行其他逻辑*/
                                                setTimeout(function () {
                                                    executeCommonLogic();
                                                }, 2000);
                                            }
                                            else {
                                                console.error(result);
                                                if (result != null) {
                                                    layer.msg(result.message, { icon: 2 });
                                                } else {
                                                    layer.msg("请求失败", { icon: 2 });
                                                }
                                            }
                                        }
                                        /*提取的公共逻辑*/
                                        function executeCommonLogic() {
                                            window.parent.location.reload(); // 刷新父页面
                                            parent.layer.closeAll(); // 关闭所有弹出层
                                        }
                                    },
                                    error: function (xhr, status, error) {
                                        layer.msg('请求出错', { icon: 2 });
                                    }
                                });
                            }).catch(error => {
                                layer.msg("打开失败" + error, { icon: 2 })
                            })
                            break;
                        case 'update':
                            if (data.length !== 1) return layer.msg('请选择一行');
                            layer.open({
                                title: '编辑',
                                type: 1,
                                area: ['80%', '80%'],
                                content: '<div style="padding: 16px;">自定义表单元素</div>'
                            });
                            break;
                        case 'delete':
                            if (data.length === 0) {
                                return layer.msg('请选择一行');
                            }
                            layer.msg('delete event');
                            break;
                    }
                }
            });

            // 行模式
            dropdown.render({
                elem: '#rowMode',
                data: [{
                    id: 'default-row',
                    title: '单行模式（默认）'
                }, {
                    id: 'multi-row',
                    title: '多行模式'
                }],
                // 菜单被点击的事件
                click: function (obj) {
                    var checkStatus = table.checkStatus(id)
                    var data = checkStatus.data; // 获取选中的数据
                    switch (obj.id) {
                        case 'default-row':
                            table.reload('test', {
                                lineStyle: null // 恢复单行
                            });
                            layer.msg('已设为单行');
                            break;
                        case 'multi-row':
                            table.reload('test', {
                                // 设置行样式，此处以设置多行高度为例。若为单行，则没必要设置改参数 - 注：v2.7.0 新增
                                lineStyle: 'height: 95px;'
                            });
                            layer.msg('即通过设置 lineStyle 参数可开启多行');
                            break;
                    }
                }
            });
        },
        error: function (res, msg) {
            console.log(res, msg)
        }
    });
    // 工具栏事件
    table.on('toolbar(test)', function (obj) {
        var id = obj.config.id;
        var checkStatus = table.checkStatus(id);
        var othis = lay(this);
        switch (obj.event) {
            case 'getCheckData':
                var data = checkStatus.data;
                layer.alert(layui.util.escape(JSON.stringify(data)));
                break;
            case 'getData':
                var getData = table.getData(id);
                console.log(getData);
                layer.alert(layui.util.escape(JSON.stringify(getData)));
                break;
            case 'LAYTABLE_TIPS':
                layer.alert('自定义工具栏图标按钮');
                break;
        };
    });
    // 表头自定义元素工具事件 --- 2.8.8+
    table.on('colTool(test)', function (obj) {
        var event = obj.event;
        console.log(obj);
        if (event === 'email-tips') {
            layer.alert(layui.util.escape(JSON.stringify(obj.col)), {
                title: '当前列属性配置项'
            });
        }
    });

    // 触发单元格工具事件
    table.on('tool(test)', function (obj) { // 双击 toolDouble
        var data = obj.data; // 获得当前行数据
        console.log("这是data")
        console.log(data.uid)
        // console.log(obj)
        if (obj.event === 'edit') {
            axios({
                url: '/SysUser/Edit_Init',
                method: 'GET',
                params: {
                    id: data.uid
                }
            }).then(result => {
                console.log(result);
                layer.open({
                    title: '编辑 - 用户:' + data.name,
                    type: 1,
                    area: ['50%', '50%'],
                    content: result.data,
                    success: function () {
                        var form = layui.form;
                        var layer = layui.layer;
                        axios({
                            url: '/SysUser/Get_By_Id',
                            method: 'GET',
                            params: {
                                id: data.uid
                            }
                        }).then(result => {
                            console.log(result)
                            console.log(result.data.name)
                            //form.val 方法，它用于给指定表单赋值
                            form.val('Edit-form', {
                                "Id": result.data.data.uid,
                                "username": result.data.data.name, // "name": "value"
                                "email": result.data.data.email,
                                "PhoneNumber": result.data.data.iphone,
                            });
                        }).catch(error => {
                            layer.msg("出错啦，页面弹出失败")
                        })

                        // 提交事件
                        form.on('submit(Submit_Edit)', function (data) {
                            var field = data.field; // 获取表单字段值
                            var field = data.field; // 获取表单字段值

                            // 在打开新对话框之前关闭所有已打开的对话框
                            layer.closeAll('dialog');

                            /* 使用确认对话框*/
                            layer.confirm('确定要修改信息吗?', {
                                icon: 3,
                                title: '提示'
                            }, function (index) {
                                /* 执行 AJAX 请求*/
                                axios({
                                    url: '/SysUser/Edit',
                                    method: 'POST',
                                    data: field
                                }).then(result => {
                                    /*解析JSON字符串*/
                                    var jsonData = JSON.parse(result.data);
                                    handleResponse(jsonData);
                                    layer.close(index); // 在处理响应后关闭确认对话框
                                }).catch(error => {
                                    /*请求失败处理*/
                                    var jsonData = JSON.parse(error.data);
                                    handleResponse(jsonData);
                                });
                            });

                            return false; // 阻止默认 form 跳转
                        });

                        /*提取的处理响应逻辑*/
                        function handleResponse(result) {
                            if (result.success == true) {
                                layer.msg(result.message, { icon: 1 });

                                /* 延迟2秒后执行其他逻辑*/
                                setTimeout(function () {
                                    executeCommonLogic();
                                }, 2000);
                            }
                            else {
                                console.error(result);
                                if (result != null) {
                                    layer.msg(result.message, { icon: 2 });
                                } else {
                                    layer.msg("请求失败", { icon: 2 });
                                }
                            }
                            return false; // 阻止默认 form 跳转
                        };
                        /*提取的公共逻辑*/
                        function executeCommonLogic() {
                            window.parent.location.reload(); // 刷新父页面
                            parent.layer.closeAll(); // 关闭所有弹出层
                        }
                    }
                });
            }).catch(error => {

            })

        } else if (obj.event === 'more') {
            // 更多 - 下拉菜单
            dropdown.render({
                elem: this, // 触发事件的 DOM 对象
                show: true, // 外部事件触发即显示
                data: [{
                    title: '查看',
                    id: 'detail'
                }, {
                    title: '删除',
                    id: 'del'
                }],
                click: function (menudata) {
                    if (menudata.id === 'detail') {
                        console.log(data);
                        layer.msg('查看操作，当前行 ID:' + data.uid);
                    } else if (menudata.id === 'del') {
                        console.log(data);
                        var uid = data.uid
                        layer.confirm('真的删除行 [id: ' + data.uid + '] 么', function (index) {
                            axios({
                                url: '/SysUser/Del',
                                method: 'GET',
                                params: {
                                    id: uid
                                }
                            }).then(result => {
                                obj.del(); // 删除对应行（tr）的DOM结构
                                layer.close(index);
                                // 向服务端发送删除指令
                                layer.msg("删除成功！", { icon: 1 })
                            }).catch(error => {
                                var jsonData = JSON.parse(error.data);
                                layer.msg("删除失败" + jsonData.message, { icon: 2 })
                            })
                        });
                    }
                },
                align: 'right', // 右对齐弹出
                style: 'box-shadow: 1px 1px 10px rgb(0 0 0 / 12%);' // 设置额外样式
            })
        }
    });

    // 触发表格复选框选择
    table.on('checkbox(test)', function (obj) {
        console.log(obj)
    });

    // 触发表格单选框选择
    table.on('radio(test)', function (obj) {
        console.log(obj)
    });

    // 行单击事件
    table.on('row(test)', function (obj) {
        //console.log(obj);
        //layer.closeAll('tips');
    });
    // 行双击事件
    table.on('rowDouble(test)', function (obj) {
        console.log(obj);
    });


    form.on('submit(demo-table-search)', function (data) {
        var field = data.field; // 获得表单字段
        console.log(field);

        table.reload('test', {
            page: {
                curr: 1 // 重新从第 1 页开始
            },
            where: field

        });
        layer.msg('搜索成功<br>此处为静态模拟数据，实际使用时换成真实接口即可');

        return false; // 阻止默认 form 跳转
    });
});




