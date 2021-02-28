using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data:data,success:true,message:message){}
        public SuccessDataResult(T data):base(data:data,success:true){}
        //default => olarak datayı bir şey döndürmek istemediğimizde geçtik
        public SuccessDataResult(string message) :base(default,true,message:message){}
        public SuccessDataResult() :base(default,true){}
    }
}
