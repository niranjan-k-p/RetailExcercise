using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;
using WingtipToys.Controllers;
using WingtipToys.Repositories;

namespace WingtipToys.Tests.Controllers
{
    [TestFixture]
    public class ProductsControllerTest
    {
        private MoqMockingKernel _kernel;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _kernel = new MoqMockingKernel();

            _kernel.Bind<ICentralRepository>().To<CentralRepository>();
            _kernel.Bind<IProductsRepository>().To<ProductsRepository>();
            _kernel.Bind<ICartItemsRepository>().To<CartItemsRepository>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (_kernel != null)
            {
                _kernel.Dispose();
                _kernel = null;
            }
        }

        // TODO: Fix unit tests
        [Test]
        public async Task Index_ReturnsOnlyCarsAsViewData()
        {
            var productsController = new ProductsController(_kernel.Get<IProductsRepository>(), _kernel.Get<ICartItemsRepository>());

            var result = await productsController.Index() as ViewResult;

            var product = (Product) result.ViewData.Model;
        }

        // TODO: Add/complete unit tests
        [Test]
        public void AddToCart_ProductAlreadyAddedToCart_QuantityIncreasedByOne()
        {

        }

        [Test]
        public void AddToCart_ProductNewlyAddedToCart_UpdateCartItemsWithNewProduct()
        {

        }
    }
}