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
            var getPage = await ApiList.GetPage("Sample-Page-12-15",true);
            NodeElement nodeElement = new NodeElement();
            nodeElement.Contents = getPage.Content;
            var createPage = await ApiList.CreatePage(token, getPage.Title, nodeElement.ToJson());
            Console.ReadLine();
        }
    }
}
