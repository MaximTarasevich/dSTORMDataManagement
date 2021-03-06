// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace dSTORMWeb.Client.Shared.Components
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
#line 1 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Shared/Components/DataGrid.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Shared/Components/DataGrid.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Shared/Components/DataGrid.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Shared/Components/DataGrid.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
    public partial class DataGrid<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "/Users/maxim/Documents/dSTORMWeb/dSTORMWeb/dSTORMWeb/Client/Shared/Components/DataGrid.razor"
       
    [Parameter]
    public Query GridQuery { get; set; }
    [Parameter]
    public RenderFragment Columns { get; set; }
    [Parameter]
    public List<object> ToolbarItems { get; set; }
    [Parameter]
    public string URL { get; set; }
    [Parameter]
    public string Width { get; set; } = "100%";
    [Parameter]
    public int PageSize { get; set; }
    [Parameter]
    public string Height { get; set; } = "calc(100vh - 200px)";
    [Parameter]
    public bool AllowPaging { get; set; } = true;
    [Parameter]
    public bool AllowSorting { get; set; } = true;
    [Parameter]
    public bool AllowFiltering { get; set; } = true;
    [Parameter]
    public bool AllowResizing { get; set; } = true;
    [Parameter]
    public List<GridColumn> GridColumns { get; set; } = new List<GridColumn>();
    [Parameter]
    public bool EnableVirtualization { get; set; } = false;
    [Parameter]
    public EventCallback<RecordDoubleClickEventArgs<T>> doubleClick { get; set; }
    [Parameter]
    public EventCallback<ClickEventArgs> ToolbarClickHandler { get; set; }
    SfGrid<T> Grid;
    private IDictionary<string, string> HeaderData = new Dictionary<string, string>();

    protected override async Task OnInitializedAsync()
    {
    }
    public void BtnEnable(List<string> toolbarItems, bool IsEnable)
    {
        this.Grid.EnableToolbarItems(toolbarItems, IsEnable);
    }
    public void Refresh()
    {
        this.Grid.Refresh();
    }

    public void UpdateGridQuery(Query q)
    {
        this.GridQuery = q;
        this.StateHasChanged();
    }
    public void ActionBeginHandler(ActionEventArgs<T> args)
    {
        if (args.CurrentFilterObject != null)
        {
            var columnName = args.CurrentFilteringColumn;
            var columnValue = args.CurrentFilterObject?.Value;

            if (!string.IsNullOrWhiteSpace(columnName))
            {
                if (this.GridQuery == null)
                {
                    this.GridQuery = new Query().AddParams(columnName.ToLower(), columnValue);
                }
                else
                {
                    this.GridQuery.AddParams(columnName.ToLower(), columnValue);
                }
            }
            else
            {
                this.GridQuery.Queries.Params.Remove(args.CurrentFilterObject.Field.ToLower());
            }

            if (columnValue is string)
            {
                if ((string)columnValue == "All")
                    this.GridQuery.Queries.Params.Remove(args.CurrentFilterObject.Field.ToLower());
            }


        }
        this.StateHasChanged();
    }
    public void FilterByColumn(string field, string oper, object val)
    {
        this.Grid.FilterByColumn(field, oper, val);
        this.StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nM { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HTTPService service { get; set; }
    }
}
#pragma warning restore 1591
