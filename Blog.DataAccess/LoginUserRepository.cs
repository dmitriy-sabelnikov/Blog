using Blog.Entities;
using Blog.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess
{
    public class LoginUserRepository : ILoginUserRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<LoginUser> GetLoginUser()
        {
            return _context.LoginUsers.ToList();
        }
    }
}
