using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User:BaseModel
{


    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
