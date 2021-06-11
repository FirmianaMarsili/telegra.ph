using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace telegraph.Reponse
{
    public class GetPage
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public Uri Description { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("content")]
        public List<Node.Content> Content { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }
    }
}
