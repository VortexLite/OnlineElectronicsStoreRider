using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineElectronicsStore.Controllers;
using OnlineElectronicsStore.Domain.Entity;
using OnlineElectronicsStore.Domain.Enum;
using OnlineElectronicsStore.Domain.Response;
using OnlineElectronicsStore.Domain.ViewModels.Cart;
using OnlineElectronicsStore.Domain.ViewModels.Product;
using OnlineElectronicsStore.Service.Interfaces;

namespace Controllers;

public class Tests
{
    [Fact]
    public async Task AddCart_ReturnsPartialView_WithCartViewModel()
    {
        // Arrange
        var profileServiceMock = new Mock<IProfileService>();
        profileServiceMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ReturnsAsync(new BaseResponse<int> { Data = 1 });

        var shoppingCartItemServiceMock = new Mock<IShoppingCartItemService>();
        shoppingCartItemServiceMock.Setup(x => x.GetShoppingCartByAsync(It.IsAny<int>())).ReturnsAsync(new BaseResponse<List<CartViewModel>>());

        var controller = new CartController(profileServiceMock.Object, shoppingCartItemServiceMock.Object);

        // Act
        var result = await controller.AddCart(1);

        // Assert
        var viewResult = Assert.IsType<PartialViewResult>(result);
        Assert.IsType<BaseResponse<List<CartViewModel>>>(viewResult.Model);
    }

    [Fact]
    public async Task AddCart_ReturnsPartialView_WithCartViewModel_WhenProfileServiceFails()
    {
        // Arrange
        var profileServiceMock = new Mock<IProfileService>();
        profileServiceMock.Setup(x => x.GetByNameAsync(It.IsAny<string>())).ThrowsAsync(new System.Exception("Simulated error"));

        var shoppingCartItemServiceMock = new Mock<IShoppingCartItemService>();

        var controller = new CartController(profileServiceMock.Object, shoppingCartItemServiceMock.Object);

        // Act
        var result = await controller.AddCart(1);

        // Assert
        Assert.IsType<PartialViewResult>(result);
    }
    
    [Fact]
    public async Task ProductDetails_ReturnsViewResult_WithProductDetailViewModel()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();
        var productDetailViewModel = new ProductDetailViewModel { Id = 1, Name = "Test Product", Price = 100 };
        var baseresponse = new BaseResponse<ProductDetailViewModel>
            { Data = productDetailViewModel, StatusCode = StatusCode.OK };
        productServiceMock.Setup(service => service.GetProductDetailAsync(It.IsAny<int>()))
            .ReturnsAsync(baseresponse);
        var controller = new ProductController(productServiceMock.Object);

        // Act
        var result = await controller.ProductDetails(1);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<ProductDetailViewModel>(viewResult.ViewData.Model);
        Assert.Equal(productDetailViewModel, model);
    }

    [Fact]
    public async Task ProductDetails_ReturnsNotFoundResult_WhenProductNotFound()
    {
        // Arrange
        var productServiceMock = new Mock<IProductService>();
        productServiceMock.Setup(service => service.GetProductDetailAsync(It.IsAny<int>()))
            .ReturnsAsync((BaseResponse<ProductDetailViewModel>)null);
        var controller = new ProductController(productServiceMock.Object);

        // Act
        var result = await controller.ProductDetails(1);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
        Assert.Equal(404, notFoundResult.StatusCode);
    }
    
    [Fact]
        public async Task GetNavigationByCategoryId_Returns_JsonResult_With_Valid_Data()
        {
            // Arrange
            int categoryId = 1;
            var mockProducerService = new Mock<IProducerService>();
            var expectedProducers = new List<Producer>
            {
                new Producer { Id = 1, Name = "Producer1" },
                new Producer { Id = 2, Name = "Producer2" }
            };
            var response = new BaseResponse<List<Producer>>
            {
                StatusCode = StatusCode.OK,
                Data = expectedProducers
            };
            mockProducerService.Setup(service => service.NavigationRowsByIdAsync(categoryId))
                               .ReturnsAsync(response);
            var controller = new HomeController(null, mockProducerService.Object, null, null, null);

            // Act
            var result = await controller.GetNavigationByCategoryId(categoryId) as JsonResult;
            var actualData = result.Value as List<Producer>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(actualData);
            Assert.Equal(expectedProducers.Count, actualData.Count);
            for (int i = 0; i < expectedProducers.Count; i++)
            {
                Assert.Equal(expectedProducers[i].Id, actualData[i].Id);
                Assert.Equal(expectedProducers[i].Name, actualData[i].Name);
            }
        }

        [Fact]
        public async Task GetNavigationByCategoryId_Returns_Redirect_To_Error_Action_When_Service_Returns_Error()
        {
            // Arrange
            int categoryId = 1;
            var mockProducerService = new Mock<IProducerService>();
            var response = new BaseResponse<List<Producer>>
            {
                StatusCode = StatusCode.InternalServerError
            };
            mockProducerService.Setup(service => service.NavigationRowsByIdAsync(categoryId))
                               .ReturnsAsync(response);
            var controller = new HomeController(null, mockProducerService.Object, null, null, null);

            // Act
            var result = await controller.GetNavigationByCategoryId(categoryId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Error", result.ActionName);
        }
}
