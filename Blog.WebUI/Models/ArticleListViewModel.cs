using Blog.Entities;
using System.Collections.Generic;

namespace Blog.WebUI.Models
{
    public class ArticleListViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public PagingInfo PageInfo { get; set; }
    }
}