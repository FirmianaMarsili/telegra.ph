using Newtonsoft.Json;
using System;

namespace telegraph.Reponse
{
    public class GetAccountInfo
    {
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("auth_url")]
        public Uri AuthUrl { get; set; }

        [JsonProperty("page_count")]
        public long PageCount { get; set; }
    }
}
