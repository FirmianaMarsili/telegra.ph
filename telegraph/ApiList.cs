using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using telegraph.Reponse;

namespace telegraph
{
    /// <summary>
    /// https://telegra.ph/api
    /// </summary>
    public class ApiList
    {       
        public static async Task<CreateAccount> CreateAccount(string shortName, string authorName = null, string authorUrl = null)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["short_name"] = shortName,
                ["author_name"] = authorName,
                ["author_url"] = authorUrl
            };
            return await HttpWeb.PostAsync<CreateAccount>("createAccount", dic);
        }

        public static async Task<CreatePage> CreatePage(string token, string title, string nodes, string authorName = null, string authorUrl = null, bool returnContent = false)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                ["access_token"] = token,
                ["title"] = title,
                ["author_name"] = authorName,
                ["author_url"] = authorUrl,
                ["return_content"] = returnContent.ToString(),
                ["content"] = nodes

            };
            return await HttpWeb.PostAsync<CreatePage>("createPage", dic);
        }

        public static async Task<GetPage> GetPage(string path, bool returnContent = false)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["path"] = path,
                ["return_content"] = returnContent.ToString()
            };
            return await HttpWeb.PostAsync<GetPage>("getPage", dic);
        }

        public static async Task<EditAccountInfo> EditAccountInfo(string token, string shortName, string authorName = null, string authorUrl = null)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["access_token"] = token,
                ["short_name"] = shortName,
                ["author_name"] = authorName,
                ["author_url"] = authorUrl
            };
            return await HttpWeb.PostAsync<EditAccountInfo>("editAccountInfo", dic);
        }

        public static async Task<GetAccountInfo> GetAccountInfo(string token)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["access_token"] = token,
                ["fields"] = "[\"short_name\", \"author_name\", \"author_url\", \"auth_url\", \"page_count\"]"
            };
            return await HttpWeb.PostAsync<GetAccountInfo>("getAccountInfo", dic);
        }

        public static async Task<RevokeAccessToken> RevokeAccessToken(string token)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                ["access_token"] = token,
            };
            return await HttpWeb.PostAsync<RevokeAccessToken>("revokeAccessToken", dic);
        }

        public static async Task<EditPage> EditPage(string token, string path, string title, string nodes, string authorName = null, string authorUrl = null, bool returnContent = false)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                ["access_token"] = token,
                //["path"] = path,
                ["title"] = title,
                ["author_name"] = authorName,
                ["author_url"] = authorUrl,
                ["return_content"] = returnContent.ToString(),
                ["content"] = nodes

            };
            //IEnumerable<dynamic>
            return await HttpWeb.PostAsync<EditPage>($"editPage/{path}", dic);
            //return null;
        }

        public static async Task<GetPageList> GetPageList(string token, int offest = 0, int limit = 50)
        {
            if (offest < 0 || limit < 0 || limit > 200)
            {
                throw new Exception("offest must >= 0 and 0 =< limit  <= 200 ");
            }
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                ["access_token"] = token,
                ["offset"] = offest.ToString(),
                ["limit"] = limit.ToString(),
            };
            //IEnumerable<dynamic>
            return await HttpWeb.PostAsync<GetPageList>("getPageList", dic);
            //return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dateTime">y m d h</param>
        /// <returns></returns>
        public static async Task<GetViews> GetViews(string path, int? year = null, int? month = null, int? day = null, int? hour = null)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                ["path"] = path,
            };
            if (year != null)
            {
                dic["year"] = year.ToString();
            }
            if (month != null)
            {
                dic["month"] = month.ToString();
            }
            if (day != null)
            {
                dic["day"] = day.ToString();
            }
            if (hour != null)
            {
                dic["hour"] = hour.ToString();
            }
            return await HttpWeb.PostAsync<GetViews>("getViews", dic);
        }

        public static async Task<Upload> Upload(List<string> paths)
        {
            List<byte[]> bs = new List<byte[]>();
            for (int i = 0; i < paths.Count; i++)
            {
                string path = paths[i];
                if (File.Exists(path))
                {
                    bs.Add(File.ReadAllBytes(path));
                    //return HttpWeb.UploadAsync();
                }
                else
                {
                    bs.Add(await HttpWeb.DownloadFile(path));                    
                }
            }
            return await HttpWeb.UploadAsync(bs);
            
        }
        public static async Task<Upload> Upload(List<byte[]> b)
        {
            return await HttpWeb.UploadAsync(b);
        }

    }
}
