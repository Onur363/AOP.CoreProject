using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class ErrorServiceDataResult<T> : ServiceDataResult<T>
    {
        public ErrorServiceDataResult(T data) : base(data, false)
        {
        }

        public ErrorServiceDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorServiceDataResult(string message):base(default,false,message)
        {

        }
    }
}
