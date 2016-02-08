using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// Generated with http://json2csharp.com/ based on the return of a single call

namespace Chargify2.Model
{
    #region Json2Class Generated

    /// <summary>
    /// A payment profile is the method of payment of a subscription
    /// </summary>
    public class PaymentProfile
    {
        /// <summary>
        /// The month of expiry
        /// </summary>
        public string expiration_month { get; set; }
        /// <summary>
        /// The billing city
        /// </summary>
        public string billing_city { get; set; }
        /// <summary>
        /// The first name (ie, the first name on the credit card represented by this payment profile)
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// The billing state
        /// </summary>
        public string billing_state { get; set; }
        /// <summary>
        /// The billing country
        /// </summary>
        public string billing_country { get; set; }
        /// <summary>
        /// The last name
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// The first line of the billing address
        /// </summary>
        public string billing_address { get; set; }
        /// <summary>
        /// The second line of the billing address
        /// </summary>
        public string billing_address_2 { get; set; }
        /// <summary>
        /// The billing zip/postal code
        /// </summary>
        public string billing_zip { get; set; }
        /// <summary>
        /// The credit card number
        /// </summary>
        public string card_number { get; set; }
        /// <summary>
        /// The expiration year
        /// </summary>
        public string expiration_year { get; set; }
        /// <summary>
        /// The card verification value number (used to prove the card is in hand for card not present transactions (online))
        /// </summary>
        public string cvv { get; set; }
    }

    /// <summary>
    /// The object representing a signup
    /// </summary>
    public class Signup
    {
        /// <summary>
        /// The product that the customer is subscribed to
        /// </summary>
        public Product product { get; set; }
        /// <summary>
        /// The coupon code (if used)
        /// </summary>
        public string coupon_code { get; set; }
        /// <summary>
        /// The payment profile associated with the subscription created during this signup
        /// </summary>
        public PaymentProfile payment_profile { get; set; }
        /// <summary>
        /// The components (and their allocations) used during signup
        /// </summary>
        public Dictionary<string, object> components { get; set; }
        /// <summary>
        /// The customer related to the subscription created/used during this signup
        /// </summary>
        public Customer customer { get; set; }
    }
    
    /// <summary>
    /// For transparent forms, this data is what was passed to APIv2
    /// </summary>
    public class Secure
    {
        /// <summary>
        /// The API key
        /// </summary>
        public string api_id { get; set; }
        /// <summary>
        /// A string (max 40 characters) used to uniquify the request. This will be a GUID if generating the nonce using this library.
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// A verification signature based on the other 4 secure inputs and the shared api_secret for the API User
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// Parameters which you want mirrored back to you
        /// </summary>
        public string mirror { get; set; }
        /// <summary>
        /// A string in URL query-string format that may be used to transmit tamper-proof data to Chargify through the form
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// The time of the request, given as an integer number of seconds elapsed since Jan 1, 1970 00:00:00 UTC (unix epoch)
        /// </summary>
        public string timestamp { get; set; }
    }

    /// <summary>
    /// The request sent to Chargify
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Details about the signup
        /// </summary>
        public Signup signup { get; set; }
        /// <summary>
        /// Details about the API v2 parameters
        /// </summary>
        public Secure secure { get; set; }
        /// <summary>
        /// The payment profile information
        /// </summary>
        public PaymentProfile payment_profile { get; set; }
        /// <summary>
        /// The ID of the request
        /// </summary>
        public string id { get; set; }
    }

    /// <summary>
    /// Any APIv2 request will result in a response containing (but not limited to) this object
    /// </summary>
    public class Result
    {
        /// <summary>
        /// The result code returned by Chargify. Generally just the status_code padded with zero.
        /// </summary>
        public string result_code { get; set; }
        /// <summary>
        /// The HTTPStatusCode of the result
        /// </summary>
        public string status_code { get; set; }
        /// <summary>
        /// The list of errors
        /// </summary>
        public List<Error> errors { get; set; }
    }

    /// <summary>
    /// An error is represented with the following
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The attribute sent in the request which has an issue
        /// </summary>
        public string attribute { get; set; }
        /// <summary>
        /// The message is the reason there was an error with the request, releated to the field specified by attribute
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// Subscriptions tie a Customer to a particular ProductThe subscription
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// The last time the subscription was updated (either by user or Chargify)
        /// </summary>
        public DateTime? updated_at { get; set; }
        /// <summary>
        /// The transaction ID of the payment associated with the signup
        /// </summary>
        public int? signup_payment_id { get; set; }
        /// <summary>
        /// The ID of the customer
        /// </summary>
        public int? customer_id { get; set; }
        /// <summary>
        /// The date/time the subscription expires at 
        /// </summary>
        public DateTime? expires_at { get; set; }
        /// <summary>
        /// Should the subscription cancel at the end of the current period?
        /// </summary>
        public bool? cancel_at_end_of_period { get; set; }
        /// <summary>
        /// The date/time the subscription was activated
        /// </summary>
        public DateTime? activated_at { get; set; }
        /// <summary>
        /// The date/time the trial was started
        /// </summary>
        public DateTime? trial_started_at { get; set; }
        /// <summary>
        /// The balance of the subscription, in cents
        /// </summary>
        public int? balance_in_cents { get; set; }
        /// <summary>
        /// The previous state of the subscription
        /// </summary>
        public string previous_state { get; set; }
        /// <summary>
        /// The date/time the current period ends
        /// </summary>
        public DateTime? current_period_ends_at { get; set; }
        /// <summary>
        /// The cancellation message (if any)
        /// </summary>
        public string cancellation_message { get; set; }
        /// <summary>
        /// The ID of the payment profile
        /// </summary>
        public int? payment_profile_id { get; set; }
        /// <summary>
        /// The date/time the subscription is set to cancel at
        /// </summary>
        public DateTime? delayed_cancel_at { get; set; }
        /// <summary>
        /// The current state of the subscription
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// The date/time the trial is ending
        /// </summary>
        public DateTime? trial_ended_at { get; set; }
        /// <summary>
        /// The date/time the subscription will next be assessed
        /// </summary>
        public DateTime? next_assessment_at { get; set; }
        /// <summary>
        /// The date/time the subscription was created
        /// </summary>
        public DateTime? created_at { get; set; }
        /// <summary>
        /// The ID of the subscription
        /// </summary>
        public int? id { get; set; }
        /// <summary>
        /// The date/time the subscription was cancelled
        /// </summary>
        public DateTime? canceled_at { get; set; }
        /// <summary>
        /// The ID of the product the customer was subscribed to
        /// </summary>
        public int? product_id { get; set; }
        /// <summary>
        /// The amount of revenue made on signup for this subscription
        /// </summary>
        public string signup_revenue { get; set; }
        /// <summary>
        /// The date/time the current period was started
        /// </summary>
        public DateTime? current_period_started_at { get; set; }
    }

    /// <summary>
    /// Products are the things that you sell. You must have Products set up in order to sell or initiate Subscriptions.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The date/time the product was updated
        /// </summary>
        public DateTime? updated_at { get; set; }
        /// <summary>
        /// The name of the product
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// The trial interval unit (day/month)
        /// </summary>
        public string trial_interval_unit { get; set; }
        /// <summary>
        /// The description of the product
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// The interval in which the product expires for a subscription
        /// </summary>
        public string expiration_interval { get; set; }
        /// <summary>
        /// The ID of the product family
        /// </summary>
        public int? product_family_id { get; set; }
        /// <summary>
        /// The product handle
        /// </summary>
        public string handle { get; set; }
        /// <summary>
        /// The date/time the product was archived at
        /// </summary>
        public DateTime? archived_at { get; set; }
        /// <summary>
        /// The parameters to be returned when the customer is redirected to the return_url
        /// </summary>
        public string return_params { get; set; }
        /// <summary>
        /// The initial charge (in cents), ie. the setup fee
        /// </summary>
        public int? initial_charge_in_cents { get; set; }
        /// <summary>
        /// The accounting code for this product
        /// </summary>
        public string accounting_code { get; set; }
        /// <summary>
        /// The unit of interval
        /// </summary>
        public string interval_unit { get; set; }
        /// <summary>
        /// The date/time the product was created
        /// </summary>
        public DateTime? created_at { get; set; }
        /// <summary>
        /// The ID of the product
        /// </summary>
        public int? id { get; set; }
        /// <summary>
        /// The URL the customer should be returned to
        /// </summary>
        public string return_url { get; set; }
        /// <summary>
        /// The interval used for the trial (ie, how long was the trial)
        /// </summary>
        public int? trial_interval { get; set; }
        /// <summary>
        /// Should the credit card information be required?
        /// </summary>
        public bool require_credit_card { get; set; }
        /// <summary>
        /// Should the credit card information be requested?
        /// </summary>
        public bool request_credit_card { get; set; }
        /// <summary>
        /// The expiration interval unit (ie. day/month)
        /// </summary>
        public string expiration_interval_unit { get; set; }
        /// <summary>
        /// The interval for this product
        /// </summary>
        public int? interval { get; set; }
        /// <summary>
        /// The price in cents for this product
        /// </summary>
        public int? price_in_cents { get; set; }
        /// <summary>
        /// The price in cents to trial this product
        /// </summary>
        public int? trial_price_in_cents { get; set; }
    }

    /// <summary>
    /// The payment profile
    /// </summary>
    public class PaymentProfile2
    {
        /// <summary>
        /// The date/time the payment profile was updated
        /// </summary>
        public DateTime? updated_at { get; set; }
        /// <summary>
        /// The current vault used by the payment profile
        /// </summary>
        public string current_vault { get; set; }
        /// <summary>
        /// The expiration month
        /// </summary>
        public int? expiration_month { get; set; }
        /// <summary>
        /// The billing city
        /// </summary>
        public string billing_city { get; set; }
        /// <summary>
        /// The customer vault token
        /// </summary>
        public string customer_vault_token { get; set; }
        /// <summary>
        /// The ID of the customer
        /// </summary>
        public int? customer_id { get; set; }
        /// <summary>
        /// The vault token
        /// </summary>
        public string vault_token { get; set; }
        /// <summary>
        /// The first name
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// The second line of the billing address
        /// </summary>
        public string billing_address_2 { get; set; }
        /// <summary>
        /// The billing country
        /// </summary>
        public string billing_country { get; set; }
        /// <summary>
        /// The billing state
        /// </summary>
        public string billing_state { get; set; }
        /// <summary>
        /// The type of card (ie. bogus/visa/mastercard/etc)
        /// </summary>
        public string card_type { get; set; }
        /// <summary>
        /// The first line of the billing address
        /// </summary>
        public string billing_address { get; set; }
        /// <summary>
        /// The last name
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// The date/time the payment/profile was created
        /// </summary>
        public DateTime? created_at { get; set; }
        /// <summary>
        /// The ID of the payment profile
        /// </summary>
        public int? id { get; set; }
        /// <summary>
        /// The zip/postal code of the billing
        /// </summary>
        public string billing_zip { get; set; }
        /// <summary>
        /// The masked card number 
        /// </summary>
        public string masked_card_number { get; set; }
        /// <summary>
        /// The expiration year
        /// </summary>
        public int? expiration_year { get; set; }
    }

    /// <summary>
    /// A transaction line item
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// The amount in cents
        /// </summary>
        public int? amount_in_cents { get; set; }
        /// <summary>
        /// The kind of transaction
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// The discount amount (in cents)
        /// </summary>
        public int? discount_amount_in_cents { get; set; }
        /// <summary>
        /// The taxable amount of the transaction (in cents)
        /// </summary>
        public int? taxable_amount_in_cents { get; set; }
        /// <summary>
        /// The transaction memo
        /// </summary>
        public string memo { get; set; }
        /// <summary>
        /// The type of transaction (ie. payment, refund, charge)
        /// </summary>
        public string transaction_type { get; set; }
        /// <summary>
        /// The id related to the component
        /// </summary>
        public int? component_id { get; set; }
    }

    /// <summary>
    /// The next billing manifest
    /// </summary>
    public class NextBillingManifest
    {
        /// <summary>
        /// The period type
        /// </summary>
        public string period_type { get; set; }
        /// <summary>
        /// The subtotal in cents
        /// </summary>
        public int? subtotal_in_cents { get; set; }
        /// <summary>
        /// The total tax in cents
        /// </summary>
        public int? total_tax_in_cents { get; set; }
        /// <summary>
        /// The total in cents
        /// </summary>
        public int? total_in_cents { get; set; }
        /// <summary>
        /// The list of line items
        /// </summary>
        public List<LineItem> line_items { get; set; }
        /// <summary>
        /// The end date
        /// </summary>
        public string end_date { get; set; }
        /// <summary>
        /// The start date
        /// </summary>
        public string start_date { get; set; }
        /// <summary>
        /// The total discount in cents
        /// </summary>
        public int? total_discount_in_cents { get; set; }
    }

    /// <summary>
    /// Customers are the people or entities that buy access to your Products via Subscriptions.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The company/organization name
        /// </summary>
        public string organization { get; set; }
        /// <summary>
        /// The date/time the customer was last updated
        /// </summary>
        public string updated_at { get; set; }
        /// <summary>
        /// The second line of the shipping address
        /// </summary>
        public string address_2 { get; set; }
        /// <summary>
        /// The first line of the shipping address
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// The customers email address
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// The shipping city
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// The customers first name
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// The shipping country
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// The shipping state
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// The customers last name (surname)
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// The date/time the customer was created
        /// </summary>
        public DateTime? created_at { get; set; }
        /// <summary>
        /// The phone number of the customer
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// The ID of the customer
        /// </summary>
        public int? id { get; set; }
        /// <summary>
        /// The reference value of the customer (usually related to their user ID for authentication/authorization)
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// The shipping zip/postal code
        /// </summary>
        public string zip { get; set; }
    }

    /// <summary>
    /// The signup object
    /// </summary>
    public class Signup2
    {
        /// <summary>
        /// The subscription related to the signup
        /// </summary>
        public Subscription subscription { get; set; }
        /// <summary>
        /// The product related to the signup
        /// </summary>
        public Product product { get; set; }
        /// <summary>
        /// The payment profile related to the signup
        /// </summary>
        public PaymentProfile2 payment_profile { get; set; }
        /// <summary>
        /// The next billing manifest
        /// </summary>
        public NextBillingManifest next_billing_manifest { get; set; }
        /// <summary>
        /// The customer related to the signup
        /// </summary>
        public Customer customer { get; set; }
    }

    /// <summary>
    /// Subscription Card Update Response
    /// </summary>
    public class SubscriptionCardUpdater
    {
        /// <summary>
        /// The payment profile
        /// </summary>
        public PaymentProfile2 payment_profile { get; set; }
    }

    /// <summary>
    /// A response from Chargify
    /// </summary>
    public class Response
    {
        /// <summary>
        /// The result of the request
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// Details about the signup
        /// </summary>
        public Signup2 signup { get; set; }
        /// <summary>
        /// Meta information
        /// </summary>
        public Result meta { get; set; }
        /// <summary>
        /// The object
        /// </summary>
        [JsonProperty("object")]
        public Object @object { get; set; }
        /// <summary>
        /// Response details about the card update action
        /// </summary>
        public SubscriptionCardUpdater subscriptioncardupdater { get; set; }
    }

    /// <summary>
    /// Resource error
    /// </summary>
    public class ResourceError
    {
        /// <summary>
        /// Attribute
        /// </summary>
        public string attribute { get; set; }
        /// <summary>
        /// Kind
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// The table
    /// </summary>
    public class Table
    {
        /// <summary>
        /// The list of resource errors
        /// </summary>
        public List<ResourceError> resource_errors { get; set; }
    }

    /// <summary>
    /// The object
    /// </summary>
    public class Object
    {
        /// <summary>
        /// The table
        /// </summary>
        public Table table { get; set; }
    }

    /// <summary>
    /// A "call" is a complete record of any call to Chargify Direct, which is both returned during the call 
    /// as well as being able to be retrieved after the fact for verification purposes.
    /// </summary>
    public class Call
    {
        /// <summary>
        /// The API ID associated with this call
        /// </summary>
        public string api_id { get; set; }

        /// <summary>
        /// The timestamp of this call. Should match the submitted secure parameter (request -> secure -> timestamp)
        /// </summary>
        public int? timestamp { get; set; }

        /// <summary>
        /// Was the call successful? (ie. was the response -> status_code 200?)
        /// </summary>
        public bool? success { get; set; }

        /// <summary>
        /// Details about the request submitted to the v2 endpoint
        /// </summary>
        public Request request { get; set; }

        /// <summary>
        /// Details the response to the call made to the v2 endpoint
        /// </summary>
        public Response response { get; set; }

        /// <summary>
        /// The nonce (if used). Should match the submitted secure parameter (request -> secure -> timestamp)
        /// </summary>
        public string nonce { get; set; }

        /// <summary>
        /// The ID of the call
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Was the call successful? (ie. was the response -> status_code 200?)
        /// </summary>
        public bool isSuccessful
        {
            get { return response.result.status_code == "200"; }
        }

        /// <summary>
        /// The list of errors being returned as part of the response (ie, why did the call fail?)
        /// </summary>
        public List<Error> Errors
        {
            get
            {
                return response != null ? response.result != null ? response.result.errors : new List<Error>() : new List<Error>();
            }
        }
    }
    #endregion
}
