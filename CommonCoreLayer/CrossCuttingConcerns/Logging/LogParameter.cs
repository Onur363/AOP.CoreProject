using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string Name { get; set; } //Loglanacak Entity adı
        public object Value { get; set; } //Entity veya dto nun verisi
        public string Type { get; set; } //tip bilgisi
    }
}
