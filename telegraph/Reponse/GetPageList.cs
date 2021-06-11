using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegraph.Reponse
{
    public class GetPageList
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("pages")]
        public List<Page> Pages { get; set; }        
    }
    public class Page
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ImageUrl { get; set; }

        [JsonProperty("views")]
        public long Views { get; set; }

        [JsonProperty("can_edit")]
        public bool CanEdit { get; set; }
    }
}
