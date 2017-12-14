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
        private ItineraryCompleteDetailsViewModel viewModel;
        private List<int> _totalTripDays;
        public Command NavigateNextDay { get; set; }
        public Command NavigatePreviousDay { get; set; }

        private string _tripTitle;

        public ItineraryCompleteDetails (ItineraryDailyBreakDown parentViewModel)
		{
			InitializeComponent ();
            NavigateNextDay = new Command<int>(async (model) => await NavigateNext(model));
            NavigatePreviousDay = new Command<int>(async (model) => await NavigatePrevious(model));

            var tripService = new Itinerary();
            _totalTripDays = tripService.GetItineraryDays(parentViewModel.TripId).Select(func=>func.ItineraryDayId).ToList();
            _tripTitle = parentViewModel.TripTitle;

            var triDayObject = tripService.GetItineraryDayDesc(parentViewModel.itineraryDayId);


            viewModel = new ItineraryCompleteDetailsViewModel();
            viewModel.DayNumber = parentViewModel.DayNumber.ToString();
            viewModel.DayDate = triDayObject.TimeOfDayId.ToString();
            viewModel.LocationName = $"{triDayObject.SourceName}-{triDayObject.DestName}";
            viewModel.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
            viewModel.CompleteDescription = triDayObject.Description;
            viewModel.Title = parentViewModel.TripTitle;

            BindingContext = viewModel;
        }

        public async Task NavigateNext(int nextOrPrevious)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {

                await Task.Run(() => NavigateNextOrPrevious(nextOrPrevious,true));

            }
            catch (Exception)
            {
                //
            }

            IsBusy = false;
        }

        public async Task NavigatePrevious(int nextOrPrevious)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {

                await Task.Run(() => NavigateNextOrPrevious(nextOrPrevious,false));

            }
            catch (Exception)
            {
                //
            }

            IsBusy = false;
        }

        private void NavigateNextOrPrevious(int currentDay,bool isNext)
        {
            var tripService = new Itinerary();
            var triDayObject = tripService.GetItineraryDayDesc(currentDay + 1);

            viewModel = new ItineraryCompleteDetailsViewModel();
            viewModel.DayNumber = (currentDay + 1).ToString();
            viewModel.DayDate = triDayObject.TimeOfDayId.ToString();
            viewModel.LocationName = $"{triDayObject.SourceName}-{triDayObject.DestName}";
            viewModel.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
            viewModel.CompleteDescription = triDayObject.Description;
            viewModel.Title = _tripTitle;

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