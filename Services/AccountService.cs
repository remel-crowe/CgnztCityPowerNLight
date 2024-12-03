using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CognizantDataverse.Services
{
    /// <summary>
    /// Service class to perform CRUD operations on Account entities within the Dataverse environment.
    /// </summary>
    public class AccountService(IOrganizationService dataverseConnection)
    {
        private readonly IOrganizationService _dataverseConnection = dataverseConnection;

        /// <summary>
        /// Creates a new account in the Dataverse environment.
        /// </summary>
        /// <param name="account">The account entity to be created.</param>
        /// <returns>The unique identifier (GUID) of the created account.</returns>
        public Guid CreateAccount(Account account)
        {
            return _dataverseConnection.Create(account);
        }

        /// <summary>
        /// Retrieves an account by its unique identifier.
        /// </summary>
        /// <param name="accountId">The unique identifier (GUID) of the account to retrieve.</param>
        /// <returns>The account entity with the specified identifier.</returns>
        public Account GetAccountById(Guid accountId)
        {
            return (Account)_dataverseConnection.Retrieve(Account.EntityLogicalName, accountId, new ColumnSet(true));
        }

        /// <summary>
        /// Updates an existing account in the Dataverse environment.
        /// </summary>
        /// <param name="account">The account entity with updated information.</param>
        public void UpdateAccount(Account account)
        {
            _dataverseConnection.Update(account);
        }

        /// <summary>
        /// Deletes an account from the Dataverse environment.
        /// </summary>
        /// <param name="accountId">The unique identifier (GUID) of the account to delete.</param>
        public void DeleteAccount(Guid accountId)
        {
            _dataverseConnection.Delete(Account.EntityLogicalName, accountId);
        }

        /// <summary>
        /// Retrieves all accounts from the Dataverse environment.
        /// </summary>
        /// <returns>A list of all account entities.</returns>
        public List<Account> GetAccounts()
        {
            var query = new QueryExpression(Account.EntityLogicalName)
            {
                ColumnSet = new ColumnSet(true)
            };
            var accounts = _dataverseConnection.RetrieveMultiple(query).Entities;
            List<Account> accountList = new();
            foreach (var account in accounts)
            {
                accountList.Add((Account)account);
            }
            return accountList;
        }
    }
}