#pragma checksum "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "986a9277a949b92ca9b216dde02ae4f98c9b074c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Building_Buildings), @"mvc.1.0.view", @"/Views/Building/Buildings.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Building/Buildings.cshtml", typeof(AspNetCore.Views_Building_Buildings))]
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
#line 2 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
using Cartridges.Web.Models;

#line default
#line hidden
#line 3 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
using Cartridges.Web.Code;

#line default
#line hidden
#line 4 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
using Cartridges.Web.Models.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"986a9277a949b92ca9b216dde02ae4f98c9b074c", @"/Views/Building/Buildings.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91b690bfeb6be76000ec1f5f7dfa8a937d042e24", @"/Views/_ViewImports.cshtml")]
    public class Views_Building_Buildings : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BuildingViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sortType-0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("sortType-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Building", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Buildings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(126, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 6 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
   ViewData["Title"] = "Сооружения";
                Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
            BeginContext(224, 316, true);
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""fade-in"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""card"">
                    <div class=""card-header""><h1>Сооружения</h1></div>
                    <div class=""card-body"">
                        <div class=""row mb-2"">
");
            EndContext();
#line 17 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                             if (User.Identity.IsAuthenticated)
                            {
                        

#line default
#line hidden
#line 19 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                         if (User.IsInRole("admin"))
                        {

#line default
#line hidden
            BeginContext(713, 328, true);
            WriteLiteral(@"                        <div class=""col-lg-3"">
                            <a id=""createBuildingModal"" data-toggle=""modal"" href=""#"" data-target=""#modal-action-function"" class=""btn btn-pill btn-block btn-primary"">
                                Добавить сооружения
                            </a>
                        </div>");
            EndContext();
#line 25 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                              }

#line default
#line hidden
#line 25 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                               }

#line default
#line hidden
            BeginContext(1044, 83, true);
            WriteLiteral("                            <div class=\"col-lg-9\">\n                                ");
            EndContext();
            BeginContext(1127, 1005, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "986a9277a949b92ca9b216dde02ae4f98c9b074c8287", async() => {
                BeginContext(1215, 186, true);
                WriteLiteral("\n                                    <div class=\"form-group mb-0 mr-3\">\n                                        <select name=\"sortType\" id=\"sortType\" class=\"form-control\" data-sortType=\"");
                EndContext();
                BeginContext(1402, 16, false);
#line 29 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                                                                             Write(ViewBag.SortType);

#line default
#line hidden
                EndContext();
                BeginContext(1418, 47, true);
                WriteLiteral("\">\n                                            ");
                EndContext();
                BeginContext(1465, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "986a9277a949b92ca9b216dde02ae4f98c9b074c9341", async() => {
                    BeginContext(1499, 11, true);
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
                BeginContext(1519, 45, true);
                WriteLiteral("\n                                            ");
                EndContext();
                BeginContext(1564, 75, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "986a9277a949b92ca9b216dde02ae4f98c9b074c10941", async() => {
                    BeginContext(1598, 32, true);
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
                BeginContext(1639, 486, true);
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
            BeginContext(2132, 643, true);
            WriteLiteral(@"
                            </div>
                        </div>
                        <table class=""table table-responsive-sm table-bordered table-striped table-sm"">
                            <thead>
                                <tr>
                                    <th>Название</th>
                                    <th>Доп. названия</th>
                                    <th>Дата добавления</th>
                                    <th>Дата изменения</th>
                                    <th>Действия</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 53 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
            BeginContext(2870, 77, true);
            WriteLiteral("                                <tr>\n                                    <td>");
            EndContext();
            BeginContext(2948, 39, false);
#line 56 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(2987, 46, true);
            WriteLiteral("</td>\n                                    <td>");
            EndContext();
            BeginContext(3034, 45, false);
#line 57 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.OtherNames));

#line default
#line hidden
            EndContext();
            BeginContext(3079, 46, true);
            WriteLiteral("</td>\n                                    <td>");
            EndContext();
            BeginContext(3126, 44, false);
#line 58 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.AddedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3170, 46, true);
            WriteLiteral("</td>\n                                    <td>");
            EndContext();
            BeginContext(3217, 47, false);
#line 59 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ModifiedDate));

#line default
#line hidden
            EndContext();
            BeginContext(3264, 169, true);
            WriteLiteral("</td>\n                                    <td>\n                                        <div class=\"btn-group btn-group-sm\" role=\"group\" aria-label=\"Small button group\">\n");
            EndContext();
#line 62 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                             if (User.Identity.IsAuthenticated)
                                            {
                                                

#line default
#line hidden
#line 64 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                 if (User.IsInRole("admin"))
                                                {

#line default
#line hidden
            BeginContext(3686, 93, true);
            WriteLiteral("                                                    <a data-toggle=\"modal\" href=\"#\" data-id=\"");
            EndContext();
            BeginContext(3780, 7, false);
#line 66 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                                                        Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3787, 239, true);
            WriteLiteral("\" data-target=\"#modal-action-function\" class=\"btn btn-dark editBuildingModal\">\n                                                        <i class=\"c-icon cil-pencil\">Редактировать</i>\n                                                    </a>\n");
            EndContext();
#line 69 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                }

#line default
#line hidden
#line 69 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                 
                                            }

#line default
#line hidden
            BeginContext(4122, 44, true);
            WriteLiteral("                                            ");
            EndContext();
#line 71 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                             if (User.Identity.IsAuthenticated)
                                            {
                                                

#line default
#line hidden
#line 73 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                 if (User.IsInRole("admin"))
                                                {

#line default
#line hidden
            BeginContext(4375, 93, true);
            WriteLiteral("                                                    <a data-toggle=\"modal\" href=\"#\" data-id=\"");
            EndContext();
            BeginContext(4469, 7, false);
#line 75 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                                                        Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4476, 236, true);
            WriteLiteral("\" data-target=\"#modal-action-function\" class=\"btn btn-danger deleteBuildingModal\">\n                                                        <i class=\"c-icon cil-trash\">Удалить</i>\n                                                    </a>\n");
            EndContext();
#line 78 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                }

#line default
#line hidden
#line 78 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                                 
                                            }

#line default
#line hidden
            BeginContext(4808, 126, true);
            WriteLiteral("                                        </div>\n                                    </td>\n                                </tr>");
            EndContext();
#line 82 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                     }

#line default
#line hidden
            BeginContext(4936, 173, true);
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            EndContext();
            BeginContext(5110, 146, false);
#line 92 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
Write(Html.Partial("_Modal", new BootstrapModel { ID = "modal-action-function", AreaLabeledId = "modal-action-function-label", Size = ModalSize.Large }));

#line default
#line hidden
            EndContext();
            BeginContext(5256, 2, true);
            WriteLiteral("\n\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5280, 139, true);
                WriteLiteral("\n    <script>\n        $(\'#createBuildingModal\').click(function (e) {\n            e.preventDefault();\n            $(\'#modal-content\').load(\'");
                EndContext();
                BeginContext(5420, 37, false);
#line 99 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                 Write(Url.Action("AddBuilding", "Building"));

#line default
#line hidden
                EndContext();
                BeginContext(5457, 228, true);
                WriteLiteral("\');\n        });\n        $(\'.editBuildingModal\').click(function (e) {\n            e.preventDefault();\n            var id = $(this).attr(\"data-id\");\n            name = encodeURIComponent(id);\n            $(\'#modal-content\').load(\'");
                EndContext();
                BeginContext(5686, 38, false);
#line 105 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                 Write(Url.Action("EditBuilding", "Building"));

#line default
#line hidden
                EndContext();
                BeginContext(5724, 239, true);
                WriteLiteral("?id=\' + id);\n        });\n        $(\'.deleteBuildingModal\').click(function (e) {\n            e.preventDefault();\n            var id = $(this).attr(\"data-id\");\n            name = encodeURIComponent(id);\n            $(\'#modal-content\').load(\'");
                EndContext();
                BeginContext(5964, 40, false);
#line 111 "D:\Cartridges\Cartridges\Views\Building\Buildings.cshtml"
                                 Write(Url.Action("DeleteBuilding", "Building"));

#line default
#line hidden
                EndContext();
                BeginContext(6004, 356, true);
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
            BeginContext(6362, 1, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BuildingViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591