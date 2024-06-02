using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class User
{
    public long Id { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? CreationUser { get; set; }

    public string? Email { get; set; }

    public DateTime? ModificationDate { get; set; }

    public string? ModificationUser { get; set; }

    public string? PhoneNumber { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
