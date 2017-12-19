using KT.BusinessLayer;
using KtMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KtMobileApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        HomePageViewModel viewModel;


        public HomePage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            viewModel = new HomePageViewModel();
            Title = "Home";
			viewModel.LocationImagePath = "KtMobileApp.Assets.Images.locationWhite.png";
			viewModel.WeatherImagePath = "KtMobileApp.Assets.Images.WeatherCloud.png";
			viewModel.BackImagePath = "TajMahal.jpg";
			viewModel.CurrentLocation = "AGRA";
			viewModel.Country = "India";

			BindingContext = viewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Start fetching async weather api.
            viewModel.GetUpdatedWeather();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}