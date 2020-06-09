using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Client.Blazor.Components
{
    public partial class Modal : ComponentBase
    {
        [Parameter] public bool Visible { get; set; } = true;
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
