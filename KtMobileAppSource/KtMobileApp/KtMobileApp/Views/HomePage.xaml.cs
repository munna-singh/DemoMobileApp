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

            viewModel.LocationImagePath = "KtMobileApp.Assets.Images.Location_128_128.png";
            viewModel.WeatherImagePath = "KtMobileApp.Assets.Images.cloud.png";
            viewModel.BackImagePath = "KtMobileApp.Assets.Images.Taj-Mahal.jpg";
            viewModel.CurrentLocation = "India";

            BindingContext = viewModel;

        }
	}
}