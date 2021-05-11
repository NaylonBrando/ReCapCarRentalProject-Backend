using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Results
{
    //Voidler için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
