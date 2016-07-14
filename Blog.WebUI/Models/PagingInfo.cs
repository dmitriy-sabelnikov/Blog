using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalArticle { get; set; }
        public int ArticlePerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage
        {
            get { return (int)Math.Ceiling((decimal)TotalArticle / ArticlePerPage); }
        }
    }
}