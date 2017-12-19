using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KT.BusinessLayer
{
   public class DataService
    {
		public static async Task<JContainer> getDataFromService(string queryString)
		{
			HttpClient client = new HttpClient();
			var response = await client.GetAsync(queryString);

			JContainer data = null;
			if (response != null)
			{
				string json = response.Content.ReadAsStringAsync().Result;
				data = (JContainer)JsonConvert.DeserializeObject(json);
			}

			return data;
		}
	}
}
