using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Çalışıcağın tipi çağırırken söyleyeceğim
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base => dediğimizde Result'a git orada this ile success veya message'a göre ilgili constructor çalışıyor
        public DataResult(T data,bool success,string message):base(success:success,message:message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success: success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
