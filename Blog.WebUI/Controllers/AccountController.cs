using Blog.WebUI.Infrastructure.Abstract;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider _authProvider;
        public AccountController (IAuthProvider provider)
        {
            _authProvider = provider;
        }
        // GET: Account
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.Login, model.Password))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или пароль");
                    return View();
                }
            }
            return View();
        }
    }
}