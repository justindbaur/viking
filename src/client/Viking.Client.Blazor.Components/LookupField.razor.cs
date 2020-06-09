using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Client.Blazor.Components
{
    public partial class LookupField<TValue> : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        [Parameter]
        public TValue Value { get; set; }

        public async Task Search_Click()
        {
            // TODO: Do a search thing
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(100);
            });
        }
    }
}
