﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}