#pragma checksum "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f2ba4df593a003e4a64d739ccc532ca9238bbbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_First_IndexIdNull), @"mvc.1.0.view", @"/Views/First/IndexIdNull.cshtml")]
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
#nullable restore
#line 1 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f2ba4df593a003e4a64d739ccc532ca9238bbbc", @"/Views/First/IndexIdNull.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7448222f992620d65d1ac2eea9f77fc9487af16f", @"/Views/_ViewImports.cshtml")]
    public class Views_First_IndexIdNull : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<String>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
  
    ViewData["Title"] = ViewData["User2"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>User1: ");
#nullable restore
#line 8 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
      Write(base.ViewBag.User1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1 User2: ");
#nullable restore
#line 9 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
      Write(base.ViewData["User2"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("></h1>\r\n<h1>User3: ");
#nullable restore
#line 10 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
      Write(base.TempData["User3"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1>User4: ");
#nullable restore
#line 11 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
      Write(base.Context.Session.GetString("User4"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h1>User5: ");
#nullable restore
#line 12 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\IndexIdNull.cshtml"
      Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h1>\r\n<h1>Index</h1>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<String> Html { get; private set; }
    }
}
#pragma warning restore 1591
