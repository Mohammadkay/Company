using Domain.Common;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAttachmentService: IService<Attachment>
    {
        Task<IResponseResult<Attachment>> Upload(IFormFile file, long? objectType,long? objectId);
    }
}
