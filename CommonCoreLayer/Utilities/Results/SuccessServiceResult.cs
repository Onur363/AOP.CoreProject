using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Results
{
    public class SuccessServiceResult : ServiceResult
    {
        public SuccessServiceResult() : base(true)
        {
        }

        public SuccessServiceResult(string message) : base(true, message)
        {
        }
    }
}
