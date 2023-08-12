using CommonCoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.Business
{
    public class BusinessRules
    {
        public static IServiceResult Run(params IServiceResult[] serviceResults)
        {
            foreach (var result in serviceResults)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
