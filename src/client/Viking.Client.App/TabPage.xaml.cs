using Microsoft.Toolkit.Uwp.UI.Controls;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TabView = Microsoft.UI.Xaml.Controls.TabView;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Viking.Client.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TabPage : Page
    {
        public TabPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;

            Window.Current.SetTitleBar(CustomDragRegion);
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (FlowDirection == FlowDirection.LeftToRight)
            {
                CustomDragRegion.MinWidth = sender.SystemOverlayRightInset;
                ShellTitlebarInset.MinWidth = sender.SystemOverlayLeftInset;
            }
            else
            {
                CustomDragRegion.MinWidth = sender.SystemOverlayRightInset;
                ShellTitlebarInset.MinWidth = sender.SystemOverlayLeftInset;
            }

            CustomDragRegion.Height = ShellTitlebarInset.Height = sender.Height;
        }

        private void MainTabView_AddTabButtonClick(TabView sender, object args)
        {
            sender.TabItems.Add(CreateDefaultTab());
        }

        private void MainTabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
        }

        private void MainTabView_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: Check for cached tabs

            (sender as TabView).TabItems.Add(CreateDefaultTab());
        }

        private Microsoft.UI.Xaml.Controls.TabViewItem CreateDefaultTab()
        {
            Frame frame = new Frame();
            frame.Navigate(typeof(MainPage));

            var tabViewItem = new Microsoft.UI.Xaml.Controls.TabViewItem
            {
                Header = "Home",
                IconSource = new Microsoft.UI.Xaml.Controls.SymbolIconSource { Symbol = Symbol.Home },
                Content = frame,
            };

            return tabViewItem;
        }

        private void MainTabView_TabDroppedOutside(TabView sender, TabViewTabDroppedOutsideEventArgs args)
        {

        }

        private void MainTabView_TabStripDragOver(object sender, DragEventArgs e)
        {

        }

        private void MainTabView_TabStripDrop(object sender, DragEventArgs e)
        {

        }

        private void MainTabView_TabDragStarting(TabView sender, TabViewTabDragStartingEventArgs args)
        {

        }

        private void MainTabView_TabItemsChanged(TabView sender, IVectorChangedEventArgs args)
        {

        }
    }
}
