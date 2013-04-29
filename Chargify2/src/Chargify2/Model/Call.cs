using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chargify2.Model
{
    /// <summary>
    /// Generated with http://json2csharp.com/ based on the return of a single call
    /// </summary>
    #region Json2Class Generated
    public class PaymentProfile
    {
        public string billing_address { get; set; }
        public string card_number { get; set; }
        public string first_name { get; set; }
        public string expiration_month { get; set; }
        public string expiration_year { get; set; }
        public string billing_city { get; set; }
        public string last_name { get; set; }
        public string billing_zip { get; set; }
        public string billing_country { get; set; }
        public string billing_state { get; set; }
    }

    public class Product
    {
        public string handle { get; set; }
    }

    public class Customer
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }

    public class Signup
    {
        public PaymentProfile payment_profile { get; set; }
        public Product product { get; set; }
        public Dictionary<string, string> components { get; set; }
        public Customer customer { get; set; }
    }

    public class Secure
    {
        public string timestamp { get; set; }
        public string nonce { get; set; }
        public string signature { get; set; }
        public string data { get; set; }
        public string api_id { get; set; }
    }

    public class Request
    {
        public Signup signup { get; set; }
        public Secure secure { get; set; }
    }

    public class Result
    {
        public string status_code { get; set; }
        public List<object> errors { get; set; }
        public string result_code { get; set; }
    }

    public class Subscription
    {
        public object delayed_cancel_at { get; set; }
        public string next_assessment_at { get; set; }
        public object activated_at { get; set; }
        public string current_period_started_at { get; set; }
        public bool cancel_at_end_of_period { get; set; }
        public int signup_payment_id { get; set; }
        public int balance_in_cents { get; set; }
        public object cancellation_message { get; set; }
        public int product_id { get; set; }
        public object expires_at { get; set; }
        public string signup_revenue { get; set; }
        public int customer_id { get; set; }
        public string trial_started_at { get; set; }
        public string current_period_ends_at { get; set; }
        public int payment_profile_id { get; set; }
        public string updated_at { get; set; }
        public object canceled_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
        public string state { get; set; }
        public string trial_ended_at { get; set; }
        public string previous_state { get; set; }
    }

    public class PaymentProfile2
    {
        public string billing_address { get; set; }
        public object billing_address_2 { get; set; }
        public string current_vault { get; set; }
        public string first_name { get; set; }
        public string masked_card_number { get; set; }
        public int expiration_month { get; set; }
        public object customer_vault_token { get; set; }
        public string billing_city { get; set; }
        public int expiration_year { get; set; }
        public string last_name { get; set; }
        public int customer_id { get; set; }
        public string billing_country { get; set; }
        public string billing_zip { get; set; }
        public string card_type { get; set; }
        public string billing_state { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
        public string vault_token { get; set; }
    }

    public class Product2
    {
        public bool request_credit_card { get; set; }
        public object expiration_interval { get; set; }
        public bool require_credit_card { get; set; }
        public string accounting_code { get; set; }
        public int trial_price_in_cents { get; set; }
        public string description { get; set; }
        public int price_in_cents { get; set; }
        public int interval { get; set; }
        public string return_url { get; set; }
        public object initial_charge_in_cents { get; set; }
        public string name { get; set; }
        public string expiration_interval_unit { get; set; }
        public string return_params { get; set; }
        public int product_family_id { get; set; }
        public string updated_at { get; set; }
        public string interval_unit { get; set; }
        public string created_at { get; set; }
        public int id { get; set; }
        public string trial_interval_unit { get; set; }
        public int trial_interval { get; set; }
        public string handle { get; set; }
        public object archived_at { get; set; }
    }

    public class Customer2
    {
        public object zip { get; set; }
        public object organization { get; set; }
        public object reference { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string updated_at { get; set; }
        public string created_at { get; set; }
        public object city { get; set; }
        public object country { get; set; }
        public object address_2 { get; set; }
        public int id { get; set; }
        public object state { get; set; }
        public object address { get; set; }
        public object phone { get; set; }
    }

    public class LineItem
    {
        public string memo { get; set; }
        public int amount_in_cents { get; set; }
        public int taxable_amount_in_cents { get; set; }
        public int discount_amount_in_cents { get; set; }
        public string kind { get; set; }
        public string transaction_type { get; set; }
        public int? component_id { get; set; }
    }

    public class NextBillingManifest
    {
        public string period_type { get; set; }
        public int total_in_cents { get; set; }
        public int total_discount_in_cents { get; set; }
        public string end_date { get; set; }
        public List<LineItem> line_items { get; set; }
        public int subtotal_in_cents { get; set; }
        public string start_date { get; set; }
        public int total_tax_in_cents { get; set; }
    }

    public class Signup2
    {
        public Subscription subscription { get; set; }
        public PaymentProfile2 payment_profile { get; set; }
        public Product2 product { get; set; }
        public Customer2 customer { get; set; }
        public NextBillingManifest next_billing_manifest { get; set; }
    }

    public class Meta
    {
        public string status_code { get; set; }
        public List<string> errors { get; set; }
        public string result_code { get; set; }
    }

    public class Response
    {
        public Result result { get; set; }
        public Signup2 signup { get; set; }
        public Meta meta { get; set; }
    }

    public class Call
    {
        public string api_id { get; set; }
        public int timestamp { get; set; }
        public bool success { get; set; }
        public Request request { get; set; }
        public Response response { get; set; }
        public string nonce { get; set; }
        public string id { get; set; }

        public bool isSuccessful
        {
            get { return this.response.result.status_code == "200"; }
        }

        public List<object> Errors
        {
            get
            {
                return response.result.errors;
            }
        }
    }
    #endregion
}
