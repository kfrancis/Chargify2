using System;
using System.Threading.Tasks;
using Chargify2.Model;

namespace Chargify2
{
    /// <summary>
    /// Client
    /// </summary>
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

        #region Calls

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        Call ReadCall(string call_id);

        /// <summary>
        /// Read the call information from Chargify
        /// </summary>
        /// <param name="call_id"></param>
        /// <returns>The call information</returns>
        Task<Call> ReadCallAsync(string call_id);

        #endregion Calls
    }
}
