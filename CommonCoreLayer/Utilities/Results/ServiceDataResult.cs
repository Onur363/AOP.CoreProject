using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class ServiceDataResult<T> : ServiceResult,IServiceDataResult<T>
    {
        public ServiceDataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public ServiceDataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }

    }
}
