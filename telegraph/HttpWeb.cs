using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace telegraph
{
    internal class HttpWeb
    {
        public static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://api.telegra.ph/"),
            Timeout = new TimeSpan(0, 0, 5)
        };

        private static HttpClient _uploadClient;
        private static HttpClient UploadClient
        {
            get
            {
                if (_uploadClient == null)
                {
                    _uploadClient = new HttpClient
                    {
                        BaseAddress = new Uri("https://telegra.ph/")
                    };
                }
                return _uploadClient;
            }
        }

        private static HttpClient _downloadClient;
        private static HttpClient DownloadClient
        {
            get
            {
                if (_downloadClient == null)
                {
                    _downloadClient = new HttpClient();
                }
                return _downloadClient;
            }
        }

        public static async Task<T> PostAsync<T>(string method, Dictionary<string, string> dic)
        {
            //var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var content = new FormUrlEncodedContent(dic.Select(e => new KeyValuePair<string, string>(e.Key, e.Value)));
            var response = await client.PostAsync(method, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = Reponse.ReponseBase<T>.FromJson(responseString);
            if (result.Ok)
            {
                return result.Result;
            }
            else
            {
                throw new Exception($"{method}  \n{result.Error}");
            }
        }

        public static async Task<Reponse.Upload> UploadAsync(List<byte[]> b)
        {
            var content = new MultipartFormDataContent();
            for (int i = 0; i < b.Count; i++)
            {
                content.Add(new ByteArrayContent(b[i]), "file" + i.ToString(), "file" + i.ToString());
            }            
            var result = await UploadClient.PostAsync("upload", content).Result.Content.ReadAsStringAsync();
            return Reponse.Upload.FromJson(result);
            //return result;
        }

        public static async Task<byte[]> DownloadFile(string url)
        {
            using (HttpResponseMessage response = DownloadClient.GetAsync(url).Result)
            {
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    byte[] b = new byte[streamToReadFrom.Length];
                    streamToReadFrom.Read(b, 0, b.Length);

                    // 设置当前流的位置为流的开始 
                    streamToReadFrom.Seek(0, SeekOrigin.Begin);
                    return b;
                }
            }

        }
    }
}
