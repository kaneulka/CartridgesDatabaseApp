#pragma checksum "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63104ecfbb9b17e4d41acfd8f5f1216c753076b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request__RequestInfo), @"mvc.1.0.view", @"/Views/Request/_RequestInfo.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Request/_RequestInfo.cshtml", typeof(AspNetCore.Views_Request__RequestInfo))]
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
#line 2 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
using Cartridges.Web.Models.ViewModel;

#line default
#line hidden
#line 3 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
using Cartridges.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63104ecfbb9b17e4d41acfd8f5f1216c753076b1", @"/Views/Request/_RequestInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91b690bfeb6be76000ec1f5f7dfa8a937d042e24", @"/Views/_ViewImports.cshtml")]
    public class Views_Request__RequestInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RequestViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(92, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(94, 104, false);
#line 5 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
Write(await Html.PartialAsync("_ModalHeader", new ModalHeader { Heading = "Подробная информация о служебке" }));

#line default
#line hidden
            EndContext();
            BeginContext(198, 34, true);
            WriteLiteral("\n<div class=\"modal-body\">\n    <h3>");
            EndContext();
            BeginContext(233, 10, false);
#line 7 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
   Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(243, 296, true);
            WriteLiteral(@"</h3>
    <div class=""row"">
        <div class=""col-12"">
            <div class=""product__info"">
                <div id=""description"" class=""description description_active"">
                    <div class=""product__group"">
                        <strong>Отдел: </strong><span id=""article-name"">");
            EndContext();
            BeginContext(540, 20, false);
#line 13 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                   Write(Model.DepartmentName);

#line default
#line hidden
            EndContext();
            BeginContext(560, 160, true);
            WriteLiteral("</span>\n                    </div>\n                    <div class=\"product__group\">\n                        <strong>Помещение: </strong><span id=\"article-name\">");
            EndContext();
            BeginContext(721, 18, false);
#line 16 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                       Write(Model.BuildingName);

#line default
#line hidden
            EndContext();
            BeginContext(739, 1, true);
            WriteLiteral("-");
            EndContext();
            BeginContext(741, 10, false);
#line 16 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                                           Write(Model.Room);

#line default
#line hidden
            EndContext();
            BeginContext(751, 158, true);
            WriteLiteral("</span>\n                    </div>\n                    <div class=\"product__group\">\n                        <strong>Принтер: </strong><span id=\"article-name\">");
            EndContext();
            BeginContext(910, 22, false);
#line 19 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                     Write(Model.PrinterModelName);

#line default
#line hidden
            EndContext();
            BeginContext(932, 178, true);
            WriteLiteral(" </span>\n                    </div>\n                    <div class=\"product__group\">\n                        <strong>Инвентарный номер принтера: </strong><span id=\"article-name\">");
            EndContext();
            BeginContext(1111, 21, false);
#line 22 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                                        Write(Model.InventoryNumber);

#line default
#line hidden
            EndContext();
            BeginContext(1132, 159, true);
            WriteLiteral("</span>\n                    </div>\n                    <div class=\"product__group\">\n                        <strong>Картридж: </strong><span id=\"article-name\">");
            EndContext();
            BeginContext(1292, 24, false);
#line 25 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                      Write(Model.CartridgeModelName);

#line default
#line hidden
            EndContext();
            BeginContext(1316, 178, true);
            WriteLiteral("</span>\n                    </div>\n                    <div class=\"product__group\">\n                        <strong>Номенклатурный номер и счет: </strong><span id=\"article-name\">");
            EndContext();
            BeginContext(1495, 21, false);
#line 28 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                                                                                         Write(Model.CartridgeNomNum);

#line default
#line hidden
            EndContext();
            BeginContext(1516, 35, true);
            WriteLiteral("</span>\n                    </div>\n");
            EndContext();
#line 30 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
                     if (Model.Defective == true)
            {

#line default
#line hidden
            BeginContext(1616, 138, true);
            WriteLiteral("                    <div class=\"product__group\">\n                        <strong>Картридж неисправен</strong>\n                    </div>\r\n");
            EndContext();
#line 35 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
            }

#line default
#line hidden
            BeginContext(1768, 75, true);
            WriteLiteral("                </div>\n            </div>\n        </div>\n    </div>\n</div>\n");
            EndContext();
            BeginContext(1844, 60, false);
#line 41 "D:\Cartridges\Cartridges\Views\Request\_RequestInfo.cshtml"
Write(await Html.PartialAsync("_ModalFooter", new ModalFooter { }));

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RequestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591