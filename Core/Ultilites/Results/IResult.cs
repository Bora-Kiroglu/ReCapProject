using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilites.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
