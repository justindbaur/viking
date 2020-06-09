using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Viking.Client.Blazor.Components.Shared;

namespace Viking.Client.Blazor.Components
{
    public partial class DropDownList<TItem, TValue> : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)] 
        public Dictionary<string, object> Attributes { get; set; }

        [Parameter] 
        public string DefaultText { get; set; } = "Choose...";
        [Parameter] 
        public Func<TItem, string> DisplayPath { get; set; }

        [Parameter] 
        public Func<TItem, TValue> ValuePath { get; set; }

        [Parameter] 
        public Func<IEnumerable<TItem>> ItemSource { get; set; }

        [Parameter] 
        public EventCallback<ChangeEventArgs<TValue>> SelectionChanged { get; set; }


        private TValue _value;

        [Parameter]
        public TValue Value
        {
            get => _value;
            set
            {
                var changeArgs = new ChangeEventArgs<TValue>(_value, value);
                _value = value;
                SelectionChanged.InvokeAsync(changeArgs);
            }
        }

        private IEnumerable<TItem> items;

        protected override void OnInitialized()
        {
            items = ItemSource?.Invoke() ?? new List<TItem>();
        }
    }
}
