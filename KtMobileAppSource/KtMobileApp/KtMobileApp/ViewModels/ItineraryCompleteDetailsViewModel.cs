using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using KT.BusinessLayer;
using KT.DAL.Models;

namespace KtMobileApp.ViewModels
{
    public class ItineraryDayViewModel : BaseViewModel
    {

        private ItineraryCompleteDetailsViewModel _DayCompleteDetails;
        public ItineraryCompleteDetailsViewModel DayCompleteDetails
        {
            get { return _DayCompleteDetails; }
            set
            {
                _DayCompleteDetails = value;
                OnPropertyChanged();
            }
        }

        public async Task NavigateNext(ItineraryCompleteDetailsViewModel currentDay)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {

                await Task.Run(() => NavigateNextOrPrevious(Int32.Parse(currentDay.DayNumber), true));

            }
            catch (Exception)
            {
                //
            }

            IsBusy = false;
        }

        public async Task NavigatePrevious(ItineraryCompleteDetailsViewModel currentDay)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {

                await Task.Run(() => NavigateNextOrPrevious(Int32.Parse(currentDay.DayNumber), false));

            }
            catch (Exception)
            {
                //
            }

            IsBusy = false;
        }

        private void NavigateNextOrPrevious(int currentDay, bool isNext)
        {
            var tripService = new Itinerary();
            var triDayObject = tripService.GetItineraryDayDesc(currentDay + 1);

            DayCompleteDetails = GetitinerayCompleteDesc(triDayObject);
            DayCompleteDetails.DayNumber = (currentDay + 1).ToString();    
        }

        public ItineraryCompleteDetailsViewModel GetitinerayCompleteDesc(ItineraryDayDesc triDayObject)
        {
            var itineraryDesc = new ItineraryCompleteDetailsViewModel();            
            itineraryDesc.DayDate = triDayObject.TimeOfDayId.ToString();
            itineraryDesc.LocationName = $"{triDayObject.SourceName}-{triDayObject.DestName}";
            itineraryDesc.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
            itineraryDesc.CompleteDescription = triDayObject.Description;

            return itineraryDesc;
        }

        public Command NavigateNextDay { get; set; }
        public Command NavigatePreviousDay { get; set; }

        public ItineraryDayViewModel()
        {
            NavigateNextDay = new Command<ItineraryCompleteDetailsViewModel>(async (model) => await NavigateNext(model));
            NavigatePreviousDay = new Command<ItineraryCompleteDetailsViewModel>(async (model) => await NavigatePrevious(model));
        }

    }

    public class ItineraryCompleteDetailsViewModel: BaseViewModel
    {
        private string _DayNumber;
        public string DayNumber
        {
            get { return _DayNumber; }
            set
            {
                _DayNumber = value;
                OnPropertyChanged();
            }
        }


        private string _LocationName;
        public string LocationName
        {
            get { return _LocationName; }
            set
            {
                _LocationName = value;
                OnPropertyChanged();
            }
        }

        private string _DayDate;
        public string DayDate
        {
            get { return _DayDate; }
            set
            {
                _DayDate = value;
                OnPropertyChanged();
            }
        }

        private string _CompleteDescription;
        public string CompleteDescription
        {
            get { return _CompleteDescription; }
            set
            {
                _CompleteDescription = value;
                OnPropertyChanged();
            }
        }

        public string ImageBanner { get; set; }
        //public string DayNumber { get; set; }
        //public string LocationName { get; set; }
        //public string DayDate { get; set; }
        //public string CompleteDescription { get; set; }

        public ImageSource ImageSourcePassed
        {
            get
            {
                return ImageSource.FromResource(ImageBanner);
            }
        }       
    }
}
