using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KtMobileApp.ViewModels
{
	public class HomePageViewModel
	{
		public string CurrentLocation { get; set; }
		public string Country { get; set; }
		public string BackImagePath { set; get; }
		public string LocationImagePath { set; get; }
		public string WeatherImagePath { set; get; }

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
	}
}
