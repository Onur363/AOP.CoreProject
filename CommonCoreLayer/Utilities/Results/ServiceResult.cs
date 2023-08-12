using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class ServiceResult : IServiceResult
    {
        public ServiceResult(bool success,string message):this(success)
        {
            Message = message;
        }

        public ServiceResult(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
