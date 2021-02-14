using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ilithenza.App.Helpers.Interfaces
{
    public interface IApiRequestHelper
    {
        public string Get(System.Uri url, string jsonBody = null);
    }
}
