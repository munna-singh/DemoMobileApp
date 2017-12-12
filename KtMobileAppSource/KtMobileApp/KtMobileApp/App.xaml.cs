using System;

using KtMobileApp.Views;
using Xamarin.Forms;

namespace KtMobileApp
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());

            //var mainPage = new RootPage();
            //var itineraryListPage = new NavigationPage(new Itineraries()) { Title = "Trips" };
            //var itemsListPage = new NavigationPage(new ItemsPage()) { Title = "Todo" };
            //var aboutPage = new NavigationPage(new AboutPage()) { Title = "About" };
            //var itemsList = new NavigationPage(new ItemsPage()) { Title = "Todo" };

            //mainPage.Children.Add(itineraryListPage);
            //mainPage.Children.Add(itemsListPage);
            //mainPage.Children.Add(aboutPage);
            //mainPage.Children.Add(itemsListPage);

            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
