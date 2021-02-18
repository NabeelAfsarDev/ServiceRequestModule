using ServiceRequest.DataAccess;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ServiceRequest.DataAccess
{
    public class ServiceRequestContext : DbContext
    {
        public ServiceRequestContext() : base("ServiceRequestContext")
        {
        }

        public DbSet<ServiceRequest> serviceRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}