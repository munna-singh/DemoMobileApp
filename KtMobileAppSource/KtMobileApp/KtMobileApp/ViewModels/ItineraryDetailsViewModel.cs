
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
using System.Linq;

namespace KtMobileApp.ViewModels
{
    public class ItineraryDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<ItineraryDailyBreakDown> ItineraryDailyBreakDown { get; set; }
        public Command LoadItineraryCommand { get; set; }

        private ItineraryViewModel _itineraryVm;
        private INavigation _navigation; // HERE

        public string Description { get; set; }
        public string DetailId { get; set; }

        public ItineraryDetailsViewModel(INavigation MainPageNavigation, ItineraryViewModel itineraryVm)
        {
            Title = itineraryVm.TripName;
            _navigation = MainPageNavigation;
            _itineraryVm = itineraryVm;
            ItineraryDailyBreakDown = new ObservableCollection<ItineraryDailyBreakDown>();
            LoadItineraryCommand = new Command(() => ExecuteLoadItemsCommand());            
        }

        void ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ItineraryDailyBreakDown.Clear();
                KT.BusinessLayer.Itinerary itineraryManager = new KT.BusinessLayer.Itinerary();
                DateTime startDate = DateTime.Today.AddDays(-2);
                var itineraryDailyBreakdown = itineraryManager.GetItineraryDays(_itineraryVm.TripId);
                int cntr = 0;
                foreach (ItineraryDayDto dto in itineraryDailyBreakdown)
                {
                    cntr++;
                    var newItem = new ItineraryDailyBreakDown(_navigation);
                    DateTime tripDayDate = DateTime.Parse(dto.ItineraryDayDate);

                    //TODO; change after demo
                    dto.ItineraryDayDate = tripDayDate.ToString("MMM dd, yyyy");

                    newItem.TripId = _itineraryVm.TripId;
                    newItem.DayNumber = Int16.Parse(dto.Day);
                    newItem.Location = dto.Summary;
                    newItem.TripDayDate = dto.ItineraryDayDate;
                    newItem.ItineraryDayDescription = @"<html><body><ul style='list-style-type:disc'>" + dto.Highlights.Select(item=>$"<li>{item}</li>") + @"</ul></body></html>";
                    newItem.itineraryDayId = dto.ItineraryDayId;
                    newItem.TripTitle = Title;
                    //newItem.TripDayHighlights = 

                    //Check for past days
                    if (tripDayDate < DateTime.Today)
                    {
                        newItem.IsPast = true;
                    }

                    //Set selected item background color for current day
                    if (tripDayDate == DateTime.Today)
                    {
                        newItem.CurrentTripDaySelectedItem = Color.FromHex("BFAD87");
                    }
                    newItem.ImageResourcePassedPath = "KtMobileApp.Assets.Images.checked_48_48.png";
                    newItem.ImageResourceActivityPath = $"KtMobileApp.Assets.Images.Activity_{cntr}_128_128.png";



                    ItineraryDailyBreakDown.Add(newItem);

                    //Add next day
                    //startDate = startDate.AddDays(1);
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