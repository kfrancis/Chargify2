using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Chargify2.Model;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;

namespace Chargify2
{
    /// <summary>
    /// REST Client Implementation
    /// </summary>
    public partial class Client
    {
        private readonly IRestSerializer _serializer;
        private readonly ILogger _logger;
        private RestClient _client;

        public Client(ILogger logger)
        {
            _serializer = new DynamicJsonDeserializer();
            _logger = logger;
        }

        /// <summary>
        /// Non-dynamic execute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request) where T : new()
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

            var response = await _client.ExecuteAsync<T>(request).ConfigureAwait(false);
            TimeoutCheck(request, response);
            return response;
        }

        private void TimeoutCheck(RestRequest request, RestResponse response)
        {
            if (response.StatusCode == 0)
            {
                LogError(request, response);
            }
        }

        private void LogError(RestRequest request, RestResponse response)
        {
            //Get the values of the parameters passed to the API
            var parameters = request.QueryParameters();

            //Set up the information message with the URL,
            //the status code, and the parameters.
            var info = "Request to " + _client.BuildUri(request) + " failed with status code "
                          + response.StatusCode + ", parameters: "
                          + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response?.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            _logger.LogError(ex, info);
        }

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        public async Task<Call> ReadCallAsync(string call_id)
        {
            var request = new RestRequest
            {
                Resource = "calls/{call_id}",
                RootElement = "call"
            };
            request.AddParameter(name: "call_id", value: call_id, type: ParameterType.UrlSegment);

            var response = await ExecuteAsync<Call>(request).ConfigureAwait(continueOnCapturedContext: false);
            TimeoutCheck(request, response);
            return response.Data;
        }
    }

    public static class RestRequestExtensions
    {
        public static string QueryParameters(this RestRequest request)
        {
            return string.Join(", ", request.Parameters.Select(x => x.Name + "=" + (x.Value ?? "NULL")).ToArray());
        }
    }
}
