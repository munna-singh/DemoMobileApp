using KT.BusinessLayer;
using KT.DAL.Models;
using KtMobileApp.Models;
using KtMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ItinerariesViewModel : BaseViewModel
    {
        public ObservableCollection<ItineraryViewModel> ItineraryList { get; set; }
        public Command LoadItineraryCommand { get; set; }
        public Command ImportItineraryScreen { get; set; }

        private INavigation _navigation;

        public string Description { get; set; }
        public string DetailId { get; set; }
        public string PastTripsBackCoverImagePath { get; set; }
        public ImageSource PastItinerariesBackImageSource
        {
            get
            {
                return ImageSource.FromResource(PastTripsBackCoverImagePath);
            }
        }

        public string MenuAddItineraryImagePath { get; set; }
        public ImageSource MenuAddItineraryImageSource
        {
            get
            {
                return ImageSource.FromResource(MenuAddItineraryImagePath);
            }
        }

        public string MenuHomeImagePath { get; set; }
        public ImageSource MenuHomeImageSource
        {
            get
            {
                return ImageSource.FromResource(MenuHomeImagePath);
            }
        }


        public ItinerariesViewModel(INavigation MainPageNavigation)
        {
            _navigation = MainPageNavigation;
            Title = "Trips";
            ItineraryList = new ObservableCollection<ItineraryViewModel>();
            LoadItineraryCommand = new Command(() => ExecuteLoadItemsCommand());
            ImportItineraryScreen = new Command(async () => await OpenPage());
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //ItineraryDailyBreakDown.Clear();
                KT.BusinessLayer.Itinerary itineraryManager = new KT.BusinessLayer.Itinerary();
                DateTime startDate = DateTime.Today.AddDays(-2);
                var itineraryList = itineraryManager.GetItineraryList();
                int cntr = 0;
                foreach(TripServices dto in itineraryList)
                {
                    cntr++;
                    var newItem = new ItineraryViewModel(_navigation);
                    DateTime tripStartDt = DateTime.Parse(dto.StartDate);

                    //TODO; change after demo
                    newItem.TripId = dto.ItineraryId;
                    newItem.TripName = dto.Name;                   
                    newItem.TripSchedule = $"{tripStartDt.ToString("MMM ddd, yyyy")} - {tripStartDt.AddDays(dto.NoOfDays).ToString("MMM dd, yyyy")}";                   
                    newItem.BackImagePath = $"KtMobileApp.Assets.Images.Activity_{cntr + 10}_128_128.png";

                    ItineraryList.Add(newItem);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task OpenPage()
        {
            //TODO
            await _navigation.PushModalAsync(new ImportItinerary()); //_pageNavigation.PushModalAsync(new Page) ; NOTE: this is for Modal Dialog
        }

    }
}
