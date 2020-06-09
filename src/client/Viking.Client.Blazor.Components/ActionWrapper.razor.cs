using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Client.Blazor.Components
{
    public partial class ActionWrapper : ComponentBase
    {
        [Parameter] 
        public RenderFragment ChildContent { get; set; }

        [Parameter] 
        public Action OnClick { get; set; }

        [Parameter] 
        public Action OnDoubleClick { get; set; }
        [Parameter] 
        public Action OnRightClick { get; set; }

        [Parameter] 
        public int Timeout { get; set; } = 300;


        private int clickCount;

        private async Task InternalClickEvent(MouseEventArgs args)
        {
            clickCount++;

            if (clickCount == 2)
            {
                clickCount = 0;
                OnDoubleClick?.Invoke();
            }
            else
            {
                // TODO: Validate that this will always do what I want it to do
                await Task.Delay(Timeout).ContinueWith((task) =>
                {
                    clickCount = 0;
                    OnClick?.Invoke();
                });
            }
        }

        private void InternalMouseUpEvent(MouseEventArgs args)
        {
            if (args.Button == 2)
            {
                OnRightClick?.Invoke();
            }
        }
    }
}
