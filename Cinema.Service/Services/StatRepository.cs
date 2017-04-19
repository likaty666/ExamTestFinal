using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Services
{
   public  class StatRepository : GenericRepository<Stat>
    {
        public StatRepository(DbContext context) : base(context) { }
    }
}
