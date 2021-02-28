using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        // başarılı olacağı için zaten mesaj gönderirsek Result'ın constructor'ını çalıştırıp get message dolucak ısSuccess=> in default true oluyor burada
        public SuccessResult(string message):base(success:true,message:message){}
        public SuccessResult() : base(true) { }
    }
}
