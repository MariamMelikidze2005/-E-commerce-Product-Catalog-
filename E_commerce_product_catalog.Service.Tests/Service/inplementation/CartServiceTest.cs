using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Data;
using E_commerce_Product_Catalog.Service.Models;
using E_commerce_Product_Catalog.Service.Repositories;
using E_commerce_Product_Catalog.Service.Services.Implementation;
using E_commerce_Product_Catalog.Service.Exceptions;
using Xunit;
using E_commerce_Product_Catalog.Service.Services.Abstractions.E_commerce_Product_Catalog.Service.Services.Abstractions;
using E_commerce_Product_Catalog.Service.Services.Abstractions;

public class CartServiceTests
{
    private readonly Mock<ICartRepository> _cartRepositoryMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<UpdateCartItemQuantityCommand> _updateCartItemQuantityCommandMock;
    private readonly CartService _cartService;

    public CartServiceTests()
    {
        // Mocking dependencies
        _cartRepositoryMock = new Mock<ICartRepository>();
        _productRepositoryMock = new Mock<IProductRepository>();
        _updateCartItemQuantityCommandMock = new Mock<UpdateCartItemQuantityCommand>();

        // Create an instance of CartService
        _cartService = new CartService(
            _cartRepositoryMock.Object,
            _productRepositoryMock.Object,
            _updateCartItemQuantityCommandMock.Object
        );
    }

    [Fact]
    public async Task AddToCartAsync_ShouldAddProductToCart_WhenQuantityIsValid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 2;
        var product = new Product { Id = productId, Quantity = 10 };

        _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
        _cartRepositoryMock.Setup(repo => repo.GetCartByUserIdAsync(It.IsAny<Guid>())).ReturnsAsync((Cart)null);
        _cartRepositoryMock.Setup(repo => repo.AddCartAsync(It.IsAny<Cart>())).Returns(Task.CompletedTask);

        // Act
        await _cartService.AddToCartAsync(userId, productId, quantity);

        // Assert
        _cartRepositoryMock.Verify(repo => repo.AddCartAsync(It.IsAny<Cart>()), Times.Once);
    }

    [Fact]
    public async Task UpdateProductQuantityAsync_ShouldUpdateQuantity_WhenValid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var newQuantity = 5;
        var product = new Product { Id = productId, Quantity = 10 };
        var cart = new Cart
        {
            UserId = userId,
            Items = new List<CartItem> { new CartItem { ProductId = productId, Quantity = 2 } }
        };

        _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
        _cartRepositoryMock.Setup(repo => repo.GetCartByUserIdAsync(It.IsAny<Guid>())).ReturnsAsync(cart);

        _updateCartItemQuantityCommandMock.Setup(cmd => cmd.Validate(It.IsAny<CartItem>()))
            .Returns(new FluentValidation.Results.ValidationResult());

        // Act
        await _cartService.UpdateProductQuantityAsync(userId, productId, newQuantity);

        // Assert
        Assert.Equal(newQuantity, cart.Items.First().Quantity);
        _cartRepositoryMock.Verify(repo => repo.UpdateCartAsync(It.IsAny<Cart>()), Times.Once);
    }

    [Fact]
    public async Task RemoveProductAsync_ShouldRemoveProduct_WhenValid()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var cart = new Cart
        {
            UserId = userId,
            Items = new List<CartItem> { new CartItem { ProductId = productId, Quantity = 2 } }
        };

        _cartRepositoryMock.Setup(repo => repo.GetCartByUserIdAsync(It.IsAny<Guid>())).ReturnsAsync(cart);

        // Act
        await _cartService.RemoveProductAsync(userId, productId);

        // Assert
        Assert.Empty(cart.Items);
        _cartRepositoryMock.Verify(repo => repo.UpdateCartAsync(It.IsAny<Cart>()), Times.Once);
    }

    [Fact]
    public async Task AddToCartAsync_ShouldThrowInvalidQuantityException_WhenQuantityIsZeroOrLess()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var quantity = 0; // Invalid quantity
        var product = new Product { Id = productId, Quantity = 10 };

        _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidQuantitiyOfCartItemExeption>(
            () => _cartService.AddToCartAsync(userId, productId, quantity)
        );

        Assert.Equal(productId, exception.ProductId);
    }

    [Fact]
    public async Task UpdateProductQuantityAsync_ShouldThrowArgumentException_WhenValidationFails()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();
        var invalidQuantity = -1;
        var product = new Product { Id = productId, Quantity = 10 };
        var cart = new Cart
        {
            UserId = userId,
            Items = new List<CartItem> { new CartItem { ProductId = productId, Quantity = 2 } }
        };

        _productRepositoryMock.Setup(repo => repo.GetProductByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
        _cartRepositoryMock.Setup(repo => repo.GetCartByUserIdAsync(It.IsAny<Guid>())).ReturnsAsync(cart);

        _updateCartItemQuantityCommandMock.Setup(cmd => cmd.Validate(It.IsAny<CartItem>()))
            .Returns(new FluentValidation.Results.ValidationResult(new[] { new FluentValidation.Results.ValidationFailure("Quantity", "Invalid quantity") }));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => _cartService.UpdateProductQuantityAsync(userId, productId, invalidQuantity)
        );

        Assert.Contains("Validation failed", exception.Message);
    }
}
