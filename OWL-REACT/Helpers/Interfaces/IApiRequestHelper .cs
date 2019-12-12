
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;

namespace OWL_REACT.Helpers.Interfaces
{
    public interface IApiRequestHelper
    {
        public string Get(string url, string jsonBody = null);    
    }
}
