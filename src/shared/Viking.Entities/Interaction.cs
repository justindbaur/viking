using System;

namespace Viking.Entities
{
    public enum InteractionType : long
    {
        GoHome,
        OpenTracker,
        CloseTracker,
        OpenItem,
        CloseItem
    }

    public sealed class Interaction : EntityBase
    {
        public DateTime Time { get; set; }
        public InteractionType Type { get; set; }
        public string UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
