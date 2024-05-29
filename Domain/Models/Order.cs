using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Order:BaseModel
{


    public long? UserId { get; set; }

    public long? ServiceId { get; set; }

    public string? Description { get; set; }


    public virtual Service? Service { get; set; }

    public virtual User? User { get; set; }
}
