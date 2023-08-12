using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public interface IServiceDataResult<T>:IServiceResult
    {
        T Data { get; }
    }
}
