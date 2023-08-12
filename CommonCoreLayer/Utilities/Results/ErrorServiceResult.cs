using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class ErrorServiceResult : ServiceResult
    {
        public ErrorServiceResult() : base(false)
        {
        }

        public ErrorServiceResult(string message) : base(false, message)
        {
        }
    }
}
