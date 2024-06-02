using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Attachment
{
    public long Id { get; set; }

    public byte[]? AttachmentData { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public DateTime? ModificationDate { get; set; }

    public string? ModificationUser { get; set; }

    public long? ObjectType { get; set; }

    public long? ObjectId { get; set; }
}
