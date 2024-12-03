using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;


namespace CognizantDataverse.App;

public class CustomerServiceHubAPI(IOrganizationService accountService, IOrganizationService caseService, IOrganizationService contactService)
{
    private IOrganizationService _accountService = accountService;
    private IOrganizationService _caseService = caseService;
    private IOrganizationService _contactService = contactService;

    public void Run()
    {
        
        
    }
}
