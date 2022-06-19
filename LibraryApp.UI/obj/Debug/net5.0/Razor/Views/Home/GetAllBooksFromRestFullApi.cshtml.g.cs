#pragma checksum "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3174cf636455984a3065ed731dcc5418d25cbd82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetAllBooksFromRestFullApi), @"mvc.1.0.view", @"/Views/Home/GetAllBooksFromRestFullApi.cshtml")]
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
#line 1 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\_ViewImports.cshtml"
using LibraryApp.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\_ViewImports.cshtml"
using LibraryApp.UI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\_ViewImports.cshtml"
using LibraryApp.UI.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3174cf636455984a3065ed731dcc5418d25cbd82", @"/Views/Home/GetAllBooksFromRestFullApi.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3657eb5c3559e12db99059f353dd321ac06272c0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetAllBooksFromRestFullApi : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BookModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddBookToUserLibrary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"text-center\">\r\n        <h4 class=\"display-4\">Bütün Kitapların Listesi</h4>\r\n        <hr />\r\n    </div>\r\n\r\n<div class=\"row\">\r\n   \r\n");
#nullable restore
#line 10 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-4 my-4\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 368, "\"", 389, 1);
#nullable restore
#line 16 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
WriteAttributeValue("", 374, item.BookImage, 374, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" alt=\"...\">\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 18 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
                                  Write(item.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">Kitap hakkında kısmı eklenicek</p>\r\n            </div>\r\n            <ul class=\"list-group list-group-flush\">\r\n                <li class=\"list-group-item\">Güncel Stok adedi:");
#nullable restore
#line 22 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
                                                         Write(item.CurrentStock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\r\n            </ul>\r\n            <div class=\"card-body\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3174cf636455984a3065ed731dcc5418d25cbd826826", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"bookId\"");
                BeginWriteAttribute("value", " value=\"", 961, "\"", 981, 1);
#nullable restore
#line 27 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
WriteAttributeValue("", 969, item.BookId, 969, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <input type=\"submit\" class=\"btn btn-primary\" value=\"Ekle\" />\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\recep\OneDrive\Masaüstü\LibraryApp\LibraryApp.UI\Views\Home\GetAllBooksFromRestFullApi.cshtml"
             


        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    \r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BookModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
