
using Newtonsoft.Json;
using System;

namespace telegraph.Reponse
{
    public class ReponseBase<T>
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        public static ReponseBase<T> FromJson(string json) => JsonConvert.DeserializeObject<ReponseBase<T>>(json, Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
            Formatting = Formatting.Indented,
            Converters =
            {
                Node.ChildElementConverter.Singleton,
            },
        };
    }    
}



