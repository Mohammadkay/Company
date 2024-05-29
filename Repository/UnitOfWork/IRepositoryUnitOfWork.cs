using Domain.Models;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IRepositoryUnitOfWork:IDisposable
    {
        Lazy<IUserRepository> Users { get; set; }
        Lazy<IOrderRepository> Orders { get; set; }
        Lazy<IServiceRepository> Services { get; set; }
        Lazy<IServiceDetailRepository> ServiceDetails { get; set; }
        Lazy<IAttachmentIRepository> Attachments { get; set; }
    }
}
