#pragma checksum "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fbf4f8469cedbc701d67753ab3ccd712a728c71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Review_Detail), @"mvc.1.0.view", @"/Views/Review/Detail.cshtml")]
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
#line 1 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\_ViewImports.cshtml"
using ProductReviewAuthentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\_ViewImports.cshtml"
using ProductReviewAuthentication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fbf4f8469cedbc701d67753ab3ccd712a728c71", @"/Views/Review/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e024d9fbb9212e11223a5f77979546b320404a3c", @"/Views/_ViewImports.cshtml")]
    public class Views_Review_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Review>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
  
    Layout = "_DashBoardLayout";
    ViewData["Title"] = "Review Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<ul>\r\n    <li>Id: ");
#nullable restore
#line 9 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
       Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Manufacturer: ");
#nullable restore
#line 10 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
                 Write(ViewBag.userName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Created At: ");
#nullable restore
#line 11 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
               Write(Model.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Product Name: ");
#nullable restore
#line 12 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
                 Write(Model.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Comment: ");
#nullable restore
#line 13 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
            Write(Model.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Ratings: ");
#nullable restore
#line 14 "C:\Users\Favour .O\Desktop\csharp\ProductReviewAuthentication\Views\Review\Detail.cshtml"
            Write(Model.Ratings);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n</ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Review> Html { get; private set; }
    }
}
#pragma warning restore 1591
