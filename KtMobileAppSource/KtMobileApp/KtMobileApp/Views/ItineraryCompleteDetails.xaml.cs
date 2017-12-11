using KtMobileApp.Models;
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
	public partial class ItineraryCompleteDetails : ContentPage
	{
        private ItineraryCompleteDetailsViewModel viewModel;
        public ItineraryCompleteDetails (ItineraryDailyBreakDown parentViewModel)
		{
			InitializeComponent ();

            viewModel = new ItineraryCompleteDetailsViewModel();
            viewModel.DayNumber = parentViewModel.DayNumber;
            viewModel.DayDate = parentViewModel.TripDayDate;
            viewModel.LocationName = parentViewModel.Location;
            viewModel.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
            viewModel.CompleteDescription = parentViewModel.ItineraryDayDescription;



            BindingContext = viewModel;
        }
	}
}