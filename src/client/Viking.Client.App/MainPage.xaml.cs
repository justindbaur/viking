using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Viking.Client.App.Dialogs;
using Viking.Client.App.Views;
using Viking.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Viking.Client.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AppNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // TODO: Go to settings
                contentFrame.Navigate(typeof(SettingsPage));
                return;
            }
            else if (args.SelectedItem is NavigationViewItem navItem)
            {
                if (navItem.Tag.ToString() == "Home")
                {
                    // Go home
                    contentFrame.Navigate(typeof(HomePage));
                }
                else
                {
                    // Do internal lookup

                }
            }
            else
            {
                // Create Bug Report dialog
                await DisplayBugReport(new BugReport { Message = "Navigation View is not setup properly." });
            }
        }

        public async Task DisplayBugReport(BugReport bugReport)
        {
            var bugReportDialog = new BugReportDialog(bugReport);
            await bugReportDialog.ShowAsync();
        }
    }
}
