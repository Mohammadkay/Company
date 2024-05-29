using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Servicedetail
{
    public long Id { get; set; }

    public string? Details1 { get; set; }

    public string? Details2 { get; set; }

    public long? ServiceId { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public string? ModificationUser { get; set; }

    public DateTime? ModificationDate { get; set; }

    public virtual Service? Service { get; set; }
}
