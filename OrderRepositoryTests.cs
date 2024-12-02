namespace OrderService.Tests;

using System;
using Xunit;
using OrderService;

public class OrderRepositoryTests
{
    [Fact]
    public void GetOrderTrackingDetails_ShouldReturnCorrectOrder_WhenTrackingIdExists()
    {
        // Arrange
        var repository = new OrderRepository();
        var order = new Order
        {
            Id = 1,
            TotalAmount = 500m,
            TrackingId = "TRACK123",
            TrackingStatus = "På väg",
            EstimatedDelivery = DateTime.Now.AddDays(3)
        };
        repository.AddOrder(order);

        // Act
        var result = repository.GetOrderTrackingDetails("TRACK123");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(order.TrackingId, result.TrackingId);
        Assert.Equal(order.TrackingStatus, result.TrackingStatus);
        Assert.Equal(order.EstimatedDelivery, result.EstimatedDelivery);
    }

    [Fact]
    public void GetOrderTrackingDetails_ShouldThrowKeyNotFoundException_WhenTrackingIdDoesNotExist()
    {
        // Arrange
        var repository = new OrderRepository();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => repository.GetOrderTrackingDetails("INVALID_TRACKING"));
    }
}
