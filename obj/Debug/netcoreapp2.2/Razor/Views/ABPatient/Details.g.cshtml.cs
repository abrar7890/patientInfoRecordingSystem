#pragma checksum "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54fb4ffd093b918a3a7dcf233febad3879a9459d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ABPatient_Details), @"mvc.1.0.view", @"/Views/ABPatient/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ABPatient/Details.cshtml", typeof(AspNetCore.Views_ABPatient_Details))]
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
#line 1 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\_ViewImports.cshtml"
using ABPatients;

#line default
#line hidden
#line 2 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\_ViewImports.cshtml"
using ABPatients.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54fb4ffd093b918a3a7dcf233febad3879a9459d", @"/Views/ABPatient/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7097be616f1c5cf1212c4a76ef3dcf132cd85eb5", @"/Views/_ViewImports.cshtml")]
    public class Views_ABPatient_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ABPatients.Models.Patient>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(104, 130, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Patient</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(235, 45, false);
#line 15 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(280, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(344, 41, false);
#line 18 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(385, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(448, 44, false);
#line 21 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(492, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(556, 40, false);
#line 24 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(596, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(659, 43, false);
#line 27 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(702, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(766, 39, false);
#line 30 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
            EndContext();
            BeginContext(805, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(868, 40, false);
#line 33 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(908, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(972, 36, false);
#line 36 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1071, 46, false);
#line 39 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1181, 42, false);
#line 42 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.PostalCode));

#line default
#line hidden
            EndContext();
            BeginContext(1223, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1286, 40, false);
#line 45 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ohip));

#line default
#line hidden
            EndContext();
            BeginContext(1326, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1390, 36, false);
#line 48 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ohip));

#line default
#line hidden
            EndContext();
            BeginContext(1426, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1489, 47, false);
#line 51 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(1536, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1600, 43, false);
#line 54 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateOfBirth));

#line default
#line hidden
            EndContext();
            BeginContext(1643, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1706, 44, false);
#line 57 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Deceased));

#line default
#line hidden
            EndContext();
            BeginContext(1750, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1814, 40, false);
#line 60 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.Deceased));

#line default
#line hidden
            EndContext();
            BeginContext(1854, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1917, 47, false);
#line 63 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfDeath));

#line default
#line hidden
            EndContext();
            BeginContext(1964, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2028, 43, false);
#line 66 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateOfDeath));

#line default
#line hidden
            EndContext();
            BeginContext(2071, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2134, 45, false);
#line 69 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomePhone));

#line default
#line hidden
            EndContext();
            BeginContext(2179, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2243, 41, false);
#line 72 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomePhone));

#line default
#line hidden
            EndContext();
            BeginContext(2284, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2347, 42, false);
#line 75 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(2389, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2453, 38, false);
#line 78 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
            EndContext();
            BeginContext(2491, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2554, 58, false);
#line 81 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ProvinceCodeNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(2612, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2676, 67, false);
#line 84 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
       Write(Html.DisplayFor(model => model.ProvinceCodeNavigation.ProvinceCode));

#line default
#line hidden
            EndContext();
            BeginContext(2743, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2790, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54fb4ffd093b918a3a7dcf233febad3879a9459d14708", async() => {
                BeginContext(2843, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 89 "C:\Users\arshd\Downloads\ABPatients\ABPatients\ABPatients\Views\ABPatient\Details.cshtml"
                           WriteLiteral(Model.PatientId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2851, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2859, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54fb4ffd093b918a3a7dcf233febad3879a9459d17046", async() => {
                BeginContext(2881, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2897, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ABPatients.Models.Patient> Html { get; private set; }
    }
}
#pragma warning restore 1591
