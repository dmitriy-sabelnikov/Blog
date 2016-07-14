using Blog.DataAccess;
using Blog.Interface;
using Blog.WebUI.Infrastructure.Abstract;
using Blog.WebUI.Infrastructure.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Blog.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver (IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType); 
        }

        private void AddBindings()
        {
            _kernel.Bind<IArticleRepository>().To<ArticleRepository>();
            _kernel.Bind<ILoginUserRepository>().To<LoginUserRepository>();
            _kernel.Bind<IAuthProvider>().To<FromAuthProvider>();
        }
    }
}