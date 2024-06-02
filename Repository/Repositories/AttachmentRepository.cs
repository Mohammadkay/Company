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
    public class AttachmentRepository : Repository<Attachment>, IAttachmentIRepository
    {
        public AttachmentRepository(ZzV10Context context) : base(context)
        {
        }
    }
}
