using System.Net;
using Chargify2.Model;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Chargify2
{
    public partial class Client
    {
        /// <summary>
        /// Synchronous execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private T Execute<T>(RestRequest request) where T : new()
        {
            var options = new RestClientOptions(BaseUrl)
            {
                UserAgent = UserAgent
            };
            if (_proxy != null)
            {
                options.Proxy = new WebProxy(_proxy);
            }
            _client = new RestClient(options);
            _client.UseSerializer(() => _serializer);
            _client.Authenticator = new HttpBasicAuthenticator(_apiKey, _apiPassword);

            var response = _client.ExecuteAsync<T>(request).GetAwaiter().GetResult();
            TimeoutCheck(request, response);
            return response.Data;
        }

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        public Call ReadCall(string call_id)
        {
            var request = new RestRequest
            {
                Resource = "calls/{call_id}",
                RootElement = "call"
            };
            request.AddParameter("call_id", call_id, ParameterType.UrlSegment);
            return this.Execute<JObject>(request)["call"].ToObject<Call>();
        }
    }
}
