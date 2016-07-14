using Blog.Entities;
using Blog.WebUI.Infrastructure.Abstract;
using System.Web.Security;
using System.Linq;
using Blog.Interface;

namespace Blog.WebUI.Infrastructure.Concrete
{
    public class FromAuthProvider : IAuthProvider
    {
        private ILoginUserRepository _repository;

        public FromAuthProvider(ILoginUserRepository repo)
        {
            _repository = repo;
        }

        public bool Authenticate(string username, string password)
        {
            LoginUser loginUser = _repository.GetLoginUser()
                .FirstOrDefault(u => u.Login == username && u.Password == password);
            if (loginUser == null)
                return false;
            FormsAuthentication.SetAuthCookie(username, false);
            return true;
        }
    }
}