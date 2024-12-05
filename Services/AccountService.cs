using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


namespace CognizantDataverse.Services
{
    /// <summary>
    /// Service class to perform CRUD operations on Account entities within the Dataverse environment.
    /// </summary>
    public class AccountService(IOrganizationService dataverseConnection) : IService<Account>
    {
        private readonly IOrganizationService _dataverseConnection = dataverseConnection;
        
        /// <summary>
        /// Creates a new account in the Dataverse environment.
        /// </summary>
        /// <param name="account">The account entity to be created.</param>
        /// <returns>The unique identifier (GUID) of the created account.</returns>
        public Guid Create(Account account)
        {
            try
            {
                return _dataverseConnection.Create(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating account: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieves an account by its unique identifier.
        /// </summary>
        /// <param name="accountId">The unique identifier (GUID) of the account to retrieve.</param>
        /// <returns>The account entity with the specified identifier.</returns>
        public Account GetById(Guid accountId)
        {
            try
            {
                return (Account)_dataverseConnection.Retrieve(Account.EntityLogicalName, accountId, new ColumnSet(true));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving account: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing account in the Dataverse environment.
        /// </summary>
        /// <param name="account">The account entity with updated information.</param>
        public void Update(Account account)
        {
            try
            {
                _dataverseConnection.Update(account);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating account: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes an account from the Dataverse environment.
        /// </summary>
        /// <param name="accountId">The unique identifier (GUID) of the account to delete.</param>
        public void Delete(Guid accountId)
        {
            try
            {
                _dataverseConnection.Delete(Account.EntityLogicalName, accountId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting account: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieves all accounts from the Dataverse environment.
        /// </summary>
        /// <returns>A list of all account entities.</returns>
        public List<Account> GetAll()
        {
            try
            {
                var query = new QueryExpression(Account.EntityLogicalName)
                {
                    ColumnSet = new ColumnSet(true)
                };
                return _dataverseConnection.RetrieveMultiple(query).Entities
                        .Select(account => (Account)account).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving accounts: {ex.Message}", ex);
            }
        }
    }
}