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
    public class AttachmentIRepository : Repository<Attachment>, IAttachmentIRepository
    {
        public AttachmentIRepository(ZzV10Context context) : base(context)
        {
        }
    }
}
