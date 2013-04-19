using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chargify2.Configuration;
using Chargify2.Model;
using RestSharp;

namespace Chargify2
{
    public class Client
    {
        const string BaseUrl = "https://api.chargify.com/api/v2";

        readonly string _apiKey;
        readonly string _apiPassword;
        readonly string _apiSecret;

        public Client(string apiKey, string apiPassword, string apiSecret)
        {
            _apiKey = apiKey;
            _apiPassword = apiPassword;
            _apiSecret = apiSecret;
        }

        public Client(ChargifyAccountElement config)
            : this(config.ApiKey, config.ApiPassword, config.Secret)
        {
        }

        private string _userAgent;
        private string UserAgent
        {
            get
            {
                if (_userAgent == null)
                {
                    _userAgent = String.Format("Chargify2 .NET Client v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                }
                return _userAgent;
            }
        }

        public string ApiKey
        {
            get { return _apiKey; }
        }

        public string ApiPassword
        {
            get { return _apiPassword; }
        }

        public string ApiSecret
        {
            get { return _apiSecret; }
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = BaseUrl;
            client.Authenticator = new HttpBasicAuthenticator(_apiKey, _apiPassword);
            client.UserAgent = UserAgent;

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        public Direct Direct
        {
            get
            {
                return new Direct(this);
            }
        }
    }
}
