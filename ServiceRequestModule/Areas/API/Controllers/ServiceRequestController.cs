using ServiceRequest.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceRequestModule.Areas.API.Controllers
{
    [RoutePrefix("api/servicerequest")]
    public class ServiceRequestController : ApiController
    {
        private ServiceRequest.Management.ServiceRequestManagement _management = new ServiceRequest.Management.ServiceRequestManagement();

        [HttpGet]
        [Route("")]
        public List<ServiceRequestDTO> Search()
        {
            return _management.Search();
        }

        [HttpGet]
        [Route("{id}")]
        public ServiceRequestDTO GetServiceRequest(Guid id)
        {
            return _management.GetServiceRequest(id);
        }

        [HttpPost]
        [Route("")]
        public void SaveServiceRequest([FromBody]ServiceRequestDTO request)
        {
            _management.AddOrUpdateServiceRequest(request);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateServiceRequest([FromBody]ServiceRequestDTO request, Guid id)
        {
            request.ID = id;
            _management.AddOrUpdateServiceRequest(request);
        }

        [HttpDelete]
        [Route("servicereqeuest/{id}")]
        public void Delete(Guid id)
        {
            _management.DeleteServiceRequest(id);
        }
    }
}
