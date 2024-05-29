using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Attachment:BaseModel
{


    public byte[] AttachmentData { get; set; } = null!;

    public long ObjectType { get; set; }

    public long ObjectId { get; set; }


}
