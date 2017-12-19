using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace KT.BusinessLayer
{
    public class Weather
    {
		public async Task GetWeather()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100;

			var position = await locator.GetPositionAsync(timeout: TimeSpan.FromTicks(10000));

			var Latitude = position.Latitude.ToString();
			var Longitude = position.Longitude.ToString();

			var loc = "lat=" + Latitude + "&lon=" + Longitude;

			string key = "26bb87e0da5c30cf2dd007b1bab61409";
			string queryString = "http://api.openweathermap.org/data/2.5/weather?"
				+ loc + "&appid=" + key;

			var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

			if (results["weather"] != null)
			{

				WeatherDto.Temprature = (string)results["main"]["temp"] + " F";
			}
		}

	}
}
