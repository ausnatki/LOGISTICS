#pragma checksum "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f70907373bf45553af081103f96c05b52295101"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f70907373bf45553af081103f96c05b52295101", @"/VIews/SysDelivery/Edit_Init.cshtml")]
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
#nullable restore
#line 2 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
  int ID = Convert.ToInt32(ViewBag.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\"padding: 50px;\">\r\n    <form class=\"layui-form layui-form-pane\">\r\n\r\n        <input type=\"text\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 296, "\"", 307, 1);
#nullable restore
#line 6 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 304, ID, 304, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" hidden />\r\n        <div class=\"layui-form-item\">\r\n            <div class=\"layui-form-item\">\r\n                <label class=\"layui-form-label\">发站</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 550, "\"", 588, 1);
#nullable restore
#line 11 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 558, temp.wayBill.DepartureStation, 558, 30, false);

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
            BeginWriteAttribute("value", " value=\"", 897, "\"", 933, 1);
#nullable restore
#line 17 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 905, temp.wayBill.ArrivalStation, 905, 28, false);

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
                    <select name=""Car_Id"" lay-filter=""required"">
");
#nullable restore
#line 29 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                          
                            foreach (var t in temp.cars)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 1465, "\"", 1478, 1);
#nullable restore
#line 32 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 1473, t.Id, 1473, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 32 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                  Write(temp.delivery.Car_Id==t.Id?"selected":"");

#line default
#line hidden
#nullable disable
            WriteLiteral(">");
#nullable restore
#line 32 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                                                             Write(t.CarNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 33 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
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
            BeginWriteAttribute("value", "value=\"", 1937, "\"", 1982, 1);
#nullable restore
#line 44 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 1944, temp.wayBill.ProvinceOfArrivalStation, 1944, 38, false);

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
            BeginWriteAttribute("value", " value=\"", 2377, "\"", 2403, 1);
#nullable restore
#line 55 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2385, temp.Shipper.Name, 2385, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\"  class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">电话</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 2630, "\"", 2657, 1);
#nullable restore
#line 60 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2638, temp.Shipper.Phone, 2638, 19, false);

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
            BeginWriteAttribute("value", " value=\"", 2944, "\"", 2973, 1);
#nullable restore
#line 66 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 2952, temp.Shipper.Address, 2952, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">邮编</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3199, "\"", 3231, 1);
#nullable restore
#line 71 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3207, temp.Shipper.PostalCode, 3207, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled> \r\n                </div>\r\n                <label class=\"layui-form-label\">邮箱</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 3456, "\"", 3483, 1);
#nullable restore
#line 75 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3464, temp.Shipper.Email, 3464, 19, false);

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
            BeginWriteAttribute("value", " value=\"", 3879, "\"", 3905, 1);
#nullable restore
#line 86 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 3887, temp.Carieer.Name, 3887, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\" disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">电话</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4131, "\"", 4158, 1);
#nullable restore
#line 91 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4139, temp.Carieer.Phone, 4139, 19, false);

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
            BeginWriteAttribute("value", " value=\"", 4444, "\"", 4473, 1);
#nullable restore
#line 97 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4452, temp.Carieer.Address, 4452, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\"disabled>\r\n                </div>\r\n\r\n                <label class=\"layui-form-label\">邮编</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4698, "\"", 4730, 1);
#nullable restore
#line 102 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4706, temp.Carieer.PostalCode, 4706, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" autocomplete=\"off\" class=\"layui-input\"disabled>\r\n                </div>\r\n                <label class=\"layui-form-label\">邮箱</label>\r\n                <div class=\"layui-input-inline\">\r\n                    <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4953, "\"", 4980, 1);
#nullable restore
#line 106 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 4961, temp.Carieer.Email, 4961, 19, false);

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
                    <select name=""Delivery_man_Id"" lay-filter=""required"">
");
#nullable restore
#line 116 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                          
                            foreach (var t in temp.Delivery_Man)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <option");
            BeginWriteAttribute("value", " value=\"", 5525, "\"", 5538, 1);
#nullable restore
#line 119 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
WriteAttributeValue("", 5533, t.Id, 5533, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" ");
#nullable restore
#line 119 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                  Write(temp.delivery.Delivery_man_Id==t.Id?"selected":"");

#line default
#line hidden
#nullable disable
            WriteLiteral(">");
#nullable restore
#line 119 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
                                                                                                      Write(t.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</option>\r\n");
#nullable restore
#line 120 "D:\github\LOGISTICS\LOGISTICS\CQIE.LOGISTICS.Web\CQIE.LOGISTICS.Web\VIews\SysDelivery\Edit_Init.cshtml"
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
