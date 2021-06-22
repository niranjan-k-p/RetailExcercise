using System;
using System.Collections.Generic;
using Ninject;
using WingtipToys.Repositories;

namespace WingtipToys
{
    public class NinjectResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel();
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
            _kernel.Bind<ICentralRepository>().To<CentralRepository>().InSingletonScope();

            _kernel.Bind<IProductsRepository>().To<ProductsRepository>().InSingletonScope()
                .WithConstructorArgument("centralRepository", _kernel.Get<ICentralRepository>());

            _kernel.Bind<ICartItemsRepository>().To<CartItemsRepository>().InSingletonScope()
                .WithConstructorArgument("centralRepository", _kernel.Get<ICentralRepository>());
        }
    }
}