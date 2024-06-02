using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Attachment :BaseModel
{


    public string? AttachmentPath { get; set; }

    public long? ObjectType { get; set; }

    public long? ObjectId { get; set; }
}
