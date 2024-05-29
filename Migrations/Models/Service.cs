using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class Service
{
    public long Id { get; set; }

    public string? ServiceName1 { get; set; }

    public string? ServiceName2 { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public string? ModificationUser { get; set; }

    public DateTime? ModificationDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Servicedetail> Servicedetails { get; set; } = new List<Servicedetail>();
}
