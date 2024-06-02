using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Order
{
    public long Id { get; set; }

    public long? ServiceId { get; set; }

    public long? UserId { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public DateTime? ModificationDate { get; set; }

    public string? ModificationUser { get; set; }

    public virtual CpService? Service { get; set; }

    public virtual User? User { get; set; }
}
