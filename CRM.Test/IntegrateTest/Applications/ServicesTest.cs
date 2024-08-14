


using Xunit;
using CRM.Domain.Services;
using FluentAssertions;
using CRM.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Net;
using CRM.Api.Controllers.Contracts;
using Microsoft.Extensions.Hosting;

namespace CRM.Test.IntegrateTest;
public class ServicesTest : IAsyncLifetime, IClassFixture<WebApplicationFactory<IApiMarker>>
{

    private readonly HttpClient _httpClient;
   private readonly string Host="/Services/v1/api/";
    public ServicesTest(WebApplicationFactory<IApiMarker> applicationFactory)
    {
        _httpClient = applicationFactory.CreateClient();
    }

    [Theory]
    [InlineData("subscription", 300)]
    [InlineData("LiveChat", 400)]
    public async Task CreateServices_WhenPostData_ShouldReturnHttpStatusCodeCreated(string name, Decimal price)
    {
        // Given

        CreateServiceRequest service = new(name, price);

        // When

        var response = await _httpClient.PostAsJsonAsync(Host+"Services", service);

        // Then
         var serviceResponse=await response.Content.ReadFromJsonAsync<CreateServiceResponse>();
         serviceResponse.Should().BeEquivalentTo(service);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }




    public Task DisposeAsync()
    {
        return Task.Delay(0);
    }

    public Task InitializeAsync()
    {
        return Task.Delay(0);
    }
}