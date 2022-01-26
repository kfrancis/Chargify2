using System;
using System.Collections;
using System.Text;

namespace Chargify2
{
    /// <summary>
    /// The API for Chargify Direct
    /// </summary>
    public class Direct
    {
        private readonly Client _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">The client</param>
        public Direct(Client client)
        {
            _client = client;

            ValidateClient();
        }

        /// <summary>
        /// Calculate the signature given the message and the api secret
        /// </summary>
        /// <param name="message">The message to use when producing the signature</param>
        /// <param name="secret">The api secret</param>
        /// <returns>The signature, null string otherwise.</returns>
        public static string Signature(string message, string secret)
        {
            return message.CalculateSignature(secret);
        }

        /// <summary>
        /// The secure parameters
        /// </summary>
        /// <param name="hash">The hash of secure parameter values</param>
        /// <returns>The secure parameters</returns>
        public SecureParameters SecureParameters(Hashtable hash)
        {
            return new SecureParameters(hash, _client);
        }

        /// <summary>
        /// The response parameters
        /// </summary>
        /// <param name="hash">The hash of secure parameter values</param>
        /// <returns>The response parameters</returns>
        public ResponseParameters ResponseParameters(Hashtable hash)
        {
            return new ResponseParameters(hash, _client);
        }

        /// <summary>
        /// Validate the client
        /// </summary>
        private void ValidateClient()
        {
            if (_client == null)
                throw new ArgumentNullException(message: "Direct requires a Client as an argument", paramName: "client");
        }
    }

#pragma warning disable JustCode_CSharp_TypeFileNameMismatch // Types not matching file names

    /// <summary>
    /// The secure parameters used in Chargify Direct (API v2)
    /// </summary>
    public class SecureParameters
#pragma warning restore JustCode_CSharp_TypeFileNameMismatch // Types not matching file names
    {
        /// <summary>
        /// The API ID (ie. the API key)
        /// </summary>
        public string api_id { get; set; }

        /// <summary>
        /// An optional timestamp (unix ticks since epoch)
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// An optional nonce value
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// A set of values to be sent to Chargify
        /// </summary>
        public Hashtable data { get; set; }

        /// <summary>
        /// The API secret
        /// </summary>
        public string secret { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hash">The hash to use when constructing the secure parameter hidden inputs</param>
        /// <param name="client">The client</param>
        public SecureParameters(Hashtable hash, Client client)
        {
            api_id = client.ApiKey;
            secret = client.ApiSecret;

            timestamp = (string)hash["timestamp"];
            nonce = (string)hash["nonce"];

            data = hash;

            ValidateArgs();
        }

        /// <summary>
        /// Converts the hash to a set of hidden inputs
        /// </summary>
        /// <returns></returns>
        public string ToFormInputs()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format(format: "<input type='hidden' name='secure[api_id]' value='{0}'/>", arg0: api_id));
            sb.AppendLine(string.Format(format: "<input type='hidden' name='secure[timestamp]' value='{0}'/>", arg0: timestamp));
            sb.AppendLine(string.Format(format: "<input type='hidden' name='secure[nonce]' value='{0}'/>", arg0: nonce));
            sb.AppendLine(string.Format(format: "<input type='hidden' name='secure[data]' value='{0}'/>", arg0: EncodedData));
            sb.AppendLine(string.Format(format: "<input type='hidden' name='secure[signature]' value='{0}'/>", arg0: Signature));
            return sb.ToString();
        }

        /// <summary>
        /// The information that should be included in the secure[data] field
        /// </summary>
        public string EncodedData
        {
            get
            {
                var h = data;
                if (h.ContainsKey(key: "timestamp")) h.Remove(key: "timestamp");
                if (h.ContainsKey(key: "nonce")) h.Remove(key: "nonce");
                return h.ToQueryString();
            }
        }

        /// <summary>
        /// The signature, as calculated by the formula listed in the documentation
        /// </summary>
        private string Signature
        {
            get
            {
                var message = api_id + timestamp + nonce + EncodedData;
                return Direct.Signature(message, secret);
            }
        }

        /// <summary>
        /// Validate args
        /// </summary>
        public void ValidateArgs()
        {
            if (data == null)
            {
                throw new ArgumentException(message: "The 'data' provided must be provideed as a Hash", paramName: "data");
            }

            if (string.IsNullOrWhiteSpace(api_id) || string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentException(message: "SecureParameters requires connection to a Client - was one given?");
            }
        }
    }

#pragma warning disable JustCode_CSharp_TypeFileNameMismatch // Types not matching file names

    /// <summary>
    /// Based on the work in the Chargify2 gem (https://github.com/chargify/chargify2)
    /// </summary>
    public class ResponseParameters
#pragma warning restore JustCode_CSharp_TypeFileNameMismatch // Types not matching file names
    {
        /// <summary>
        /// The API id (ie. The API key)
        /// </summary>
        public string api_id { get; set; }

        /// <summary>
        /// The timestamp (unix ticks since epoch)
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// The nonce value
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// The status code of the response
        /// </summary>
        public string status_code { get; set; }

        /// <summary>
        /// The result code of the response
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// The ID of the call that is related to this response (for looking up later)
        /// </summary>
        public string call_id { get; set; }

        /// <summary>
        /// The api secret
        /// </summary>
        public string secret { get; private set; }

        /// <summary>
        /// The signature of the response
        /// </summary>
        public string signature { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hash">The hash of response values</param>
        /// <param name="client">The rest api client</param>
        public ResponseParameters(Hashtable hash, Client client)
        {
            api_id = client.ApiKey;
            secret = client.ApiSecret;

            status_code = (string)hash["status_code"];
            timestamp = (string)hash["timestamp"];
            nonce = (string)hash["nonce"];
            result_code = (string)hash["result_code"];
            call_id = (string)hash["call_id"];
            signature = (string)hash["signature"];

            ValidateArgs();
        }

        /// <summary>
        /// Was this successful?
        /// </summary>
        public bool isSuccess
        {
            get
            {
                return status_code == "200";
            }
        }

        /// <summary>
        /// Is the signature returned from the call valid?
        /// </summary>
        public bool isVerified
        {
            get
            {
                var message = api_id + timestamp + nonce + status_code + result_code + call_id;
                return Direct.Signature(message, secret) == signature;
            }
        }

        /// <summary>
        /// Validate the args
        /// </summary>
        public void ValidateArgs()
        {
            if (string.IsNullOrWhiteSpace(api_id) || string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentException("ResponseParameters requires connection to a Client - was one given?");
            }
        }
    }
}
