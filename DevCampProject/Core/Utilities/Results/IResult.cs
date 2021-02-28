using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // basic void operations for beginning
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
