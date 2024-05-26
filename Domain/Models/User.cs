using System;
using System.Collections.Generic;

namespace Migrations.Models;

public partial class User
{
    public long Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
