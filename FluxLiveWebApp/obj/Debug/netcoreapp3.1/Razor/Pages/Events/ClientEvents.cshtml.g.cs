#pragma checksum "D:\Flux\app\web\FluxLiveWebApp\Pages\Events\ClientEvents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcdc53ea8e94f6feda176c452c4e22fc8e810184"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(FluxLiveWebApp.Pages.Events.Pages_Events_ClientEvents), @"mvc.1.0.razor-page", @"/Pages/Events/ClientEvents.cshtml")]
namespace FluxLiveWebApp.Pages.Events
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
#line 1 "D:\Flux\app\web\FluxLiveWebApp\Pages\_ViewImports.cshtml"
using FluxLiveWebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcdc53ea8e94f6feda176c452c4e22fc8e810184", @"/Pages/Events/ClientEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0581e86765fcfe4cb2b54573adda220a1cd387a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Events_ClientEvents : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(function () {\r\n            $.ajax(\"/api/events/\",\r\n                { method: \"get\" })\r\n                .then(function (response) {\r\n                    console.dir(response)\r\n            }\r\n        );\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FluxLiveWebApp.Pages.Events.ClientEventsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FluxLiveWebApp.Pages.Events.ClientEventsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<FluxLiveWebApp.Pages.Events.ClientEventsModel>)PageContext?.ViewData;
        public FluxLiveWebApp.Pages.Events.ClientEventsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
