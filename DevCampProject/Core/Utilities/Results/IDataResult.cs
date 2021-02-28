using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // IResult zaten içeriyor Success ve Message o yüzden kendimizi tekrar etmeyelim. IResult dan implemente edelim ayrıca
    public interface IDataResult<T>: IResult
    {
        T Data { get; }
    }
}
