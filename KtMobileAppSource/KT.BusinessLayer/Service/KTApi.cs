using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KT.BusinessLayer.Service
{
    public class KTApi<T>
    {
        private readonly string baseUri;

        public KTApi()
        {
            baseUri = "http://new-api-tmt.kensingtontours.com/api/"; //Move to config
        }


        public T Get(string apiUri)
        {
            var client = new HttpClient();
            var response = client.GetAsync(baseUri+apiUri).Result;
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

            return default(T);
        }

    }
}
