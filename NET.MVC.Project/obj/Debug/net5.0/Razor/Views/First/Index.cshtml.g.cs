#pragma checksum "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4aef480ccaadf9e6ea7c27d3745d491af7ad29bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_First_Index), @"mvc.1.0.view", @"/Views/First/Index.cshtml")]
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
#line 1 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\_ViewImports.cshtml"
using NET.MVC.Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\_ViewImports.cshtml"
using NET.MVC.Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4aef480ccaadf9e6ea7c27d3745d491af7ad29bc", @"/Views/First/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7448222f992620d65d1ac2eea9f77fc9487af16f", @"/Views/_ViewImports.cshtml")]
    public class Views_First_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Image/liuyan.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" PeopleModel\r\n");
#nullable restore
#line 2 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
  
    ViewData["Title"] = "FirtPage";
    PeopleModel currentPeople = (PeopleModel)ViewData["CurrentUser"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<h1>Index First</h1>\r\n\r\n<h2>User1-viewBag: ");
#nullable restore
#line 10 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
              Write(ViewBag.CurrentUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h2>User2-ViewData: ");
#nullable restore
#line 11 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
               Write(currentPeople.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<h3>user3-model: ");
#nullable restore
#line 12 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n<h3>user3-tempData: ");
#nullable restore
#line 13 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
                Write((PeopleModel)TempData["CurrentUser"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(".Name</h3>\r\n\r\n");
#nullable restore
#line 15 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
  Html.RenderPartial("PartialPage", "kulala");

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
#nullable restore
#line 16 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
Write(Html.Partial("PartialPage", currentPeople));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n<br/>\r\n\r\n");
#nullable restore
#line 20 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
 foreach(var item in Model.Likes)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>");
#nullable restore
#line 22 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 23 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4aef480ccaadf9e6ea7c27d3745d491af7ad29bc5987", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n</div>\r\n");
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
