using System;
using Chargify2.Configuration;

namespace Chargify2
{
    public partial class Client : IClient
    {
        private const string BaseUrl = "https://api.chargify.com/api/v2";

        private readonly string _apiKey;
        private readonly string _apiPassword;
        private readonly string _apiSecret;
        private readonly Uri _proxy;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key (like username) used for authentication</param>
        /// <param name="apiPassword">The api password used for authentication</param>
        /// <param name="apiSecret">The api secret used for encrypting/decrypting important data</param>
        /// <param name="proxy">The proxy connection to the server</param>
        public Client(string apiKey, string apiPassword, string apiSecret, Uri proxy)
        {
            _apiKey = apiKey;
            _apiPassword = apiPassword;
            _apiSecret = apiSecret;
            _proxy = proxy;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiKey">The api key (like username) used for authentication</param>
        /// <param name="apiPassword">The api password used for authentication</param>
        /// <param name="apiSecret">The api secret used for encrypting/decrypting important data</param>
        public Client(string apiKey, string apiPassword, string apiSecret)
            : this(apiKey, apiPassword, apiSecret, proxy: null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">The chargify configuration from web.config/app.config</param>
        public Client(ChargifyAccountElement config)
            : this(config.ApiKey, config.ApiPassword, config.Secret, config.Proxy)
        {
        }

        private string _userAgent;

        private string UserAgent
        {
            get
            {
                if (_userAgent == null)
                {
                    _userAgent = string.Format("Chargify2 .NET Client v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                }
                return _userAgent;
            }
        }

        /// <summary>
        /// An application programming interface key (API key) is a code passed in by computer programs calling an API (application programming interface) to identify the calling program, its developer, or its user to the Web site.
        /// </summary>
        public string ApiKey
        {
            get
            {
                return _apiKey;
            }
        }

        /// <summary>
        /// The password related to the ApiKey
        /// </summary>
        public string ApiPassword
        {
            get
            {
                return _apiPassword;
            }
        }

        /// <summary>
        /// The Api Secret is another string which is known only to the user and the server and is not publically shared. Generally
        /// used to encrypt data that is easily decrypted by the server.
        /// </summary>
        public string ApiSecret
        {
            get
            {
                return _apiSecret;
            }
        }

        /// <summary>
        /// The proxy connection to the server
        /// </summary>
        public Uri Proxy
        {
            get
            {
                return _proxy;
            }
        }

        /// <summary>
        /// The Chargify Direct API
        /// </summary>
        public Direct Direct
        {
            get
            {
                return new Direct(this);
            }
        }
    }
}
