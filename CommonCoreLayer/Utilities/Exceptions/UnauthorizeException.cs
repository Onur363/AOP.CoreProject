using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Exceptions
{
    public class UnauthorizeException:Exception
    {
        private string message;
        public UnauthorizeException(string message)
        {
            this.message = message;
        }
        public override string Message => message;
    }
}
