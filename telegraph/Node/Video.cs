﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telegraph.Node
{
    public partial class NodeElement
    {
        public void AddVideo(string url, string caption = "")
        {
            if (!url.StartsWith(@"/file"))
            {
                throw new Exception("'url' please start with '/file**'");
            }
            Content content = new Content
            {
                Tag = tag.figure.ToString(),
                Children = new List<ChildElement>
                {
                    new ChildElement
                    {
                        ChildClass = new ChildClass
                        {
                            Tag = tag.video.ToString(),
                            Attrs = new Attrs
                            {
                                Src = url,
                                Preload = "auto",
                                Controls = "controls"
                            }
                        }
                    },
                    new ChildElement
                    {
                        ChildClass = new ChildClass
                        {
                            Tag = tag.figcaption.ToString(),
                            Children = new List<string>
                            {
                                caption
                            }
                        }
                    }
                }
            };
            Contents.Add(content);
        }
    }
}
