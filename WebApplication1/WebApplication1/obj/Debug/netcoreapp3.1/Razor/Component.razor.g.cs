#pragma checksum "D:\Teradyne\RazorPagesSample\WebApplication1\WebApplication1\Component.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eb377af93ab54cca018150e6a0a47ac8e3000c5"
// <auto-generated/>
#pragma warning disable 1591
namespace WebApplication1
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    public partial class Component : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddContent(1, 
#nullable restore
#line 1 "D:\Teradyne\RazorPagesSample\WebApplication1\WebApplication1\Component.razor"
     Text

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(2, " : ");
            __builder.AddContent(3, 
#nullable restore
#line 1 "D:\Teradyne\RazorPagesSample\WebApplication1\WebApplication1\Component.razor"
             counter

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 3 "D:\Teradyne\RazorPagesSample\WebApplication1\WebApplication1\Component.razor"
       

    [Parameter]
    public string Text { get; set; }

    static int counter = 0;

    protected override void OnInitialized()
    {
        counter++;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
