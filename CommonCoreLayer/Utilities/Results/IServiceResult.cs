using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public interface IServiceResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
