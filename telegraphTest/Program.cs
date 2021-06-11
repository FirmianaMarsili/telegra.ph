using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using telegraph;
using telegraph.Node;
using picacomic;

namespace telegraphTest
{
    class Program
    {
        public static string token = "";
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            #region 获取官方示例页面,并重建为自己的一个页面
            var getPage = await ApiList.GetPage("Sample-Page-12-15", true);
           
            NodeElement nodeElement = new NodeElement();            
            nodeElement.Contents = getPage.Content;

            var createPage = await ApiList.CreatePage(token, getPage.Title, nodeElement.ToJson());
            #endregion


            #region 新建一个页面

            NodeElement node = new NodeElement();
            node.AddText("第一行");
            node.AddText("第二行并添加一个回车\n");
            node.AddText("第四行并添加一个回车\n\n第六行");            
            node.AddText("第七行");            
            var createPage_1 = await ApiList.CreatePage(token, "测试", node.ToJson());
            Console.WriteLine(createPage_1.Url.AbsoluteUri);
            #endregion            
            Console.ReadLine();
        }
    }
}
