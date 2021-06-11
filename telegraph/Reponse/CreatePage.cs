using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace telegraph.Reponse
{
    public class CreatePage
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        public List<Node.Content> Content { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }
    }
}
