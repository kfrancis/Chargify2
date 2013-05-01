using System;
using System.Net;
using Chargify2.Configuration;
using RestSharp;

namespace Chargify2
{
    public interface IClient
    {
        /// <summary>
        /// The V2 API key, also documented as "Chargify Direct API ID" on
        /// https://subdomain.chargify.com/settings#chargify-direct
        /// </summary>
        string ApiKey { get; }

        /// <summary>
        /// The V2 API password, also documented as "Chargify Direct Password" on
        /// https://subdomain.chargify.com/settings#chargify-direct
        /// </summary>
        string ApiPassword { get; }

        /// <summary>
        /// The V2 API Secret, also documented as "Chargify Direct API Secret" on
        /// https://subdomain.chargify.com/settings#chargify-direct
        /// </summary>
        string ApiSecret { get; }

        /// <summary>
        /// (Optional) The proxy needed to connect to the API, used for endpoints (not transparent forms)
        /// </summary>
        Uri Proxy { get; }

        /// <summary>
        /// The direct endpoint class
        /// </summary>
        Direct Direct { get; }
    }
}