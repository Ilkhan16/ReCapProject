using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Results.Concrete;

namespace Core.Utilites.Results.Abstract
{
    public interface IResult
    {
        bool Success { get;}
        public string Messages { get;}
    }
}
