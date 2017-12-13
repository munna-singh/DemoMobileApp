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
			InitializeComponent ();
            viewModel = new HomePageViewModel();

			viewModel.LocationImagePath = "KtMobileApp.Assets.Images.locationWhite.png";
			viewModel.WeatherImagePath = "KtMobileApp.Assets.Images.WeatherCloud.png";
			viewModel.BackImagePath = "TajMahal.jpg";
			viewModel.CurrentLocation = "AGRA";
			viewModel.Country = "India";
			BindingContext = viewModel;

			BindingContext = viewModel;

        }
	}
}