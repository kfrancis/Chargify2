using System;
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
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_apiKey, _apiPassword);
            client.AddHandler(contentType: "application/json", deserializer: new DynamicJsonDeserializer());
            client.UserAgent = UserAgent;
            if (_proxy != null)
            {
                client.Proxy = new WebProxy(this._proxy);
            }

            IRestResponse<T> response = client.Execute<T>(request);

            if (response.ErrorException == null)
            {
                return response.Data;
            }
            else
            {
                throw response.ErrorException;
            }
        }

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        public Call ReadCall(string call_id)
        {
            var request = new RestRequest();
            request.Resource = "calls/{call_id}";
            request.RootElement = "call";
            request.AddParameter("call_id", call_id, ParameterType.UrlSegment);
            return this.Execute<JObject>(request)["call"].ToObject<Call>();
        }
    }
}
