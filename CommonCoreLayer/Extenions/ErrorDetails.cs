using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Extenions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
