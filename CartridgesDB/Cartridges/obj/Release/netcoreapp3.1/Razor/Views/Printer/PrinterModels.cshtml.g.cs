#pragma checksum "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "def8a7b1f1c162fdda118a9e31c809061adb3ca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Printer_PrinterModels), @"mvc.1.0.view", @"/Views/Printer/PrinterModels.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Printer/PrinterModels.cshtml", typeof(AspNetCore.Views_Printer_PrinterModels))]
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
#line 2 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
using Cartridges.Web.Models;

#line default
#line hidden
#line 3 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
using Cartridges.Web.Code;

#line default
#line hidden
#line 4 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
using Cartridges.Web.Models.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"def8a7b1f1c162fdda118a9e31c809061adb3ca7", @"/Views/Printer/PrinterModels.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91b690bfeb6be76000ec1f5f7dfa8a937d042e24", @"/Views/_ViewImports.cshtml")]
    public class Views_Printer_PrinterModels : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PrinterModelViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sortType-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sortType-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Printer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrinterModels", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrinterCompanies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-pill btn-block btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(130, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 6 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
   ViewData["Title"] = "Модели принтеров " + @ViewBag.ProductModelName;
    Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
            BeginContext(251, 220, true);
            WriteLiteral("\n<div class=\"container-fluid\">\n    <div class=\"fade-in\">\n        <div class=\"row\">\n            <div class=\"col-lg-12\">\n                <div class=\"card\">\n                    <div class=\"card-header\"><h1>Модели принтеров ");
            EndContext();
            BeginContext(472, 27, false);
#line 14 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                                             Write(ViewBag.PrinterCompany.Name);

#line default
#line hidden
            EndContext();
            BeginContext(499, 104, true);
            WriteLiteral("</h1></div>\n                    <div class=\"card-body\">\n                        <div class=\"row mb-2\">\r\n");
            EndContext();
#line 17 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                             if (User.Identity.IsAuthenticated)
                            {
                                

#line default
#line hidden
#line 19 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 if (User.IsInRole("admin"))
                                {

#line default
#line hidden
            BeginContext(792, 138, true);
            WriteLiteral("                            <div class=\"col-lg-3\">\n                                <a id=\"createPrinterModelModal\" data-printerCompanyId=\"");
            EndContext();
            BeginContext(931, 25, false);
#line 22 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                                                                  Write(ViewBag.PrinterCompany.Id);

#line default
#line hidden
            EndContext();
            BeginContext(956, 236, true);
            WriteLiteral("\" data-toggle=\"modal\" href=\"#\" data-target=\"#modal-action-function\" class=\"btn btn-pill btn-block btn-primary\">\n                                    Добавить модель\n                                </a>\n                            </div>\n");
            EndContext();
#line 26 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                }

#line default
#line hidden
#line 26 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 
                            }

#line default
#line hidden
            BeginContext(1256, 83, true);
            WriteLiteral("                            <div class=\"col-lg-6\">\n                                ");
            EndContext();
            BeginContext(1339, 1155, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "def8a7b1f1c162fdda118a9e31c809061adb3ca710076", async() => {
                BeginContext(1431, 164, true);
                WriteLiteral("\n                                    <div class=\"form-group mb-0 mr-3\">\n                                        <input name=\"printerCompanyId\" id=\"printerCompanyId\"");
                EndContext();
                BeginWriteAttribute("value", "  value=\"", 1595, "\"", 1630, 1);
#line 31 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
WriteAttributeValue("", 1604, ViewBag.PrinterCompany.Id, 1604, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1631, 132, true);
                WriteLiteral(" type=\"hidden\" />\n                                        <select name=\"sortType\" id=\"sortType\" class=\"form-control\" data-sortType=\"");
                EndContext();
                BeginContext(1764, 16, false);
#line 32 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                                                                                             Write(ViewBag.SortType);

#line default
#line hidden
                EndContext();
                BeginContext(1780, 47, true);
                WriteLiteral("\">\n                                            ");
                EndContext();
                BeginContext(1827, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "def8a7b1f1c162fdda118a9e31c809061adb3ca711664", async() => {
                    BeginContext(1861, 11, true);
                    WriteLiteral("По названию");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1881, 45, true);
                WriteLiteral("\n                                            ");
                EndContext();
                BeginContext(1926, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "def8a7b1f1c162fdda118a9e31c809061adb3ca713265", async() => {
                    BeginContext(1960, 32, true);
                    WriteLiteral("По названию (в обратном порядке)");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2001, 486, true);
                WriteLiteral(@"
                                        </select>
                                    </div>
                                    <div class=""form-group mb-0"">
                                        <button type=""submit"" class=""btn btn-dark btn-pill btn-sm btnSearch"">
                                            <i class=""c-icon cil-search"">Отсортировать</i>
                                        </button>
                                    </div>
                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2494, 119, true);
            WriteLiteral("\n                            </div>\n                            <div class=\"col-lg-3\">\n                                ");
            EndContext();
            BeginContext(2613, 219, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "def8a7b1f1c162fdda118a9e31c809061adb3ca717212", async() => {
                BeginContext(2722, 106, true);
                WriteLiteral("\n                                    <i class=\"c-icon cil-list\">Назад</i>\n                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2832, 585, true);
            WriteLiteral(@"

                            </div>
                        </div>
                        <table class=""table table-responsive-sm table-bordered table-striped table-sm"">
                            <thead>
                                <tr>
                                    <th>Название</th>
                                    <th>Дата добавления</th>
                                    <th>Дата изменения</th>
                                    <th>Действия</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 61 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(3512, 53, true);
            WriteLiteral("                    <tr>\n                        <td>");
            EndContext();
            BeginContext(3566, 39, false);
#line 64 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(3605, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(3640, 44, false);
#line 65 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AddedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3684, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(3719, 47, false);
#line 66 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ModifiedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3766, 36, true);
            WriteLiteral("</td>\n                        <td>\r\n");
            EndContext();
#line 68 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                             if (User.Identity.IsAuthenticated)
                            {
                                

#line default
#line hidden
#line 70 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 if (User.IsInRole("admin"))
                                {

#line default
#line hidden
            BeginContext(3991, 183, true);
            WriteLiteral("                            <div class=\"btn-group btn-group-sm\" role=\"group\" aria-label=\"Small button group\">\n                                <a data-toggle=\"modal\" href=\"#\" data-id=\"");
            EndContext();
            BeginContext(4175, 7, false);
#line 73 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                                                    Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4182, 276, true);
            WriteLiteral(@""" data-target=""#modal-action-function"" class=""btn btn-dark editPrinterModelModal"">
                                    <i class=""c-icon cil-pencil"">Редактировать</i>
                                </a>
                                <a data-toggle=""modal"" href=""#"" data-id=""");
            EndContext();
            BeginContext(4459, 7, false);
#line 76 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                                                    Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4466, 235, true);
            WriteLiteral("\" data-target=\"#modal-action-function\" class=\"btn btn-danger deletePrinterModelModal\">\n                                    <i class=\"c-icon cil-trash\">Удалить</i>\n                                </a>\n                            </div>\n");
            EndContext();
#line 80 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                }

#line default
#line hidden
#line 80 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 
                            }

#line default
#line hidden
            BeginContext(4765, 55, true);
            WriteLiteral("                        </td>\n                    </tr>");
            EndContext();
#line 83 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                         }

#line default
#line hidden
            BeginContext(4822, 173, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            EndContext();
            BeginContext(4996, 146, false);
#line 93 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
Write(Html.Partial("_Modal", new BootstrapModel { ID = "modal-action-function", AreaLabeledId = "modal-action-function-label", Size = ModalSize.Large }));

#line default
#line hidden
            EndContext();
            BeginContext(5142, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5166, 282, true);
                WriteLiteral(@"
    <script>
        $('#createPrinterModelModal').click(function (e) {
            e.preventDefault();
            var printerCompany = $(this).attr(""data-printerCompanyId"");
            printerCompanyId = encodeURIComponent(printerCompany);
            $('#modal-content').load('");
                EndContext();
                BeginContext(5449, 40, false);
#line 102 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 Write(Url.Action("AddPrinterModel", "Printer"));

#line default
#line hidden
                EndContext();
                BeginContext(5489, 408, true);
                WriteLiteral(@"?printerCompanyId=' + printerCompanyId);
        });
        $('.editPrinterModelModal').click(function (e) {
            e.preventDefault();
            var id = $(this).attr(""data-id"");
            name = encodeURIComponent(id);
            var printerCompany = $(this).attr(""data-printerCompanyId"");
            printerCompanyId = encodeURIComponent(printerCompany);
            $('#modal-content').load('");
                EndContext();
                BeginContext(5898, 41, false);
#line 110 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 Write(Url.Action("EditPrinterModel", "Printer"));

#line default
#line hidden
                EndContext();
                BeginContext(5939, 286, true);
                WriteLiteral(@"?id=' + id + '&?printerCompanyId=' + printerCompanyId);
        });
        $('.deletePrinterModelModal').click(function (e) {
            e.preventDefault();
            var id = $(this).attr(""data-id"");
            name = encodeURIComponent(id);
            $('#modal-content').load('");
                EndContext();
                BeginContext(6226, 43, false);
#line 116 "D:\Cartridges\Cartridges\Views\Printer\PrinterModels.cshtml"
                                 Write(Url.Action("DeletePrinterModel", "Printer"));

#line default
#line hidden
                EndContext();
                BeginContext(6269, 356, true);
                WriteLiteral(@"?id=' + id);
        });

        var sortType = $('#sortType').attr(""data-sortType"");

        switch (sortType) {
            case ""0"":
                $('#sortType-0').attr(""selected"", ""selected"");
                break;
            case ""1"":
                $('#sortType-1').attr(""selected"", ""selected"");
                break;
        }
    </script>
");
                EndContext();
            }
            );
            BeginContext(6627, 1, true);
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PrinterModelViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
