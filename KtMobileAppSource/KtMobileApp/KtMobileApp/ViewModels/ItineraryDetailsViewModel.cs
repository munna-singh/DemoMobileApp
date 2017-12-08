using KT.BusinessLayer;
using KtMobileApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ItineraryDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<ItineraryDailyBreakDown> ItineraryDailyBreakDown { get; set; }
        public Command LoadItineraryCommand { get; set; }

        public string Description { get; set; }
        public string DetailId { get; set; }        

        public ItineraryDetailsViewModel()
        {
            Title = "Itinerary Details";
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
                Itinerary itineraryManager = new Itinerary();
                DateTime startDate = DateTime.Today.AddDays(-2);
                var itineraryDailyBreakdown = itineraryManager.GetItineraryDays(1);
                int cntr = 0;
                foreach(ItineraryDayDto dto in itineraryDailyBreakdown)
                {
                    cntr++;
                    var newItem = new ItineraryDailyBreakDown();
                    //TODO; change after demo
                    dto.ItineraryDayDate = startDate.ToString("MMM dd,yyyy");

                    newItem.DayNumber = dto.Day;
                    newItem.Location = dto.LocationName;
                    newItem.TripDayDate = dto.ItineraryDayDate;
                    if (startDate < DateTime.Today)
                    {
                        newItem.IsPast = true;                        
                    }
                    newItem.ImageResourcePassedPath = "KtMobileApp.Assets.Images.checked_48_48.png";
                    newItem.ImageResourceActivityPath = $"KtMobileApp.Assets.Images.Activity_{cntr}_128_128.png";

                    ItineraryDailyBreakDown.Add(newItem);

                    //Add next day
                    startDate =  startDate.AddDays(1);
                }

                //ItineraryDailyBreakDown.AddRange(itineraryManager.GetItineraryDays(1));

                //ItineraryDailyBreakDown.Add(new Models.ItineraryDailyBreakDown() { Header = "Water games", Description = "Playing in water park", DayNumber = "1", IsPast = true,  ImageResourceActivityPath= "KtMobileApp.Assets.Images.Activity.jpg", ImageResourceCheckedPath = "KtMobileApp.Assets.Images.checked_48_48.png" });
                //ItineraryDailyBreakDown.Add(new Models.ItineraryDailyBreakDown() { Header = "Ground games", Description = "Playing Footbal", DayNumber = "2", IsPast = false,  ImageResourceActivityPath = "KtMobileApp.Assets.Images.Activity.jpg", ImageResourceCheckedPath = "KtMobileApp.Assets.Images.checked_48_48.png" });
                //ItineraryDailyBreakDown.Add(new Models.ItineraryDailyBreakDown() { Header = "Mountain Climbing", Description = "Mountain trecking", DayNumber = "3", IsPast = true, ImageResourceActivityPath = "KtMobileApp.Assets.Images.Activity.jpg" , ImageResourceCheckedPath = "KtMobileApp.Assets.Images.checked_48_48.png" });
                //ItineraryDailyBreakDown.Add(new Models.ItineraryDailyBreakDown() { Header = "Camp Fire", Description = "Camp fire in resort", DayNumber = "4", IsPast = false,  ImageResourceActivityPath = "KtMobileApp.Assets.Images.Activity.jpg" });
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
