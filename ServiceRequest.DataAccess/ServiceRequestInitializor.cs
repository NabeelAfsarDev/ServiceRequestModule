using System;
using System.Collections.Generic;
using ServiceRequest.DataAccess;

namespace ServiceRequest.DataAccess
{
    public class ServiceRequestInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ServiceRequestContext>
    {
        //seed the database with some data
        protected override void Seed(ServiceRequestContext context)
        {
            var serviceRequests = new List<ServiceRequest>
            {
               new ServiceRequest{ID = Guid.NewGuid(), BuildingCode = "C0H", Description = "Please turn up the AC in suite 1200D. It is too hot in here.", CurrentStatus = CurrentStatus.Created, CreatedBy="Nik Patel", CreatedDate=DateTime.Parse("2019-08-01T14:25:43.511Z"), LastModifiedBy="Jane Doe", LastModifiedDate=DateTime.Parse("2019-08-01T15:01:23.511Z")},
               new ServiceRequest{ID = Guid.NewGuid(), BuildingCode = "Z0C", Description = "Please turn up the Heat in suite 900B. It is getting cold in here.", CurrentStatus = CurrentStatus.Created, CreatedBy="Nabeel the Engineer", CreatedDate=DateTime.Parse("2019-07-02T14:25:43.511Z"), LastModifiedBy="Jane Joe", LastModifiedDate=DateTime.Parse("2019-07-02T15:01:23.511Z")}
            };

            serviceRequests.ForEach(sr => context.serviceRequests.Add(sr));
            context.SaveChanges();
        }
    }
}