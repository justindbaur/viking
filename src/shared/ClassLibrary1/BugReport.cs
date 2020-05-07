using System;

namespace Viking.Common
{
    public class BugReport
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
