using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // this=> bu class'ı hitap eder.
        // this ile=> tek parametreli constructor'a çalışssın bu demek istiyoruz
        public Result(bool success, string message):this(success)
        {
            Message = message;
            //IsSuccess = success;
        }
        //method overloading => constructor iki şekilde set edilebilir
        public Result(bool success)
        {
            IsSuccess = success; // Bu constructor mecburi bu constructor'ı kullanırsa fakat yukarıdaki constructor set edilirse zaten bunu da çalıştırmış olucak bu yüzden yukarıdaki IsSuccess'i commentledim.
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
