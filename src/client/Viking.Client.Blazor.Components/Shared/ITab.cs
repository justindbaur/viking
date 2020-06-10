using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Viking.Client.Blazor.Components.Shared
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
