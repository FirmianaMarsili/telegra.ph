using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace telegraph.Reponse
{
    public class Upload
    {
        //[JsonProperty("src")]
        public List<Src_Upload> Srcs { get; set; }
        public static Upload FromJson(string json)
        {
            JArray array = JArray.Parse(json);
            Upload upload = new Upload
            {
                Srcs = new List<Src_Upload>()
            };
            for (int i = 0; i < array.Count; i++)
            {
                upload.Srcs.Add(JsonConvert.DeserializeObject<Src_Upload>(array[i].ToString(), Converter.Settings) );
            }
            return upload;
        }
    }
    public class Src_Upload
    {
        [JsonProperty("src")]
        public string Src { get; set; }
    }
}
