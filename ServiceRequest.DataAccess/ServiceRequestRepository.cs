using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest.DataAccess
{
    public class ServiceRequestRepository : BaseRepository
    {
        public List<ServiceRequest> SearchRequests()
        {
            return DbContext.serviceRequests.ToList();
        }

        public ServiceRequest GetServiceRequest(Guid requestId)
        {
            var request = DbContext.serviceRequests.FirstOrDefault(sr => sr.ID == requestId);
            return request;
        }

        public void AddServiceRequest(ServiceRequest newRequest)
        {
            DbContext.serviceRequests.Add(newRequest);
            DbContext.SaveChanges();
        }

        public void DeleteCategory(Guid requestId)
        {
            var request = DbContext.serviceRequests.FirstOrDefault(sr => sr.ID == requestId);
            if(request != null)
            {
                //remove the request mate
                DbContext.serviceRequests.Remove(request);
                DbContext.SaveChanges();
            }
        }

        public void UpdateCategory(ServiceRequest updatedRequest)
        {
            var existingRequest = DbContext.serviceRequests.FirstOrDefault(sr => sr.ID == updatedRequest.ID);
            if(existingRequest != null)
            {
                existingRequest.Description = updatedRequest.Description;
                existingRequest.CurrentStatus = updatedRequest.CurrentStatus;
                existingRequest.LastModifiedBy = updatedRequest.LastModifiedBy;
                existingRequest.LastModifiedDate = DateTime.Parse(DateTime.Now.ToString("O"));
            }
        }
    }
}
