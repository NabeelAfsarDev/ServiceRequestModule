using ServiceRequest.DataAccess;
using ServiceRequest.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest.Management
{
    public class ServiceRequestManagement
    {
        private ServiceRequestRepository _repo = new ServiceRequestRepository();

        public List<ServiceRequestDTO> Search()
        {
            var result = _repo.SearchRequests();

            var toReturn = result.Select(r => new ServiceRequestDTO
            {
                ID = r.ID,
                BuildingCode = r.BuildingCode,
                Description = r.Description,
                CurrentStatus = (DataContracts.CurrentStatus?)r.CurrentStatus,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                LastModifiedBy = r.LastModifiedBy,
                LastModifiedDate = r.LastModifiedDate
            }).ToList();
            return toReturn;
        }

        public ServiceRequestDTO GetServiceRequest(Guid id)
        {
            var repoResult = _repo.GetServiceRequest(id);
            return new ServiceRequestDTO
            {
                ID = repoResult.ID,
                BuildingCode = repoResult.BuildingCode,
                Description = repoResult.Description,
                CurrentStatus = (DataContracts.CurrentStatus?)repoResult.CurrentStatus,
                CreatedBy = repoResult.CreatedBy,
                CreatedDate = repoResult.CreatedDate,
                LastModifiedBy = repoResult.LastModifiedBy,
                LastModifiedDate = repoResult.LastModifiedDate
            };
        }

        public void DeleteServiceRequest(Guid id)
        {
            _repo.DeleteServiceRequest(id);
        }

        public void AddOrUpdateServiceRequest(ServiceRequestDTO serviceRequest)
        {
            DateTime timestamp = DateTime.Parse(DateTime.Now.ToString("O"));
            var request = new ServiceRequest.DataAccess.ServiceRequest
            {
                ID = serviceRequest.ID != Guid.Empty ? serviceRequest.ID : Guid.NewGuid(),
                Description = serviceRequest.Description,
                BuildingCode = serviceRequest.BuildingCode,
                CurrentStatus = (DataAccess.CurrentStatus?)serviceRequest.CurrentStatus,
                LastModifiedBy = serviceRequest.LastModifiedBy,
                LastModifiedDate = timestamp
            };

            //hmm need to check if it is a new request or existing one and then proceed with updating/adding
            if(serviceRequest.ID != Guid.Empty) //exists => update
            {
                _repo.UpdateServiceRequest(request);
            }
            else
            {
                request.CreatedBy = serviceRequest.LastModifiedBy;
                request.CreatedDate = timestamp;
                _repo.AddServiceRequest(request);
            }
        }
    }
}
