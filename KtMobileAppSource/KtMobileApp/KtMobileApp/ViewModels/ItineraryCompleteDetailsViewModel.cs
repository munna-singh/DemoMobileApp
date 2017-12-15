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
        List<int> _itineraryDays;
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

                await Task.Run(() => NavigateNextOrPrevious(currentDay, true));

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

                await Task.Run(() => NavigateNextOrPrevious(currentDay, false));

            }
            catch (Exception)
            {
                //
            }

            IsBusy = false;
        }

        private void NavigateNextOrPrevious(ItineraryCompleteDetailsViewModel currentDay, bool isNext)
        {
            var tripService = new Itinerary();

            var triDayObject = isNext ? tripService.GetItineraryNextDay(currentDay.ItineraryDayId, currentDay.ItineraryId, Int32.Parse(currentDay.DayNumber)) 
                                    : tripService.GetItineraryPreviousDay(currentDay.ItineraryDayId, currentDay.ItineraryId, Int32.Parse(currentDay.DayNumber));

            DayCompleteDetails = GetitinerayCompleteDesc(triDayObject);
        }

        public ItineraryCompleteDetailsViewModel GetitinerayCompleteDesc(ItineraryDayDescDto triDayObject)
        {
            var itineraryDesc = new ItineraryCompleteDetailsViewModel();            
           // itineraryDesc.DayDate = triDayObject.TimeOfDayId.ToString();
            itineraryDesc.LocationName = $"{triDayObject.LocationName}";
            itineraryDesc.ImageBanner = "KtMobileApp.Assets.Images.BannerImage_2_256_256.png";
           // itineraryDesc.CompleteDescription = triDayObject.Description;
            itineraryDesc.DayNumber = triDayObject.DayNumber.ToString();
            itineraryDesc.ItineraryId = triDayObject.ItineraryId;
            itineraryDesc.ItineraryDayId = triDayObject.ItineraryDayId;

            return itineraryDesc;
        }

        public Command NavigateNextDay { get; set; }
        public Command NavigatePreviousDay { get; set; }

        public ItineraryDayViewModel()
        {
            var tripService = new Itinerary();
          
            NavigateNextDay = new Command<ItineraryCompleteDetailsViewModel>(async (model) => await NavigateNext(model));
            NavigatePreviousDay = new Command<ItineraryCompleteDetailsViewModel>(async (model) => await NavigatePrevious(model));
            //_itineraryDays = tripService
        }

    }

    public class ItineraryCompleteDetailsViewModel: BaseViewModel
    {
        public int ItineraryId { set; get; }
        public int ItineraryDayId { set; get; }

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

        public ImageSource ImageSourcePassed
        {
            get
            {
                return ImageSource.FromResource(ImageBanner);
            }
        }       
    }
}
