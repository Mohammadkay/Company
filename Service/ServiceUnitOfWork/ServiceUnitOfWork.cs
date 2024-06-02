using Domain.Models;
using Migrations.Models;
using Repository.UnitOfWork;
using Service.Interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceUnitOfWork
{
    public class ServiceUnitOfWork:IServiceUnitOfWork
    {
        private IRepositoryUnitOfWork _repositoryUnitOfWork;
        public Lazy<IUserService> Users { get; set; }
        public Lazy<IServices> Services { get; set; }
        public Lazy<IServiceDetailsService> ServicesDetails { get; set; }
        public Lazy<IOrdersService> Orders { get; set; }

        public ServiceUnitOfWork(ZzV10Context context)
        {
            _repositoryUnitOfWork =new  RepositoryUnitOfWork(context);

            Users=new Lazy<IUserService>(()=>new UserService(_repositoryUnitOfWork));
            Services = new Lazy<IServices>(() => new Service.Services.Service(_repositoryUnitOfWork));
            ServicesDetails=new Lazy<IServiceDetailsService>(()=> new ServiceDetailsService(_repositoryUnitOfWork));
            Orders=new Lazy<IOrdersService>(()=>new OrdersService(_repositoryUnitOfWork)); 
        }

        public void Dispose()
        {
    
        }
    }
}
