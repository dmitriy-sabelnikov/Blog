using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string TextComment { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
