using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            this.loggingEvent = loggingEvent;
        }

        public object Message => loggingEvent.MessageObject;

        //public object Message
        //{
        //    get { return loggingEvent.MessageObject; }
        //}
    }
}
