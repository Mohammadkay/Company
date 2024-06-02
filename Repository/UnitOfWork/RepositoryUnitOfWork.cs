using Domain.Models;
using Migrations.Models;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class RepositoryUnitOfWork:IRepositoryUnitOfWork
    {
        private ZzV10Context _context;

        public Lazy<IUserRepository> Users { get; set; }
        public Lazy<IOrderRepository> Orders { get; set; }
        public Lazy<IServiceRepository> Services { get; set; }
        public Lazy<IServiceDetailRepository> ServiceDetails { get; set; }
        public Lazy<IAttachmentIRepository> Attachments { get; set; }

        public RepositoryUnitOfWork(ZzV10Context context)
        {
            _context = context;
            Users= new Lazy<IUserRepository>(()=>new UserRepository(_context));
            Orders = new Lazy<IOrderRepository>(() => new OrderRepository(_context));
            Services=new Lazy<IServiceRepository>(()=>new ServiceRepository(_context));
            ServiceDetails=new Lazy<IServiceDetailRepository>(()=>new ServiceDetailRepository(_context));
            Attachments=new Lazy<IAttachmentIRepository>(()=>new AttachmentRepository(_context));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
