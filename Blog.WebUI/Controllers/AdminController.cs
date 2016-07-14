using Blog.Entities;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Blog.Interface;

namespace Blog.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IArticleRepository _repository;
        public int pageSize = 4;

        public AdminController(IArticleRepository repo)
        {
            _repository = repo;
        }
        // GET: Admin
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

        [HttpPost]
        public ActionResult Delete(int articleID, int currentPage)
        {
            //дописать проверить на ноль
            Article deletedArticle = _repository.DeleteArticle(articleID);
            if (deletedArticle != null)
            {
                TempData["message"] = String.Format("Article {0} deleted", deletedArticle.NameArticle);
            }

            return RedirectToAction("Index", new { page = currentPage });
        }

        public ViewResult Edit(int articleID)
        {
            Article article = _repository.GetArticles()
                .FirstOrDefault(a => a.ArticleID == articleID);
            if (article == null)
            {
                article = new Article();
            }
            return View(article);
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if(ModelState.IsValid)
            {
                _repository.SaveArticle(article);
                TempData["message"] = String.Format("Article {0} saved", article.NameArticle);
                return RedirectToAction("Index");
            }
            else
            {
                return View(article);
            }
        }

        public ActionResult Create()
        {
            return RedirectToAction("Edit", new { articleID = 0 });
        }
        
    }
}