using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Order
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? ServiceId { get; set; }

    public string? Description { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
