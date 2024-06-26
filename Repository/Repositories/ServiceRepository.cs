﻿using Domain.Models;
using Repository.Common;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ServiceRepository : Repository<CpService>, IServiceRepository
    {
        private ZzV10Context _context;
        public ServiceRepository(ZzV10Context context) : base(context)
        {
            _context = context;
        }
    }
}
