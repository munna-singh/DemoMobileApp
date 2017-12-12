using KT.BusinessLayer;
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

        private INavigation _navigation;

        public string Description { get; set; }
        public string DetailId { get; set; }


        public ItinerariesViewModel(INavigation MainPageNavigation)
        {
            _navigation = MainPageNavigation;
            Title = "Trips";
            ItineraryList = new ObservableCollection<ItineraryViewModel>();
            LoadItineraryCommand = new Command(() => ExecuteLoadItemsCommand());            
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
                var itineraryList = itineraryManager.GetItineries();
                int cntr = 0;
                foreach(ItineraryDto dto in itineraryList)
                {
                    cntr++;
                    var newItem = new ItineraryViewModel(_navigation);
                    //TODO; change after demo
                    newItem.TripId = dto.ItineraryId;
                    newItem.TripName = dto.Name;                   
                    newItem.TripSchedule = $"{dto.Schedules[0].StartDate} - {dto.Schedules[0].EndDate}";                   
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

    }
}
