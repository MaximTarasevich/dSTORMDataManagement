#pragma checksum "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00f2d5c39b4fc40c4b15eaa193895877d82d10cc"
// <auto-generated/>
#pragma warning disable 1591
namespace dSTORMWeb.Client.Pages.Lists
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client.Shared.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/_Imports.razor"
using dSTORMWeb.Client.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/objectives")]
    public partial class Objectives : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __Blazor.dSTORMWeb.Client.Pages.Lists.Objectives.TypeInference.CreateDataGrid_0(__builder, 0, 1, 
#nullable restore
#line 6 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                    25

#line default
#line hidden
#nullable disable
            , 2, "api/objective/GetObjectives", 3, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 8 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                         (RecordDoubleClickEventArgs<ObjectiveViewModel> ev) => { RecordDoubleClickHandler(ev); }

#line default
#line hidden
#nullable disable
            ), 4, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Navigations.ClickEventArgs>(this, 
#nullable restore
#line 9 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                ToolbarClickHandler

#line default
#line hidden
#nullable disable
            ), 5, 
#nullable restore
#line 10 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                         ToolbarItems

#line default
#line hidden
#nullable disable
            , 6, (__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Grids.GridColumns>(7);
                __builder2.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(9);
                    __builder3.AddAttribute(10, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.Name)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(11, "HeaderText", "Name");
                    __builder3.AddAttribute(12, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 13 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                              TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(13, "Width", "100");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(14, "\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(15);
                    __builder3.AddAttribute(16, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.Resolution)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(17, "HeaderText", "Resolution");
                    __builder3.AddAttribute(18, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 14 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                                          TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "Width", "50");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(20, "\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(21);
                    __builder3.AddAttribute(22, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 15 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.Magnification)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(23, "HeaderText", "Magnification");
                    __builder3.AddAttribute(24, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 15 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                                                TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(25, "Width", "50");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(27);
                    __builder3.AddAttribute(28, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.EyePiece)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(29, "HeaderText", "EyePiece");
                    __builder3.AddAttribute(30, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 16 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                                      TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(31, "Width", "100");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(32, "\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(33);
                    __builder3.AddAttribute(34, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 17 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.ObjectiveLens)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(35, "HeaderText", "ObjectiveLens");
                    __builder3.AddAttribute(36, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 17 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                                                TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(37, "Width", "100");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(38, "\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Grids.GridColumn>(39);
                    __builder3.AddAttribute(40, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 18 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                nameof(ObjectiveViewModel.Description)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(41, "HeaderText", "Description");
                    __builder3.AddAttribute(42, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Syncfusion.Blazor.Grids.TextAlign>(
#nullable restore
#line 18 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                                                                                                            TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(43, "Width", "100");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            , 44, (__value) => {
#nullable restore
#line 6 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
                BaseGrid = __value;

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Pages/Lists/Objectives.razor"
 

    DataGrid<ObjectiveViewModel> BaseGrid;
    public List<object> ToolbarItems;
    protected override async Task OnInitializedAsync()
    {

        ToolbarItems = new List<object> {
            new ItemModel() { Text = "Add", TooltipText = "Add", PrefixIcon = "e-add", Id = "Add" },
            new ItemModel() { Text = "Refresh", TooltipText = "Refresh", PrefixIcon = "e-refresh", Id = "Refresh" }
                                                        };


    }

    private void RecordDoubleClickHandler(RecordDoubleClickEventArgs<ObjectiveViewModel>
    args)
    {
        var id = args.RowData.Id;
        if (id > 0)
            nM.NavigateTo("objective/" + id);
    }
    private void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Refresh")
        {
            BaseGrid.Refresh();
        }
        if (args.Item.Id == "Add")
        {
            nM.NavigateTo("/objective");
        }
    }
    private void onChange(CallBackObj obj)
    {
        this.BaseGrid.FilterByColumn(obj.FieldName, "equal", obj.FieldValue);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nM { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HTTPService service { get; set; }
    }
}
namespace __Blazor.dSTORMWeb.Client.Pages.Lists.Objectives
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateDataGrid_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Int32 __arg0, int __seq1, global::System.String __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<global::Syncfusion.Blazor.Grids.RecordDoubleClickEventArgs<T>> __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<global::Syncfusion.Blazor.Navigations.ClickEventArgs> __arg3, int __seq4, global::System.Collections.Generic.List<global::System.Object> __arg4, int __seq5, global::Microsoft.AspNetCore.Components.RenderFragment __arg5, int __seq6, global::System.Action<global::dSTORMWeb.Client.Shared.Components.DataGrid<T>> __arg6)
        {
        __builder.OpenComponent<global::dSTORMWeb.Client.Shared.Components.DataGrid<T>>(seq);
        __builder.AddAttribute(__seq0, "PageSize", __arg0);
        __builder.AddAttribute(__seq1, "URL", __arg1);
        __builder.AddAttribute(__seq2, "doubleClick", __arg2);
        __builder.AddAttribute(__seq3, "ToolbarClickHandler", __arg3);
        __builder.AddAttribute(__seq4, "ToolbarItems", __arg4);
        __builder.AddAttribute(__seq5, "Columns", __arg5);
        __builder.AddComponentReferenceCapture(__seq6, (__value) => { __arg6((global::dSTORMWeb.Client.Shared.Components.DataGrid<T>)__value); });
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
