using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Results.Abstract;

namespace Core.Utilites.Results.Concrete
{
    public class SuccessResult:Result
    {
        public SuccessResult(string messages) : base(true, messages)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
