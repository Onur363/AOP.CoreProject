﻿using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net
{
    public class JsonLayout : LayoutSkeleton
    {

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);

            writer.WriteLine(json);
        }

        public override void ActivateOptions()
        {
            
        }

        
    }
}
