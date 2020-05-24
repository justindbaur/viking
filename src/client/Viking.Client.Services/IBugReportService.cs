using System;
using System.Collections.Generic;
using System.Text;
using Viking.Common;

namespace Viking.Client.Services
{
    public interface IBugReportService
    {
        BugReport CollectBugReport();
    }
}
