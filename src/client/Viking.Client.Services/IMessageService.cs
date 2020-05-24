using System;
using System.Collections.Generic;
using System.Text;
using Viking.Common;

namespace Viking.Client.Services
{
    public interface IMessageService
    {
        void ShowInfo(string message);
        void ShowAlert(string message);
        void ShowBugReport(BugReport bugReport);
    }
}
