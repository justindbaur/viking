using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Viking.Client.App.Dialogs;
using Viking.Client.App.Views;
using Viking.Client.App.Views.Config;
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

        public async Task DisplayBugReport(BugReport bugReport)
        {
            var bugReportDialog = new BugReportDialog(bugReport);
            await bugReportDialog.ShowAsync();
        }

        private async void AppNavigation_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                // TODO: Go to settings
                contentFrame.Navigate(typeof(SettingsPage));
                return;
            }
            else if (args.SelectedItem is Microsoft.UI.Xaml.Controls.NavigationViewItem navItem)
            {
                string tag = navItem.Tag.ToString();

                if (tag == "Home")
                {
                    // Go home
                    contentFrame.Navigate(typeof(HomePage));
                }
                else
                {
                    // Do internal lookup
                    // TODO: Do something more scalable than this
                    switch (tag)
                    {
                        case "PurchaseOrder":
                            contentFrame.Navigate(typeof(PurchaseOrderPage));
                            break;
                        case "CompanyConfig":
                            contentFrame.Navigate(typeof(CompanyConfigPage));
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // Create Bug Report dialog
                await DisplayBugReport(new BugReport { Message = "Navigation View is not setup properly." });
            }
        }
    }
}
