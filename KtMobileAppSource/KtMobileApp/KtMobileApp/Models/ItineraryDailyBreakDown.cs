using KtMobileApp.ViewModels;
using KtMobileApp.Views;
//using KtMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.Models
{
    public class ItineraryDailyBreakDown : BaseViewModel
    {
        private INavigation _pageNavigation;
        

        public ItineraryDailyBreakDown(INavigation MainPageNavigation)
        {
            //Title = "Itinerary Name";
            _pageNavigation = MainPageNavigation;

            OpenItineraryDayDetails = new Command<ItineraryDailyBreakDown>(async (model) => await OpenNewPage(model));

        }

       

        public int TripId { get; set; }
        public int itineraryDayId { get; set; }
        public string ImageUri { get; set; }
        public string Location { get; set; }
        public string TripDayDate { get; set; }
        public bool IsPast { get; set; }
        public string IsPastText { get; set; }
        public int DayNumber { get; set; }
        public string CheckImageUri { get; set; }
        public string ItineraryDayDescription { set; get; }
        public string ImageResourceActivityPath { set; get; }
        public string TripTitle { set; get; }

        private string _imageResourcePassedPath;
        public string ImageResourcePassedPath
        {
            get { return _imageResourcePassedPath; }
            set
            {               
                    _imageResourcePassedPath = value;
            }
        }

        private bool _expandItineraryDayDetails;
        public bool ExpandItineraryDayDetails
        {
            get
            {
                return _expandItineraryDayDetails;
            }
            set
            {
                _expandItineraryDayDetails = value;
                OnPropertyChanged();
            }
        }
        
        public int ImageSourcePastTripDayHide
        {
            get {
                return IsPast ? 100 : 0;//for seting the opacity of image value = 0 (means not visible, 100 means full visible)
            }           
        }        

        public Command OpenItineraryDayDetails { get; set; }
        
        public async Task OpenNewPage(ItineraryDailyBreakDown objVm)
        {
            //objVm.TripTitle = Title;
            //MainPage.SetMenu(new ItineraryCompleteDetails(objVm,new Menu() { })
            await _pageNavigation.PushAsync(new ItineraryCompleteDetails(objVm)); //_pageNavigation.PushModalAsync(new Page) ; NOTE: this is for Modal Dialog
        }


        public Color CurrentTripDaySelectedItem { get; set; }

        public ImageSource ImageSourceActivity
        {
            get
            {
                return ImageSource.FromResource(ImageResourceActivityPath);
            }
        }

        public ImageSource ImageSourcePastTripDay
        {
            get
            {
                return ImageSource.FromResource(ImageResourcePassedPath);
            }
        }

        private int _ExpandingHeight = 0;
        public int ExpandedHeight
        {
            get
            {
                return _ExpandingHeight;
            }
            set
            {
                _ExpandingHeight = value;
                OnPropertyChanged();
            }
        }


        public Command ExpandHideData
        {
            get
            {
                return new Command(() =>
                {
                    ExpandItineraryDayDetails = !ExpandItineraryDayDetails;
                });
            }
        }

    }

}