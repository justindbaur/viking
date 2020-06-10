using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Viking.Client.Blazor.Components.Shared;

namespace Viking.Client.Blazor.Components
{
    public partial class Tab : ComponentBase, ITab
    {
        [CascadingParameter]
        public TabView ContainerTabView { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private string TitleCssClass => ContainerTabView.ActiveTab == this ? "active" : null;

        protected override void OnInitialized()
        {
            ContainerTabView.AddTab(this);
        }

        private void Activate()
        {
            ContainerTabView.SetActiveTab(this);
        }
    }
}
