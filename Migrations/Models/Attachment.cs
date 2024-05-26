using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Attachment
{
    public long Id { get; set; }

    public byte[] AttachmentData { get; set; } = null!;

    public long ObjectType { get; set; }

    public long ObjectId { get; set; }

    public string? CreationUser { get; set; }

    public DateTime? CreationDate { get; set; }
}
