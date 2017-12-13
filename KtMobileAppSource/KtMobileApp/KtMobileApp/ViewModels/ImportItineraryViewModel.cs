using KtMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ImportItineraryViewModel:BaseViewModel
    {
        public string TripReferenceNumber { set; get; }
        public string LocationImagePath { set; get; }
        public string WeatherImagePath { set; get; }
        public string ImageSourceCloseFormPath { set; get; }

        public string ImportStatusIconPath { set; get; }
        


        private string _importTripReferenceStatusMessage;
        public string ImportTripReferenceStatusMessage
    {
            get
            {
                return _importTripReferenceStatusMessage;
            }
            set
            {
                _importTripReferenceStatusMessage = value;
                OnPropertyChanged();
            }
        }

        private bool _hideImportTripView = true;
        public bool ShowImportTripView
        {
            get
            {
                return _hideImportTripView;
            }
            set
            {
                _hideImportTripView = value;
                OnPropertyChanged();
            }
        }

        private bool _showImportTripStatusView;
        public bool ShowImportTripStatusView
        {
            get
            {
                return _showImportTripStatusView;
            }
            set
            {
                _showImportTripStatusView = value;
                OnPropertyChanged();
            }
        }

        public ImageSource ImageSourceCloseForm
        {
            get
            {
                return ImageSource.FromResource(ImageSourceCloseFormPath);
            }
        }

        public ImageSource ImportStatusIcon
        {
            get
            {
                return ImageSource.FromResource(ImportStatusIconPath);
            }
        }

        private INavigation _pageNavigation;

        public Command ImportItinerary { get; set; }
        public Command CloseForm { get; set; }

        public ImportItineraryViewModel(INavigation pageNavigation)
        {
            //Title = "Manage Your Itinerary";
            _pageNavigation = pageNavigation;
            ImportItinerary = new Command<ImportItineraryViewModel>((parm) => AddItineraryToDb(parm));
            CloseForm = new Command(() => CloseDialogForm());
        }

        public void CloseDialogForm()
        {
            _pageNavigation.PopModalAsync();
        }

        public void AddItineraryToDb(ImportItineraryViewModel tripReferenceModel)
        {
            //TODO: DB is failing to open
            //KT.BusinessLayer.Itinerary itineraryManager = new KT.BusinessLayer.Itinerary();            
            //var tripCallResponse = itineraryManager.GetItinerary(tripReferenceModel.TripReferenceNumber);

            //AFTER success
            ImportTripReferenceStatusMessage = "Successfully Imported";
            ShowImportTripView = false;
            ShowImportTripStatusView = true;
            //await DisplayAlert
        }
    }
}
