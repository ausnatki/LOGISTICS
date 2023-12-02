////layui.use(['form', 'layer'], function () {
////    var form = layui.form;
////    var layer = layui.layer;

/////*     提交事件*/
////    form.on('submit(Submit_Add)', function (data) {
////        var field = data.field; // 获取表单字段值

////        /* 使用确认对话框*/
////        layer.confirm('确定要修改商品信息吗?', {
////            icon: 3,
////            title: false
////        }, function (index) {
////            /* 执行 AJAX 请求*/
////            axios({
////                url: '/SysUser/Add',
////                method: 'POST',
////                data: field
////            }).then(result => {
////                 /*解析JSON字符串*/
////                var jsonData = JSON.parse(result.data);
////                handleResponse(jsonData);
////                layer.close(index);
////            }).catch(error => {
////                 /*请求失败处理*/
////                var jsonData = JSON.parse(result.data);
////                handleResponse(jsonData);
////            });
////        });
////        return false; // 阻止默认 form 跳转
////    });

////     /*提取的处理响应逻辑*/
////    function handleResponse(result) {
////        if (result.success == true) {
////            layer.msg(result.message, { icon: 1 });

////            /* 延迟2秒后执行其他逻辑*/
////            setTimeout(function () {
////                executeCommonLogic();
////            }, 2000);
////        }
////        else {
////            console.error(result);
////            if (result!=null) {
////                layer.msg(result.message, { icon: 2 });
////            } else {
////                layer.msg("请求失败", { icon: 2 });
////            }
////        }
////    }
////     /*提取的公共逻辑*/
////    function executeCommonLogic() {
////        window.parent.location.reload(); // 刷新父页面
////        parent.layer.closeAll(); // 关闭所有弹出层
////    }
////});
