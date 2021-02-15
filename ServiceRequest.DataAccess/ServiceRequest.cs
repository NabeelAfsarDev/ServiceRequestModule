using System;

namespace ServiceRequest.DataAccess
{
    public enum CurrentStatus
    {
        NotApplicable,
        Created,
        InProgress,
        Complete,
        Canceled
    }
    public class ServiceRequest
    {
        public Guid ID { get; set; }
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public CurrentStatus? CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
