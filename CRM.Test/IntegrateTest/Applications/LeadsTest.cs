


using Xunit;
using CRM.Domain.Leads;
using FluentAssertions;
namespace CRM.Test.IntegrateTest;
public class LeadsTest : IAsyncLifetime
{

   
    public Task InitializeAsync()
    {
        return Task.Delay(0);
    }
     public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}