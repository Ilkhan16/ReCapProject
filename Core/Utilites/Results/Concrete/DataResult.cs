using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilites.Results.Abstract;

namespace Core.Utilites.Results.Concrete
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data ,bool success, string messages) : base(success, messages)
        {
            Data = data;
        }

        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
