using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ServiceDetail : BaseModel
{

    public long? ServiceId { get; set; }

    public string? Details1 { get; set; }

    public string? Details2 { get; set; }

    public virtual CpService? Service { get; set; }
}
