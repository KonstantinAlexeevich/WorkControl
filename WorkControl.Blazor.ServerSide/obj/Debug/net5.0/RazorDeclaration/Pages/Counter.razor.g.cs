// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace WorkControl.Blazor.ServerSide.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using WorkControl.Blazor.ServerSide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using WorkControl.Blazor.ServerSide.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using EventFlow;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using WorkControl.Domain.Work;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\_Imports.razor"
using WorkControl.Domain.Work.Commands;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/counter")]
    public partial class Counter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Projects\KonstantinAlexeevich\WorkControl\WorkControl.Blazor.ServerSide\Pages\Counter.razor"
       

    [Inject]
    public ICommandBus CommandBus { get; set; }

    private int currentCount;

    private async Task IncrementCount()
    {
        await CommandBus.PublishAsync(new RenameCommand(new WorkId(1), "Rename"), CancellationToken.None);
        currentCount++;
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591