using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegraph.Node
{
    public partial class NodeElement
    {
        public void AddText(string text = null)
        {
            if (!string.IsNullOrEmpty(text) && text.Contains('\n'))
            {
                string[] msg = text.Split('\n');
                for (int i = 0; i < msg.Length; i++)
                {
                    AddText(msg[i]);
                }
            }
            else
            {
                Content content = new Content()
                {
                    Tag = tag.p.ToString(),                    
                };                
                if (string.IsNullOrEmpty(text))
                {
                    content.Children = new List<ChildElement>
                    {
                        new ChildElement
                        {
                             ChildClass = new ChildClass
                            {
                                Tag = tag.br.ToString()

                            }
                        }
                    };

                }
                else
                {
                    content.Children = new List<ChildElement>
                    {
                        new ChildElement
                        {
                             ChildClass = new ChildClass
                            {
                                 Children = new List<string>
                                 { 
                                     text
                                 }
                            }
                        }
                    };
                }
                Contents.Add(content);
            }
        }
    }
}
