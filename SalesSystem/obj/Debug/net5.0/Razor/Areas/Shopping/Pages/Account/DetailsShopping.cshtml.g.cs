#pragma checksum "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e2dfeb6717d7cf21117b8af9843e5e7a3dca77e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Shopping_Pages_Account_DetailsShopping), @"mvc.1.0.razor-page", @"/Areas/Shopping/Pages/Account/DetailsShopping.cshtml")]
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
#nullable restore
#line 1 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using SalesSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using SalesSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using SalesSystem.Areas.Shopping.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using SalesSystem.Areas.Shopping.Pages.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\_ViewImports.cshtml"
using SalesSystem.Library;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e2dfeb6717d7cf21117b8af9843e5e7a3dca77e", @"/Areas/Shopping/Pages/Account/DetailsShopping.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"401fb9e82c05727c9712072b5ad7f78ccd6d50c0", @"/Areas/Shopping/Pages/_ViewImports.cshtml")]
    public class Areas_Shopping_Pages_Account_DetailsShopping : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
  
    var money = LSetting.Mony;
    var image = "data:image/jpg;base64," + Convert.ToBase64String(Model.Input.DataShopping.Image,
0, Model.Input.DataShopping.Image.Length);
    var description = Model.Input.DataShopping.Description;
    var provider = Model.Input.DataShopping.Provider;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <h3>");
#nullable restore
#line 11 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
   Write(description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    <div class=\"row\">\r\n        <div class=\"col-sm \">\r\n            <div class=\"card text-center\" style=\"width: 21rem;\">\r\n                <div class=\"card-header \">\r\n                    <img class=\'imageUserDetails\'");
            BeginWriteAttribute("src", " src=\"", 599, "\"", 611, 1);
#nullable restore
#line 16 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
WriteAttributeValue("", 605, image, 605, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                </div>\r\n                <div class=\"card-body\">\r\n                    <div class=\"col-md-10\">\r\n                        <div class=\"row\">\r\n                            <p> ");
#nullable restore
#line 21 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                           Write(description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <p class=\"text-success\">");
#nullable restore
#line 24 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                               Write(String.Format(money + "{0:#,###,###,##0.00####}", Model.Input.DataShopping.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-sm"">
            <div class=""card"">
                <div class=""card-body"">
                    <table>
                        <tbody>
                            <tr>
                                <th>
                                    Informacion
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    Description
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 47 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                  Write(description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Precio
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p class=""text-success"">");
#nullable restore
#line 57 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                                       Write(String.Format(money + "{0:#,###,###,##0.00####}", Model.Input.DataShopping.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Cantidad
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 67 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                  Write(Model.Input.DataShopping.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Importe
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p class=""text-success"">");
#nullable restore
#line 77 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                                       Write(String.Format(money + "{0:#,###,###,##0.00####}", Model.Input.DataShopping.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Fecha
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 87 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                  Write(Model.Input.DataShopping.Date.ToString("dd/MMM/yyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    Proveedor
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <p>");
#nullable restore
#line 97 "D:\C#\SalesSystem\SalesSystem\Areas\Shopping\Pages\Account\DetailsShopping.cshtml"
                                  Write(provider);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </td>\r\n                            </tr>\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsShoppingModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsShoppingModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsShoppingModel>)PageContext?.ViewData;
        public DetailsShoppingModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
