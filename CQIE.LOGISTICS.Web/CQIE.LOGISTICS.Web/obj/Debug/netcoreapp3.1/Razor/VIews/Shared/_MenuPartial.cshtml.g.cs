#pragma checksum "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cd4721acca97179fd74c7ca93344dbb4746eecc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.VIews_Shared__MenuPartial), @"mvc.1.0.view", @"/VIews/Shared/_MenuPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cd4721acca97179fd74c7ca93344dbb4746eecc", @"/VIews/Shared/_MenuPartial.cshtml")]
    public class VIews_Shared__MenuPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Account/Logout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
  
    List<CQIE.LOG.Models.SystemMenu> menu = null;
    var service = this.Context.RequestServices.GetService(typeof(CQIE.LOG.Services.ISystemMenuService)) as CQIE.LOG.Services.ISystemMenuService;//获取服务
    if (service != null)
    {
        menu = service.GetSystemMenus().ToList();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul class=\"layui-nav layui-nav-tree\" lay-filter=\"test\">\r\n\r\n");
#nullable restore
#line 15 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
     foreach (var temp in menu)
    {
        int partentid = temp.Id;
        if (temp.ParentID != null) continue;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"layui-nav-item layui-nav-itemed\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 665, "\"", 673, 0);
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 674, "\"", 690, 1);
#nullable restore
#line 20 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
WriteAttributeValue("", 681, temp.Url, 681, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
                                Write(temp.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 21 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
          
            foreach (var temp2 in menu)
            {
                if (temp2.ParentID == partentid)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <dl class=\"layui-nav-child\">\r\n                        <dd><a");
            BeginWriteAttribute("href", " href=\"", 925, "\"", 942, 1);
#nullable restore
#line 27 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
WriteAttributeValue("", 932, temp2.Url, 932, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 27 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
                                            Write(temp2.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></dd>\r\n                    </dl>\r\n");
#nullable restore
#line 29 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
                }
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </li>\r\n");
#nullable restore
#line 33 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\Shared\_MenuPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <li class=\"layui-nav-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3cd4721acca97179fd74c7ca93344dbb4746eecc6332", async() => {
                WriteLiteral("退出");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n</ul>\r\n\r\n");
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
