using CognizantDataverse.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace CognizantDataverse.Services
{
    /// <summary>
    /// Service class to perform CRUD operations on Incident entities within the Dataverse environment.
    /// </summary>
    public class CaseService(IOrganizationService dataverseConnection)
    {
        private readonly IOrganizationService _dataverseConnection = dataverseConnection;
        
        /// <summary>
        /// Creates a new case in the Dataverse environment.
        /// </summary>
        /// <param name="case">The case to be created</param>
        /// <returns>The unique identifier (GUID) of the created case.</returns>
        public Guid CreateCase(Incident @case)
        {
            try
            {
                return _dataverseConnection.Create(@case);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating case: {ex.Message}");
                throw;
            }
        }
        
        /// <summary>
        /// Retrieves a case by its unique identifier(ID).
        /// </summary>
        /// <param name="caseId">The unique identifier (GUID) of the case to retrieve.</param>
        /// <returns>The contact entity with the specified identifier.</returns>
        public Incident GetCaseById(Guid caseId)
        {
            try
            {
                return (Incident)_dataverseConnection.Retrieve(Incident.EntityLogicalName, caseId, new ColumnSet(true));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving case: {ex.Message}");
                throw;
            }
        }
        
        
        public List<Incident> GetCases()
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
                Console.WriteLine($"Error retrieving cases: {ex.Message}");
                throw;
            }
         
        }
        
        public void UpdateCase(Incident @case)
        {
            try
            {
                _dataverseConnection.Update(@case);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating case: {ex.Message}");
                throw;
            }
        }
        
        public void DeleteCase(Guid caseId)
        {
            try
            {
                _dataverseConnection.Delete(Incident.EntityLogicalName, caseId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting case: {ex.Message}");
                throw;
            }
        }

        
        // public List<Incident> GetCasesBySearchTerm(string searchTerm)
        // {
        //     try
        //     {
        //         var query = new QueryExpression(Incident.EntityLogicalName)
        //         {
        //             ColumnSet = new ColumnSet(true),
        //             Criteria = new FilterExpression
        //             {
        //                 FilterOperator = LogicalOperator.Or,
        //                 Conditions =
        //                 {
        //                     new ConditionExpression("incidentid", ConditionOperator.Equal, searchTerm),
        //                     new ConditionExpression("title", ConditionOperator.Like, $"%{searchTerm}%"),
        //                     new ConditionExpression("description", ConditionOperator.Like, $"%{searchTerm}%")
        //                 }
        //             }
        //         };
        //
        //         return _dataverseConnection.RetrieveMultiple(query).Entities
        //             .Select(entity => (Incident)entity).ToList();
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error retrieving case: {ex.Message}");
        //         throw;
        //     }
        // }
    }

}


    
    
    
    
    
