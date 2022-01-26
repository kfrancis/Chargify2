using System;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace Chargify2
{
    internal class DynamicJsonDeserializer : IRestSerializer, ISerializer, IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public ISerializer Serializer => this;

        public IDeserializer Deserializer => this;

        public string[] AcceptedContentTypes { get; } = { "application/json", "text/json", "text/x-json", "text/javascript", "*+json" };

        public SupportsContentType SupportsContentType => contentType => contentType.EndsWith("json", StringComparison.InvariantCultureIgnoreCase);

        public DataFormat DataFormat => DataFormat.Json;

        public string ContentType { get; set; } = "application/json";

        public T Deserialize<T>(RestResponse response) => JsonConvert.DeserializeObject<dynamic>(response.Content);

        public string Serialize(Parameter parameter) => Serialize(parameter.Value);

        public string Serialize(object obj) => JsonConvert.SerializeObject(obj);
    }
}
