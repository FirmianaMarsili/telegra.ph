

using Newtonsoft.Json;

namespace telegraph.Reponse
{
    public class GetViews
    {
        [JsonProperty("views")]
        public int Views { get; set; }
    }
}
