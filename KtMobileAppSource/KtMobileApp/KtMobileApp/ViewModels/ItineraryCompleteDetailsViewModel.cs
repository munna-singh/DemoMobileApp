using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ItineraryCompleteDetailsViewModel:BaseViewModel
    {
        public string ImageBanner { get; set; }
        public int DayNumber { get; set; }
        public string LocationName { get; set; }
        public string DayDate { get; set; }
        public string CompleteDescription { get; set; }

        public ImageSource ImageSourcePassed
        {
            get
            {
                return ImageSource.FromResource(ImageBanner);
            }
        }

        public ItineraryCompleteDetailsViewModel()
        {
            Title = "Itinerary Name-2";
        }
    }
}
