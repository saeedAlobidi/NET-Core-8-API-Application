


using Xunit;
using CRM.Domain.Services;
using FluentAssertions;
namespace CRM.Test.UnitTest.Domain;
public class ServicesTest : IAsyncLifetime
{

    [Theory]
    [InlineData("subscription", 300)]
    public async Task CreateServices_WhenAllParameterIsAvailable_ShouldCreateService(string name, Decimal price)
    {
        // Given

        Service Service = new Service { name = name, price=price };

        // When

        var resultStatus = await Service.AddService();

        // Then

        resultStatus.IsError.Should().Be(false);
    }



    [Theory]
    [InlineData("subscription", 0)]
    public async Task CreateServices_WhenPriceIsZero_ShouldNotCreateService(string name, Decimal price)
    {
        // Given

        Service Service = new Service { name = name, price=price };

        // When

        var resultStatus = await Service.AddService();

        // Then

       
        resultStatus.IsError.Should().Be(true);
    }
 
    public Task InitializeAsync()
    {
        return Task.Delay(0);
    }
  public Task DisposeAsync()
    {
      return Task.CompletedTask;
    }

}