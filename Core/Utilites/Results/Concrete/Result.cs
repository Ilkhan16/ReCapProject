using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Results.Abstract;

namespace Core.Utilites.Results.Concrete
{
    public class Result:IResult
    {
        public Result(bool success, string messages):this(success)
        {
            Messages = messages;
        }
        public Result(bool success)
        {
            Success=success;
        }

        public bool Success { get; }
        public string Messages { get; }
    }
}
