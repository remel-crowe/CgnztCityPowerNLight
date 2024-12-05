using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CognizantDataverse.Services
{
    /// <summary>
    /// Service class to perform CRUD operations on Incident entities within the Dataverse environment.
    /// </summary>
    public class CaseService(IOrganizationService dataverseConnection) : IService<Incident>
    {
        private readonly IOrganizationService _dataverseConnection = dataverseConnection;
        
        /// <summary>
        /// Creates a new case in the Dataverse environment.
        /// </summary>
        /// <param name="case">The case to be created</param>
        /// <returns>The unique identifier (GUID) of the created case.</returns>
        public Guid Create(Incident @case)
        {
            try
            {
                return _dataverseConnection.Create(@case);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating case: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Retrieves a case by its unique identifier(ID).
        /// </summary>
        /// <param name="caseId">The unique identifier (GUID) of the case to retrieve.</param>
        /// <returns>The contact entity with the specified identifier.</returns>
        public Incident GetById(Guid caseId)
        {
            try
            {
                return (Incident)_dataverseConnection.Retrieve(Incident.EntityLogicalName, caseId, new ColumnSet(true));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving case: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Lists all cases in the Dataverse environment.
        /// </summary>
        /// <returns>A list of incident entities</returns>
        public List<Incident> GetAll()
        {
            try
            {
                var query = new QueryExpression(Incident.EntityLogicalName)
                {
                    ColumnSet = new ColumnSet(true)
                };
                return _dataverseConnection.RetrieveMultiple(query).Entities
                        .Select(entity => (Incident)entity).ToList();
                
            } catch (Exception ex)
            {
                throw new Exception($"Error retrieving cases: {ex.Message}");
            }
         
        }
        
        /// <summary>
        /// Updates an existing case in the Dataverse environment.
        /// </summary>
        /// <param name="case">The incident to be udpated</param>
        public void Update(Incident @case)
        {
            try
            {
                _dataverseConnection.Update(@case);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating case: {ex.Message}");
            }
        }
        public void Delete(Guid caseId)
        {
            try
            {
                _dataverseConnection.Delete(Incident.EntityLogicalName, caseId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting case: {ex.Message}");
            }
        }
        
    }

}


    
    
    
    
    
