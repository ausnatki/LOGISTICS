#pragma checksum "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysCarType\Edit_Init.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83b9534529ffaccf8fd54c372a7c8f14750dd846"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.VIews_SysCarType_Edit_Init), @"mvc.1.0.view", @"/VIews/SysCarType/Edit_Init.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83b9534529ffaccf8fd54c372a7c8f14750dd846", @"/VIews/SysCarType/Edit_Init.cshtml")]
    public class VIews_SysCarType_Edit_Init : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div style=""padding: 50px;"">
    <form class=""layui-form layui-form-pane"" lay-filter=""Edit-form"">

        <input type=""text"" name=""Id"" hidden>
        <div class=""layui-form-item"">
            <div class=""layui-inline"">
                <label class=""layui-form-label"">车类型</label>
                <div class=""layui-input-block"">
                    <input type=""text"" name=""Name"" autocomplete=""off"" class=""layui-input"" lay-filter=""required"">
                </div>
            </div>
        </div>

        <div class=""layui-form-item"">
            <button class=""layui-btn"" lay-submit lay-filter=""Submit_Edit"">确认</button>
            <button type=""reset"" class=""layui-btn layui-btn-primary"">重置</button>
        </div>
    </form>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
