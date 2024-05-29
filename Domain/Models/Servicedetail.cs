using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Servicedetail:BaseModel
{

    public string? Details1 { get; set; }

    public string? Details2 { get; set; }

    public long? ServiceId { get; set; }

  

    public virtual Service? Service { get; set; }
}
