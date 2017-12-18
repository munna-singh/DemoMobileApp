using KT.BusinessLayer;
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
        public string ImportFailedIconPath { set; get; }

        private bool _showSuccessIcon = true;
        public bool ShowSuccessIcon
        {
            get
            {
                return _showSuccessIcon;
            }
            set
            {
                _showSuccessIcon = value;
                OnPropertyChanged();
            }
        }

        private bool _showFailedIcon = true;
        public bool ShowFailedIcon
        {
            get
            {
                return _showFailedIcon;
            }
            set
            {
                _showFailedIcon = value;
                OnPropertyChanged();
            }
        }

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

        public ImageSource ImportFailedIcon
        {
            get
            {
                return ImageSource.FromResource(ImportFailedIconPath);
            }
        }

        private INavigation _pageNavigation;

        public Command ImportItinerary { get; set; }
        public Command CloseForm { get; set; }

        public ImportItineraryViewModel(INavigation pageNavigation)
        {
            //Title = "Manage Your Itinerary";
            _pageNavigation = pageNavigation;
            ImportItinerary = new Command<ImportItineraryViewModel>(async (parm) => await AddItineraryToDb(parm));
            CloseForm = new Command(() => CloseDialogForm());
        }

        public void CloseDialogForm()
        {            
            _pageNavigation.PopModalAsync();
        }

        public async Task AddItineraryToDb(ImportItineraryViewModel tripReferenceModel)
        {
            if (IsBusy) return;
            IsBusy = true;            

            try
            {

                await Task.Run(() => AddTrip(tripReferenceModel.TripReferenceNumber));

            }
            catch (Exception ex)
            {
                ImportTripReferenceStatusMessage = "Trip Import Failed";
                ShowImportTripView = false;
                ShowImportTripStatusView = true;
                ShowFailedIcon = true;
                ShowSuccessIcon = false;
            }

            IsBusy = false;
        }

        private void AddTrip(string tripReferenceNumber)
        {
            //TODO: DB is failing to open
            KT.BusinessLayer.Itinerary itineraryManager = new KT.BusinessLayer.Itinerary();
            TripImportStatus tripCallResponse = itineraryManager.AddItinerary(tripReferenceNumber);

            //AFTER success
            if (tripCallResponse==TripImportStatus.Add || tripCallResponse == TripImportStatus.Update)
            {
                ImportTripReferenceStatusMessage = tripCallResponse == TripImportStatus.Update ? "Itinerary updated with latest info !" : "Successfully Imported !";
                ShowImportTripView = false;
                ShowImportTripStatusView = true;
                ShowSuccessIcon = true;
                ShowFailedIcon = false;
            }
            else
            {               
                ImportTripReferenceStatusMessage = "Problem loading api response";
                ShowImportTripView = false;
                ShowImportTripStatusView = true;
                ShowFailedIcon = true;
                ShowSuccessIcon = false;
            }
        }
    }
}
