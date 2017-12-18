using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KtMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var HomePage = new NavigationPage(new Itineraries());
            var HomePage = new HomePage();
            HomePage.Icon = "Home_64_64.png";
            HomePage.Title = "Home";
            NavigationPage.SetHasNavigationBar(this, false);

            var itineraries = new NavigationPage(new Itineraries());
            
            //var itineraries = new Itineraries();
            itineraries.Icon = "trip_64_64.png";
            itineraries.Title = "Itinerary";

            //var HomePage = new NavigationPage(new Itineraries());
            var MapPage = new AboutPage();
            MapPage.Icon = "Map_64_64.png";
            MapPage.Title = "Map";

            var SettingPage = new NavigationPage(new ItemsPage());
            //var SettingPage = new ItemsPage();
            SettingPage.Icon = "Settings_64_64.png";
            SettingPage.Title = "Setting";

            Children.Add(HomePage);
            Children.Add(itineraries);
            Children.Add(MapPage);
            Children.Add(SettingPage);
        }
    }
}