#pragma checksum "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "573cb2808006823948e8cd7156b79611656fd109"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Place_WatchPlace), @"mvc.1.0.view", @"/Views/Place/WatchPlace.cshtml")]
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
#line 1 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\_ViewImports.cshtml"
using WebLeisure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\_ViewImports.cshtml"
using WebLeisure.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
using Core.ado;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
using Core.Classes_Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"573cb2808006823948e8cd7156b79611656fd109", @"/Views/Place/WatchPlace.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58ece859d7712c939f85faad04f6116f89b5668e", @"/Views/_ViewImports.cshtml")]
    public class Views_Place_WatchPlace : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Place>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
  
    ViewData["Title"] = "Activity";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
 using (Html.BeginForm("WatchPlace", "Place", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n\r\n        ");
#nullable restore
#line 14 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
   Write(Html.HiddenFor(a => a.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p>\r\n            <table width=\"700px\">\r\n                <tr>\r\n                    <td width=\"100px\">\r\n                        ");
#nullable restore
#line 19 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                   Write(Html.LabelFor(a => a.Name, "Название:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"400px\">\r\n                        <label for=\"Name\">");
#nullable restore
#line 22 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                                     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td width=\"100px\">\r\n                        ");
#nullable restore
#line 27 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                   Write(Html.LabelFor(a => a.Description, "Описание:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"400px\">\r\n                        <label for=\"Name\">");
#nullable restore
#line 30 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                                     Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td width=\"100px\">\r\n                        ");
#nullable restore
#line 35 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                   Write(Html.LabelFor(a => a.Place_Type.Name, "Вместительность:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"400px\">\r\n                        <label for=\"Name\">");
#nullable restore
#line 38 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                                     Write(Model.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n                <tr>\r\n                    <td width=\"100px\">\r\n                        ");
#nullable restore
#line 43 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                   Write(Html.LabelFor(a => a.Visits, "Посещений:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"400px\">\r\n                        <label for=\"Name\">");
#nullable restore
#line 46 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
                                     Write(Model.Visits);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n\r\n\r\n\r\n\r\n\r\n        </p>\r\n        <p>\r\n            ");
#nullable restore
#line 57 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
       Write(Html.Raw("<img style='width:500px; height:300px;' src=\"data:image/jpeg;base64,"
                                + Convert.ToBase64String(Model.Photo) + "\" />"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n        <p>\r\n\r\n\r\n\r\n        </p>\r\n\r\n\r\n    </fieldset>\r\n");
#nullable restore
#line 68 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Place\WatchPlace.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "573cb2808006823948e8cd7156b79611656fd1099234", async() => {
                WriteLiteral("Назад");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Place> Html { get; private set; }
    }
}
#pragma warning restore 1591
