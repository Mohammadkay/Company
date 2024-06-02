using Domain.Models;
using Migrations.Models;
using Repository.Common;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ServiceDetailRepository : Repository<ServiceDetail>, IServiceDetailRepository
    {
        private ZzV10Context _context;
        public ServiceDetailRepository(ZzV10Context context) : base(context)
        {
            _context = context;
        }
    }
}
