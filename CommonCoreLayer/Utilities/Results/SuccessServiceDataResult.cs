using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class SuccessServiceDataResult<T> : ServiceDataResult<T>
    {
        public SuccessServiceDataResult(T data ) : base(data, true)
        {
        }

        public SuccessServiceDataResult(T data, string message) : base(data, true, message)
        {
        }

        public SuccessServiceDataResult(string message) : base(default, true, message)
        {
        }
    }
}
