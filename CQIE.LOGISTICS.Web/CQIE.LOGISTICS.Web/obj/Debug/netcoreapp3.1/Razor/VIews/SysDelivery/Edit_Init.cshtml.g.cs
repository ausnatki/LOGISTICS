#pragma checksum "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "772deb7c87cb06ccfddb302cf1a1ad0b65927684"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.VIews_SysDelivery_Edit_Init), @"mvc.1.0.view", @"/VIews/SysDelivery/Edit_Init.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"772deb7c87cb06ccfddb302cf1a1ad0b65927684", @"/VIews/SysDelivery/Edit_Init.cshtml")]
    public class VIews_SysDelivery_Edit_Init : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
  CQIE.LOG.Models.Tool.CarTypeCarWaybillShipperUserModel temp = ViewBag.data as CQIE.LOG.Models.Tool.CarTypeCarWaybillShipperUserModel; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div style=""padding: 50px;"">
    <form class=""layui-form layui-form-pane"">

        <div class=""layui-form-item"">
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">发站</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 448, "\"", 486, 1);
#nullable restore
#line 9 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 456, temp.wayBill.DepartureStation, 456, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"  autocomplete=""off""  class=""layui-input""disabled>
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">到站</label>
                <div class=""layui-input-inline"">
                    <input type=""text"" name=""Shipper_Email""");
            BeginWriteAttribute("value", " value=\"", 795, "\"", 831, 1);
#nullable restore
#line 15 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 803, temp.wayBill.ArrivalStation, 803, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" autocomplete=""off"" class=""layui-input""disabled>
                </div>
            </div>
        </div>

        <div class=""layui-form-item"">


            <div class=""layui-form-item"">
                <label class=""layui-form-label"">车牌号</label>
                <div class=""layui-input-inline"">
                    <select name=""State"" lay-filter=""required"">
");
#nullable restore
#line 27 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                          
                            foreach (var t in temp.cars)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 1362, "\"", 1375, 1);
#nullable restore
#line 30 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 1370, t.Id, 1370, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 30 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                 Write(t.CarNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 31 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
            </div>
        </div>

        <div class=""layui-form-item"">
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">到站所属省市（自治区）</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", "value=\"", 1790, "\"", 1835, 1);
#nullable restore
#line 42 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 1797, temp.wayBill.ProvinceOfArrivalStation, 1797, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\"disabled>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n");
            WriteLiteral(@"        <div class=""layui-form-item people"">
            <p>托运人信息</p>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">名称</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 2230, "\"", 2256, 1);
#nullable restore
#line 53 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2238, temp.Shipper.Name, 2238, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\"  class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">电话</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 2483, "\"", 2510, 1);
#nullable restore
#line 58 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2491, temp.Shipper.Phone, 2491, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" autocomplete=""off"" class=""layui-input"" disabled>
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">地址</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 2797, "\"", 2826, 1);
#nullable restore
#line 64 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2805, temp.Shipper.Address, 2805, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">邮编</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3052, "\"", 3084, 1);
#nullable restore
#line 69 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3060, temp.Shipper.PostalCode, 3060, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled> \r\n                </div>\r\n                <label class=\"layui-form-label\">邮箱</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3309, "\"", 3336, 1);
#nullable restore
#line 73 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3317, temp.Shipper.Email, 3317, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n");
            WriteLiteral(@"        <div class=""layui-form-item people"">
            <p>送货人信息</p>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">名称</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 3732, "\"", 3758, 1);
#nullable restore
#line 84 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3740, temp.Carieer.Name, 3740, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">电话</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3984, "\"", 4011, 1);
#nullable restore
#line 89 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3992, temp.Carieer.Phone, 3992, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" autocomplete=""off"" class=""layui-input""disabled>
                </div>
            </div>
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">地址</label>
                <div class=""layui-input-inline"">
                    <input type=""text""");
            BeginWriteAttribute("value", " value=\"", 4297, "\"", 4326, 1);
#nullable restore
#line 95 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4305, temp.Carieer.Address, 4305, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\"disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">邮编</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4551, "\"", 4583, 1);
#nullable restore
#line 100 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4559, temp.Carieer.PostalCode, 4559, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\"disabled>\r\n                </div>\r\n                <label class=\"layui-form-label\">邮箱</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4806, "\"", 4833, 1);
#nullable restore
#line 104 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4814, temp.Carieer.Email, 4814, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" autocomplete=""off"" class=""layui-input""disabled>
                </div>
            </div>
        </div>

        <div class=""layui-form-item"">
            <div class=""layui-form-item"">
                <label class=""layui-form-label"">送货人</label>
                <div class=""layui-input-inline"">
                    <select name=""State"" lay-filter=""required"">
");
#nullable restore
#line 114 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                          
                            foreach (var t in temp.Delivery_Man)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 5368, "\"", 5381, 1);
#nullable restore
#line 117 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 5376, t.Id, 5376, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 117 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                 Write(t.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 118 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </select>
                </div>
            </div>
        </div>

        <div class=""layui-form-item"">
            <button class=""layui-btn"" lay-submit lay-filter=""Submit_Edit"">确认</button>
            <button type=""reset"" class=""layui-btn layui-btn-primary"">重置</button>
        </div>
    </form>
</div>
");
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