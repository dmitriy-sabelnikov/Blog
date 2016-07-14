using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Interface
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
        IEnumerable<Comment> GetComments(int articleId);

        void SaveArticle(Article article);
        Article DeleteArticle(int ArticleID);

        void AddComment(int ArticleID, string text);
    }
}
