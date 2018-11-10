using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace KT.BusinessLayer
{
    public class Weather
    {
		public async Task<string> GetWeather()
		{
			//Call Cross Geolocator 
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 100;
			var position = await locator.GetPositionAsync(timeout: TimeSpan.FromTicks(10000));
			//Get lat log 
			var Latitude = position.Latitude.ToString();
			var Longitude = position.Longitude.ToString();

			var loc = "lat=" + Latitude + "&lon=" + Longitude;
			string key = "26bb87e0da5c30cf2dd007b1bab61409";

			//Query string which has to be requested to open weather API
			string queryString = "http://api.openweathermap.org/data/2.5/weather?"
				+ loc + "&appid=" + key;

			// Get the result from API
			var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
			
			if (results["weather"] != null)
			{
				var result = (string)results["main"]["temp"];

				//Convert Temprature From Kelvin to F

				var TempInFahrenheit = 9 / 5 * double.Parse(result) - 273 + 32 +"F";

				//Return
				return TempInFahrenheit.ToString();
			}

            return null;
		}

	}
}
