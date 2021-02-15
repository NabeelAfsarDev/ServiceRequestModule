using ContosoUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceRequest.DataAccess
{
    public class BaseRepository
    {
        protected ServiceRequestContext DbContext = new ServiceRequestContext();
    }
}
