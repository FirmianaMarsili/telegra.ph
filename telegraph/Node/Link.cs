using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegraph.Node
{
    public partial class NodeElement
    {
        public void AddLink(string link)
        {
            Content content = new Content()
            {
                Tag = tag.p.ToString(),
                Children = new List<ChildElement>
                {
                    new ChildElement
                    {
                        ChildClass = new ChildClass
                        {
                            Tag = tag.a.ToString(),
                            Attrs = new Attrs
                            {
                                Href = new Uri( link),
                                Target = "_blank"
                            },
                            Children = new List<string>
                            {
                                link
                            }
                        }
                    },
                }
            };
            Contents.Add(content);
        }
    }
}
