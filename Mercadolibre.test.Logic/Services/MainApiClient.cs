using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Mercadolibre.test.Logic.Services
{
    public class MainApiClient
    {
        private string BaseUrl = "https://api.mercadolibre.com/sites/MLC/search?q=";

        private readonly HttpClient _client;

        public MainApiClient()
        {
            _client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task<Response> GetAsync<Request, Response>(string queryString)
        {
            string relativeUrl = BaseUrl + queryString;

            HttpResponseMessage response = await _client.GetAsync(relativeUrl);
            var result = CastResponseAsync(response);
            return JsonConvert.DeserializeObject<Response>(result);
        }

        private string CastResponseAsync(HttpResponseMessage response)
        {
            string responseString = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return responseString;
            }
            else
            {
                //string errorDefault = ValidateException(responseString);
                //throw new GeneralException(errorDefault);
                return null;
            }
        }
    }
}
