#pragma checksum "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa40e4b02f5d52deabd9b24ab8f5cd35d221be1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_WatchActivity), @"mvc.1.0.view", @"/Views/Activity/WatchActivity.cshtml")]
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
#line 1 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
using Core.ado;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
using Core.Classes_Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa40e4b02f5d52deabd9b24ab8f5cd35d221be1e", @"/Views/Activity/WatchActivity.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58ece859d7712c939f85faad04f6116f89b5668e", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_WatchActivity : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Activity>
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
#line 3 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
   
    ViewData["Title"] = "Activity";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 13 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
 using (Html.BeginForm("WatchActivity", "Activity", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<fieldset>\r\n    ");
#nullable restore
#line 16 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
Write(Html.HiddenFor(a => a.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <p>\r\n        ");
#nullable restore
#line 18 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
   Write(Html.LabelFor(a => a.Name, "Название"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br>\r\n        ");
#nullable restore
#line 20 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
   Write(Html.EditorFor(a => a.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        ");
#nullable restore
#line 23 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
   Write(Html.LabelFor(a => a.Price, "Цена"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br>\r\n        ");
#nullable restore
#line 25 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
   Write(Html.EditorFor(a => a.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n\r\n        \r\n\r\n    </p>\r\n   \r\n</fieldset>\r\n");
#nullable restore
#line 34 "C:\Users\ИМЕННО ОН\Desktop\крусач\LEISURE\WebLeisure\Views\Activity\WatchActivity.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa40e4b02f5d52deabd9b24ab8f5cd35d221be1e6679", async() => {
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
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Activity> Html { get; private set; }
    }
}
#pragma warning restore 1591
