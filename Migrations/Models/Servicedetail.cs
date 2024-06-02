using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class ServiceDetail
{
    public long Id { get; set; }

    public long? ServiceId { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public string? Details1 { get; set; }

    public string? Details2 { get; set; }

    public DateTime? ModificationDate { get; set; }

    public string? ModificationUser { get; set; }

    public virtual CpService? Service { get; set; }
}
