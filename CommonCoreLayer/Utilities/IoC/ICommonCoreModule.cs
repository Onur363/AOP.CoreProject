using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLayer.Utilities.IoC
{
    public interface ICommonCoreModule
    {
        void Load(IServiceCollection services);
    }
}
