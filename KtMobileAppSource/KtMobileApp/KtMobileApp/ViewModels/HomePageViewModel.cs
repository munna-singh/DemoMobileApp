using KT.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
	public class HomePageViewModel:BaseViewModel
	{
		public string CurrentLocation { get; set; }
		public string Country { get; set; }
		public string BackImagePath { set; get; }
		public string LocationImagePath { set; get; }
		public string WeatherImagePath { set; get; }
        //public string Temprature { get; set; }

        private string _temprature;
        public string Temprature
        {
            get { return _temprature; }
            set
            {
                _temprature = value;
                OnPropertyChanged();
            }
        }

        public ImageSource BackImage
		{
			get
			{
				return ImageSource.FromResource(BackImagePath);
			}
		}
		public ImageSource LocationImage
		{
			get
			{
				return ImageSource.FromResource(LocationImagePath);
			}
		}
		public ImageSource WeatherImage
		{
			get
			{
				return ImageSource.FromResource(WeatherImagePath);
			}
		}

		public HomePageViewModel()
		{

		}

        public void GetUpdatedWeather()
        {
            Weather weather = new Weather();
            Task.Factory.StartNew(() =>
            {
                // Do some work on a background thread, allowing the UI to remain responsive
                var temperatureRes = weather.GetWeather().Result;
                Temprature = temperatureRes; //Update your viewmodel Property to show view with latest value.
                // When the background work is done, continue with this code block
            });          
            
        }

	}
}
