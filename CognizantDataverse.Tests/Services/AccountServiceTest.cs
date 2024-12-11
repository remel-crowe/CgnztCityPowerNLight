using CognizantDataverse.Model.Entities;
using CognizantDataverse.Services;
using Microsoft.Xrm.Sdk;
using Moq;

namespace CognizantDataverse.Tests.Services;

public class AccountServiceTests
{
    [Fact]
    public void Create_ShouldReturnValidGuid()
    {
        //Arrange
        var mockOrganizationService = new Mock<IOrganizationService>();
        var testAccount = new Account {Name = "Test Account", EMailAddress1 = "Testmail@mail.com"};
        var expectedGuid = Guid.NewGuid();
        
        mockOrganizationService.Setup(service => service.Create(It.IsAny<Account>())).Returns(expectedGuid);
        var accountService = new AccountService(mockOrganizationService.Object);

        //Act
        var result = accountService.Create(testAccount);
        
        //Assert
        Assert.Equal(expectedGuid, result);
    }
}