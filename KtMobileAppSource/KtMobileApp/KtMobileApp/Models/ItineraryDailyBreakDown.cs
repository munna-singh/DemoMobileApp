using KtMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace KtMobileApp.Models
{
    public class ItineraryDailyBreakDown: BaseViewModel
    {
        public string ImageUri { get; set; }
        public string Location { get; set; }
        public string TripDayDate { get; set; }
        public bool IsPast { get; set; }
        public string IsPastText { get; set; }
        public int DayNumber { get; set; }
        public string CheckImageUri { get; set; }

        public string ImageResourceActivityPath { set; get; }
        
        private string _imageResourcePassedPath;
        public string ImageResourcePassedPath
        {
            get { return _imageResourcePassedPath; }
            set {
                if (IsPast)
                    _imageResourcePassedPath = value;
            }
        }

        public ImageSource ImageSourceActivity
        {
            get
            {
                return ImageSource.FromResource(ImageResourceActivityPath);
            }
        }

        public ImageSource ImageSourcePassed
        {
            get
            {
                return ImageSource.FromResource(ImageResourcePassedPath);
            }
        }
    }

}
