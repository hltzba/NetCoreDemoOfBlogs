using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDemo.Core.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime PostTime { get; set; }
    }
}
