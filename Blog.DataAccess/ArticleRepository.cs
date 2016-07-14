using Blog.Entities;
using Blog.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.DataAccess
{
    public class ArticleRepository : IArticleRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Article> GetArticles()
        {
            List<Article> articles = _context.Articles.Include(c => c.Comments).ToList();
            return articles;
        }

        public IEnumerable<Comment> GetComments(int articleId)
        {
            return _context.Comments.Where(c => c.ArticleId == articleId).ToList(); ;
        }


        public void SaveArticle(Article article)
        {
            if (article.ArticleID == 0)
            {
                _context.Articles.Add(article);
            }
            else
            {
                Article dbArticle = _context.Articles.Find(article.ArticleID);
                if (dbArticle != null)
                {
                    dbArticle.Author = article.Author;
                    dbArticle.NameArticle = article.NameArticle;
                    dbArticle.TextArticle = article.TextArticle;
                }
            }
            _context.SaveChanges();
        }

        public Article DeleteArticle(int ArticleID)
        {
            Article dbArticle = _context.Articles.Find(ArticleID);
            if (dbArticle != null)
            {
                _context.Articles.Remove(dbArticle);
                _context.SaveChanges();
            }
            return dbArticle;
        }

        public void AddComment(int ArticleID, string text)
        {
            Comment comment = new Comment
            {
                ArticleId = ArticleID,
                TextComment = text
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
