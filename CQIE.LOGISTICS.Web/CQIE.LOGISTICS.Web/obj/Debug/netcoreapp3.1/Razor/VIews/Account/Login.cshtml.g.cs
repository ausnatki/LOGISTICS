#pragma checksum "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ae945ddb69d8faa8c215c45a8604b735f66ca95"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.VIews_Account_Login), @"mvc.1.0.view", @"/VIews/Account/Login.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ae945ddb69d8faa8c215c45a8604b735f66ca95", @"/VIews/Account/Login.cshtml")]
    public class VIews_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CQIE.LOG.Models.Identity.SysUser>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ae945ddb69d8faa8c215c45a8604b735f66ca952802", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <title>Demo</title>\r\n    <!-- 请勿在项目正式环境中引用该 layui.css 地址 -->\r\n    <link href=\"/lib/node_modules/layui/dist/css/layui.css\" rel=\"stylesheet\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ae945ddb69d8faa8c215c45a8604b735f66ca954039", async() => {
                WriteLiteral(@"
    <style>
        .demo-login-container {
            width: 320px;
            margin: 21px auto 0;
        }

        .demo-login-other .layui-icon {
            position: relative;
            display: inline-block;
            margin: 0 2px;
            top: 2px;
            font-size: 26px;
        }
    </style>
    <div class=""my-Loginbox"">
        <form class=""layui-form"">
            <div class=""demo-login-container"">
                <div class=""layui-form-item"">
                    <div class=""layui-input-wrap"">
                        <div class=""layui-input-prefix"">
                            <i class=""layui-icon layui-icon-username""></i>
                        </div>
                        <input type=""text"" name=""UserName""");
                BeginWriteAttribute("value", " value=\"", 1119, "\"", 1161, 1);
#nullable restore
#line 38 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Account\Login.cshtml"
WriteAttributeValue("", 1127, Model != null?Model.UserName:"", 1127, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" lay-verify=""required"" placeholder=""用户名"" lay-reqtext=""请填写用户名"" autocomplete=""off"" class=""layui-input"" lay-affix=""clear"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <div class=""layui-input-wrap"">
                        <div class=""layui-input-prefix"">
                            <i class=""layui-icon layui-icon-password""></i>
                        </div>
                        <input type=""password"" name=""LoginPassword""");
                BeginWriteAttribute("value", " value=\"", 1667, "\"", 1712, 1);
#nullable restore
#line 46 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Account\Login.cshtml"
WriteAttributeValue("", 1675, Model!=null?Model.LoginPassword:"", 1675, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" lay-verify=""required"" placeholder=""密   码"" lay-reqtext=""请填写密码"" autocomplete=""off"" class=""layui-input"" lay-affix=""eye"">
                    </div>
                </div>
                <div class=""layui-form-item"">
                    <input type=""checkbox"" name=""remember"" lay-skin=""primary"" title=""记住密码"">
                    <a href=""#forget"" style=""float: right; margin-top: 7px;"">忘记密码？</a>
                </div>
                <div class=""layui-form-item"">
                    <button class=""layui-btn layui-btn-fluid"" lay-submit lay-filter=""login"">登录</button>
                </div>
                <div class=""layui-form-item demo-login-other"">
                    <label>社交账号登录</label>
                    <span style=""padding: 0 21px 0 6px;"">
                        <a href=""javascript:;""><i class=""layui-icon layui-icon-login-qq"" style=""color: #3492ed;""></i></a>
                        <a href=""javascript:;""><i class=""layui-icon layui-icon-login-wechat"" style=""color: #4daf29;""></i></a>
        ");
                WriteLiteral(@"                <a href=""javascript:;""><i class=""layui-icon layui-icon-login-weibo"" style=""color: #cf1900;""></i></a>
                    </span>
                    或 <a href=""#reg"">注册帐号</a>
                </div>
            </div>
        </form>
    </div>

    <!-- 请勿在项目正式环境中引用该 layui.js 地址 -->
    <script src=""/lib/node_modules/layui/dist/layui.js""></script>
    <script>

        function Loadin() {
            var index_login = layer.load(0, { shade: false });
            setTimeout(function () {
                layer.close(index_login);
                resolve();
            }, 2000);
        }


        layui.use(function () {
            var form = layui.form;
            var layer = layui.layer;
            // 提交事件
            form.on('submit(login)', function (data) {
                var field = data.field; // 获取表单字段值
                Loadin();
                layui.jquery.ajax({
                    type: 'POST',
                    url: ""/Account/Login"",
             ");
                WriteLiteral(@"       data: field,
                    //processData: false,  // 防止 jQuery 处理数据
                    //contentType: false,  // 防止 jQuery 设置内容类型
                    success: function (response) {
                        // Request success handling
                        if (response.success) {

                            layer.msg('登录成功');
                            window.location.href = ""/Home/Index"";
                        } else {
                            // 登录失败的操作
                            layer.alert('登录失败: ' + response.message, {
                                icon: 2,
                                title: ""错误""
                            });
                        }
                    },
                    error: function () {
                        // 处理 AJAX 请求错误
                        layer.alert('发生错误，请稍后再试。', {
                            title: '错误'
                        });
                    }

                })

                return false; // 阻止");
                WriteLiteral("默认 form 跳转\r\n            });\r\n        });\r\n    </script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CQIE.LOG.Models.Identity.SysUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
