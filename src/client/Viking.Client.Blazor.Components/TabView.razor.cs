using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Viking.Client.Blazor.Components.Shared;

namespace Viking.Client.Blazor.Components
{
    public partial class TabView : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string TabStyle { get; set; } = "nav nav-pills nav-fill";

        [Parameter]
        public string ContentStyle { get; set; } = "nav-tabs-body p-4";

        public ITab ActiveTab { get; private set; }

        public void AddTab(ITab tab)
        {
            if (ActiveTab == null)
            {
                SetActiveTab(tab);
            }
        }

        public void RemoveTab(ITab tab)
        {
            if (ActiveTab == tab)
            {
                SetActiveTab(null);
            }
        }

        public void SetActiveTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                StateHasChanged();
            }
        }
    }
}
