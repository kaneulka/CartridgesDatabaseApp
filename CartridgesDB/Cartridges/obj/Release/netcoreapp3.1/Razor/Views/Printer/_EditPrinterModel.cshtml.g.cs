#pragma checksum "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Printer__EditPrinterModel), @"mvc.1.0.view", @"/Views/Printer/_EditPrinterModel.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Printer/_EditPrinterModel.cshtml", typeof(AspNetCore.Views_Printer__EditPrinterModel))]
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
#line 1 "D:\Cartridges\Cartridges\Views\_ViewImports.cshtml"
using Cartridges;

#line default
#line hidden
#line 2 "D:\Cartridges\Cartridges\Views\_ViewImports.cshtml"
using Cartridges.Models;

#line default
#line hidden
#line 2 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
using Cartridges.Web.Models.ViewModel;

#line default
#line hidden
#line 3 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
using Cartridges.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe3c3b08d9643547248b04c2f8170e5dda6ba7a", @"/Views/Printer/_EditPrinterModel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91b690bfeb6be76000ec1f5f7dfa8a937d042e24", @"/Views/_ViewImports.cshtml")]
    public class Views_Printer__EditPrinterModel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PrinterModelViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditPrinterModel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(102, 1978, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a5349", async() => {
                BeginContext(150, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(157, 93, false);
#line 6 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
Write(await Html.PartialAsync("_ModalHeader", new ModalHeader { Heading = "Редактировать модель" }));

#line default
#line hidden
                EndContext();
                BeginContext(250, 125, true);
                WriteLiteral("\r\n    <div class=\"modal-body form-horizontal\">\r\n        <div class=\"row\">\r\n            <div class=\"col-12\">\r\n                ");
                EndContext();
                BeginContext(375, 22, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a6273", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 10 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(397, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(415, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a7871", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 11 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PrinterCompanyId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(465, 64, true);
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    ");
                EndContext();
                BeginContext(529, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a9749", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#line 13 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(568, 28, true);
                WriteLiteral("<br />\r\n                    ");
                EndContext();
                BeginContext(596, 30, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a11435", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 14 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(626, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(648, 45, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dbe3c3b08d9643547248b04c2f8170e5dda6ba7a13046", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 15 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Name);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(693, 46, true);
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
                EndContext();
#line 18 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
             if (Model.CartridgeModels != null)
            {
                 

#line default
#line hidden
#line 20 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                  foreach (var item in Model.CartridgeModels)
                 {

#line default
#line hidden
                BeginContext(886, 116, true);
                WriteLiteral("                 <div class=\"col-3\">\r\n                     <div class=\"form-group\">\r\n                         <span>");
                EndContext();
                BeginContext(1003, 9, false);
#line 24 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                          Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1012, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1014, 14, false);
#line 24 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                                     Write(item.Bill.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1028, 11, true);
                WriteLiteral("</span>\r\n\r\n");
                EndContext();
#line 26 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                          if (Model.CheckedCartridgeModels != null)
                         {
                             

#line default
#line hidden
#line 28 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                              if (Model.CheckedCartridgeModels.Contains(item.Id))
                             {

#line default
#line hidden
                BeginContext(1251, 88, true);
                WriteLiteral("                                 <input type=\"checkbox\" checked name=\"cartridgeModelIds\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1339, "\"", 1355, 1);
#line 30 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
WriteAttributeValue("", 1347, item.Id, 1347, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1356, 23, true);
                WriteLiteral(" class=\"btn-check\" />\r\n");
                EndContext();
#line 31 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                             }
                             else
                             {

#line default
#line hidden
                BeginContext(1478, 80, true);
                WriteLiteral("                                 <input type=\"checkbox\" name=\"cartridgeModelIds\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1558, "\"", 1574, 1);
#line 34 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
WriteAttributeValue("", 1566, item.Id, 1566, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1575, 23, true);
                WriteLiteral(" class=\"btn-check\" />\r\n");
                EndContext();
#line 35 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                             }

#line default
#line hidden
#line 35 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                              
                         }
                         else
                         {

#line default
#line hidden
                BeginContext(1717, 76, true);
                WriteLiteral("                             <input type=\"checkbox\" name=\"cartridgeModelIds\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1793, "\"", 1809, 1);
#line 39 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
WriteAttributeValue("", 1801, item.Id, 1801, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1810, 23, true);
                WriteLiteral(" class=\"btn-check\" />\r\n");
                EndContext();
#line 40 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                         }

#line default
#line hidden
                BeginContext(1861, 70, true);
                WriteLiteral("                     </div>\r\n                 </div>                \r\n");
                EndContext();
#line 43 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                 }

#line default
#line hidden
#line 43 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
                              
            }

#line default
#line hidden
                BeginContext(1978, 32, true);
                WriteLiteral("        </div>\r\n    </div>\r\n    ");
                EndContext();
                BeginContext(2011, 60, false);
#line 47 "D:\Cartridges\Cartridges\Views\Printer\_EditPrinterModel.cshtml"
Write(await Html.PartialAsync("_ModalFooter", new ModalFooter { }));

#line default
#line hidden
                EndContext();
                BeginContext(2071, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrinterModelViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591