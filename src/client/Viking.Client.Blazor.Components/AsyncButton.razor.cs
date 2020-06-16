using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Client.Blazor.Components
{
    public partial class AsyncButton : ComponentBase
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public Func<MouseEventArgs, Task> OnClick { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> Attributes { get; set; }

        [Parameter]
        public string LoadingText { get; set; } = "Loading...";

        private bool isActionRunning;
        
        private async Task InternalOnClick(MouseEventArgs e)
        {
            // TODO: Switch button to loading stuff
            isActionRunning = true;

            await OnClick?.Invoke(e);

            // TODO: Turn off loading stuff
            isActionRunning = false;
        }
    }
}
