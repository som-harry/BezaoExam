using Ninject;
using RecruitingProject.Interface;
using RecruitingProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace RecruitingProject.Infrastructure
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public NinjectResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<IApplicant>().To<ApplicantService>();
        }

        public IDependencyScope BeginScope()
        {

            return new NinjectResolver(_kernel);
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)_kernel;
            if (disposable != null) disposable.Dispose();
            _kernel = null;
        }

        public object GetService(Type serviceType) => _kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => _kernel.GetAll(serviceType);

    }
}