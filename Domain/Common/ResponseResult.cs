using Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ResponseResult : IResponseResult
    {
        public ResultStatus status { get ; set ; }
        public string Error { get ; set ; }
        public object Data { get ; set ; }
    }
}
