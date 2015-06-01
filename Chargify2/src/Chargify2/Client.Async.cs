using System;
using System.Net;
using System.Threading.Tasks;
using Chargify2.Model;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Chargify2
{
    public partial class Client
    {
        /// <summary>
        /// Non-dynamic execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_apiKey, _apiPassword);
            client.AddHandler(contentType: "application/json", deserializer: new DynamicJsonDeserializer());
            client.UserAgent = UserAgent;
            if (_proxy != null)
            {
                client.Proxy = new WebProxy(_proxy);
            }

            var tcs = new TaskCompletionSource<T>();
            client.ExecuteAsync<T>(request, (response) => {
                if (response.ErrorException == null)
                {
                    tcs.SetResult(response.Data);
                }
                else
                {
                    tcs.SetException(response.ErrorException);
                }
            });           

            return tcs.Task;
        }

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        public async Task<Call> ReadCallAsync(string call_id)
        {
            var request = new RestRequest();

            request.Resource = "calls/{call_id}";
            request.RootElement = "call";
            request.AddParameter(name: "call_id", value: call_id, type: ParameterType.UrlSegment);

            JObject response = await ExecuteAsync<JObject>(request).ConfigureAwait(continueOnCapturedContext: false);

            return response["call"].ToObject<Call>();
        }
    }
}
