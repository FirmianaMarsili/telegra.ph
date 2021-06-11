using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegraph.Reponse
{
    public class CreateAccount
    {
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("author_name")]
        public string AuthorName { get; set; }

        [JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("auth_url")]
        public Uri AuthUrl { get; set; }
    }
}
