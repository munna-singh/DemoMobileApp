using KT.BusinessLayer;
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
        private ItineraryDayViewModel viewModel;
        private List<int> _totalTripDays;
       

        private string _tripTitle;

        public ItineraryCompleteDetails (ItineraryDailyBreakDown parentViewModel)
		{
			InitializeComponent ();
           

            var tripService = new Itinerary();
            _totalTripDays = tripService.GetItineraryDays(parentViewModel.TripId).Select(func=>func.ItineraryDayId).ToList();
            _tripTitle = parentViewModel.TripTitle;

            var triDayObject = tripService.GetItineraryDayDesc(parentViewModel.itineraryDayId);


            viewModel = new ItineraryDayViewModel();
            viewModel.DayCompleteDetails = viewModel.GetitinerayCompleteDesc(triDayObject);
            viewModel.DayCompleteDetails.DayNumber = parentViewModel.DayNumber.ToString();

            //viewModel.DayNumber = parentViewModel.DayNumber.ToString();
            //viewModel.DayDate = triDayObject.TimeOfDayId.ToString();
            //viewModel.LocationName = $"{triDayObject.SourceName}-{triDayObject.DestName}";
            //viewModel.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
            //viewModel.CompleteDescription = triDayObject.Description;
            viewModel.Title = parentViewModel.TripTitle;

            BindingContext = viewModel;
        }
        

        protected override void OnAppearing()
        {
            //var master=this.pare
            //this.ParentView = MainPage;
            base.OnAppearing();
        }
    }
}