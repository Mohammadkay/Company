using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Order:BaseModel
{

    public long? ServiceId { get; set; }

    public long? UserId { get; set; }

    public virtual CpService? Service { get; set; }

    public virtual User? User { get; set; }
}
