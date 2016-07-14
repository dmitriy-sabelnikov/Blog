using Blog.Entities;
using Blog.Interface;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Blog.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IArticleRepository _repository;
        public int pageSize = 4;

        public BlogController (IArticleRepository repo)
        {
            _repository = repo;
        }
        // GET: Blog
        public ViewResult Index(int page = 1)
        {
            IEnumerable<Article> articles = _repository.GetArticles()
                .OrderBy(article => article.Author)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

                PagingInfo pageInfo = new PagingInfo
                {
                    TotalArticle = _repository.GetArticles().Count(),
                    ArticlePerPage = pageSize,
                    CurrentPage = page
                };

                ArticleListViewModel model = new ArticleListViewModel
                {
                    Articles = articles,
                    PageInfo = pageInfo
                };
            return View(model);
        }

        public ViewResult Article(int articleID)
        {
            Article article = _repository.GetArticles()
                .FirstOrDefault(a => a.ArticleID == articleID);
            return View(article);
        }

        [HttpPost]
        public PartialViewResult SetCommets(int articleId, string Comment)
        {
            if (Comment != String.Empty)
            {
                _repository.AddComment(articleId, Comment);
                Comment = String.Empty;
            }
            return PartialView("Comments", _repository.GetComments(articleId));
        }
    }
}