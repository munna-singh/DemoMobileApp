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
	public partial class Itineraries : ContentPage
	{
        ItinerariesViewModel viewModel;

        public Itineraries ()
		{
			InitializeComponent ();

            viewModel = new ItinerariesViewModel(Navigation);
            viewModel.PastTripsBackCoverImagePath = "KtMobileApp.Assets.Images.PastTrips_BackCover_16_128_128.png";
            viewModel.MenuAddItineraryImagePath = "KtMobileApp.Assets.Images.Plus_32_32.png";
            viewModel.MenuHomeImagePath = "KtMobileApp.Assets.Images.Home_white_32_32.png";
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.ItineraryList.Count == 0)
                viewModel.LoadItineraryCommand.Execute(null);
        }
    }
}