#pragma checksum "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d7596278ca781b1ade45904b2ca3b3f0a14f6f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_Index), @"mvc.1.0.view", @"/Views/Activity/Index.cshtml")]
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
#line 1 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
using System.Collections.ObjectModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
using Core.ado;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d7596278ca781b1ade45904b2ca3b3f0a14f6f5", @"/Views/Activity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58ece859d7712c939f85faad04f6116f89b5668e", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ObservableCollection<Activity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Activity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "WatchActivity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("bgcolor", new global::Microsoft.AspNetCore.Html.HtmlString("#B4E15E"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d7596278ca781b1ade45904b2ca3b3f0a14f6f55248", async() => {
                WriteLiteral("\r\n    <h2>События</h2>\r\n    \r\n    <br />\r\n\r\n\r\n");
                WriteLiteral("    <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
         foreach (var activity in Model)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"col-md-4 mb-5\">\r\n                <div class=\"card h-100\">\r\n                    <div class=\"card-body\">\r\n                        <div>\r\n");
#nullable restore
#line 17 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
                             if (activity.Photo != null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
                           Write(Html.Raw("<img style='width:300px; height:300px;' src=\"data:image/jpeg;base64,"
                                + Convert.ToBase64String(activity.Photo) + "\" />"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
                                                                                   
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <h2 class=\"card-title text-center\">\r\n                            <a");
                BeginWriteAttribute("href", " href=\"", 849, "\"", 870, 1);
#nullable restore
#line 24 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
WriteAttributeValue("", 856, activity.Name, 856, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" target=_blank>");
#nullable restore
#line 24 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
                                                              Write(activity.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                        </h2>\r\n                        <div class=\"text-center\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d7596278ca781b1ade45904b2ca3b3f0a14f6f57931", async() => {
                    WriteLiteral("\r\n                                Посмотреть\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
                                                            WriteLiteral(activity.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 36 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ObservableCollection<Activity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
