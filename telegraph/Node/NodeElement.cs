using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace telegraph.Node
{
    public partial class NodeElement
    {
        enum tag
        {
            figure,
            img,
            figcaption,
            p,
            br,
            a,
            video
        }

        [JsonProperty("content")]
        public List<Content> Contents { get; set; }
        public NodeElement()
        {
            Contents = new();
        }

        //public Content AddBR()
        //{
            
        //    return content;
        //}


    }
    public static class Serialize
    {
        public static string ToJson(this NodeElement self)
        {
            ////在编辑以后加一个换行            
            //self.AddText();
            
            return JObject.Parse(JsonConvert.SerializeObject(self, Converter.Settings))["content"].ToString();
        }
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
                ChildElementConverter.Singleton,
            },
        };
    }
    internal class ChildElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ChildElement) || t == typeof(ChildElement?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new ChildElement { String = stringValue };
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<ChildClass>(reader);
                    return new ChildElement { ChildClass = objectValue };                    
            }
            throw new Exception("Cannot unmarshal type ChildElement");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ChildElement)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.ChildClass != null)
            {
                serializer.Serialize(writer, value.ChildClass);
                return;
            }
            throw new Exception("Cannot marshal type ChildElement");
        }

        public static readonly ChildElementConverter Singleton = new ChildElementConverter();
    }
    public class Content
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("children")]
        public List<ChildElement> Children { get; set; }
    }

    public class ChildClass
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("attrs", NullValueHandling = NullValueHandling.Ignore)]
        public Attrs Attrs { get; set; }

        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Children { get; set; }
    }

    public class Attrs
    {
        [JsonProperty("src", NullValueHandling = NullValueHandling.Ignore)]
        public string Src { get; set; }

        [JsonProperty("href", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Href { get; set; }

        [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

        [JsonProperty("preload", NullValueHandling = NullValueHandling.Ignore)]
        public string Preload { get; set; }

        [JsonProperty("controls", NullValueHandling = NullValueHandling.Ignore)]
        public string Controls { get; set; }
    }

    public struct ChildElement
    {
        public ChildClass ChildClass;
        public string String;

        public static implicit operator ChildElement(ChildClass ChildClass) => new ChildElement { ChildClass = ChildClass };
        public static implicit operator ChildElement(string String) => new ChildElement { String = String };
    }

}

