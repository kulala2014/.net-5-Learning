#pragma checksum "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\PartialPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "532beff42c8f28c64adaf80505c50fb843634f7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_First_PartialPage), @"mvc.1.0.view", @"/Views/First/PartialPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"532beff42c8f28c64adaf80505c50fb843634f7c", @"/Views/First/PartialPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7448222f992620d65d1ac2eea9f77fc9487af16f", @"/Views/_ViewImports.cshtml")]
    public class Views_First_PartialPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1>This is partial page</h1>\r\n<h2>this value is from parantePage ");
#nullable restore
#line 4 "D:\Github\DoNET5Learning\NET.MVC.Project\Views\First\PartialPage.cshtml"
                              Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
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
