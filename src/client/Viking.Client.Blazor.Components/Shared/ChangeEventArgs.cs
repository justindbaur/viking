using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viking.Client.Blazor.Components.Shared
{
    public class ChangeEventArgs<T>
    {
        public ChangeEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public T OldValue { get; set; }

        public T NewValue { get; set; }
    }
}
