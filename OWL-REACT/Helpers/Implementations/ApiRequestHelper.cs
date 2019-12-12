
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OWL_REACT.Helpers.Interfaces;
using System;
using System.Net.Http;
using System.Text;

namespace OWL_REACT.Helpers.Implementations
{
    public class ApiRequestHelper: IApiRequestHelper
    {
        private HttpClient _httpClient;

        public string Get(string url, string jsonBody = null){
            _httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

            if (jsonBody != null)
            {
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/jsonBody");
            }

            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch(Exception e)
            {
                throw e;  // NEEDS IMPROVED, JUST TEMP
            }
        }
    }
}
