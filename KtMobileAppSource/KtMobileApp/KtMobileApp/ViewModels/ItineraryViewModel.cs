using KtMobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
    public class ItineraryViewModel: BaseViewModel
    {
        public string BackImagePath { get; set; }
        public string Location { get; set; }
        public string TripName { get; set; }
        public string TripSchedule { get; set; }
        public int TripId { get; set; }        

        public ImageSource BackImageSource
        {
            get
            {
                return ImageSource.FromResource(BackImagePath);
            }
        }

        private INavigation _pageNavigation;

        public Command ViewItineraryDetails { get; set; }

        public ItineraryViewModel(INavigation pageNavigation)
        {
            _pageNavigation = pageNavigation;
            ViewItineraryDetails = new Command<ItineraryViewModel>(async (parm) => await OpenPage(parm));
        }

        public async Task OpenPage(ItineraryViewModel itineraryVm)
        {            
            await _pageNavigation.PushAsync(new ItineraryDetails(_pageNavigation, itineraryVm)); //_pageNavigation.PushModalAsync(new Page) ; NOTE: this is for Modal Dialog
        }
    }
}
