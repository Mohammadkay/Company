using Domain.Models;
using Repository.Common;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        private ZzV10Context _context;
        public OrderRepository(ZzV10Context context ):base(context)
        {
            _context = context;
        }
      
    }
}
