using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Splash_Screen.Resources;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace Splash_Screen
{
    public partial class MainPage : PhoneApplicationPage
    {
        BackgroundWorker BackgroundWork;

        Popup pop;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            pop = new Popup();

            pop.IsOpen = true;

            pop.Child = new SplashScreen();



            StartProcess();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private void StartProcess()

        {
            BackgroundWork = new BackgroundWorker();
            BackgroundWork.RunWorkerCompleted += ((r, args) => { this.Dispatcher.BeginInvoke(() => { this.pop.IsOpen = false; }); });

            BackgroundWork.DoWork += ((r, args) => { Thread.Sleep(5000); });

            BackgroundWork.RunWorkerAsync();


        }


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}