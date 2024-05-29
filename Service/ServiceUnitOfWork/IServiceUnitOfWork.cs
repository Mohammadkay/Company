using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceUnitOfWork
{
    public interface IServiceUnitOfWork:IDisposable
    {
        Lazy<IUserService> Users { get; set; }
        Lazy<IServices> Services { get; set; }
        Lazy<IServiceDetailsService> ServicesDetails { get; set; }
        Lazy<IOrdersService> Orders { get; set; }
    }
}
