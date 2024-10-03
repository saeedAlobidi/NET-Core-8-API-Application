


using Xunit;
using CRM.Domain.Leads;
using FluentAssertions;
namespace CRM.Test.UnitTest.Domain;
public class LeadsTest : IAsyncLifetime
{

    // you have to write all the case 

    [Theory]
    [InlineData("saeed", 30, "saeed1adm@gamil.com", "https://www.linkedin.com/in/saeed-mohammed-al-obidi-289082147/")]
    public async Task CreateLeads_WhenAllParameterIsAvailable_ShouldCreateLead(string name, int age, string email, string linkedin)
    {
        // Given

      //  Lead lead = new Lead { name = name, age = age, email = email, linkedin = linkedin };

        // When

       // var resultStatus = await lead.ValidateAsync();

        // Then

      //  resultStatus.IsError.Should().Be(false);
    }



    [Theory]
    [InlineData("saeed", 30, "saeed1adm@gamil.com")]
    public async Task addLead_retrunError_whenOneOfVariableIsNotInitilze(string name, int age, string email)
    {
        // Given

        //Lead lead = new Lead { name = name, age = age, email = email };

        // When

     //   var resultStatus = await lead.ValidateAsync();

        // Then

      //  resultStatus.IsError.Should().Be(true);

    }

    [Theory]
    [InlineData("saeed", 30, "saeed1adm@gamil")]
    public async Task addLead_retrunError_whenEmailIsNotTrue(string name, int age, string email)
    {
        // Given

     //   Lead lead = new Lead { name = name, age = age, email = email };

        // When

     //   var resultStatus = await lead.ValidateAsync();

        // Then

      //  resultStatus.IsError.Should().Be(true);

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