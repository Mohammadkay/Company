using Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IResponseResult<Model>
    {
        ResultStatus status { get; set; }
        string Error { get; set; }
        Model Data { get; set; }
        long TotalRecord {  get; set; }

    }
}
