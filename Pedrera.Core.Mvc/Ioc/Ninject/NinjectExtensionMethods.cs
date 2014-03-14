using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace Pedrera.Core.Mvc.Ioc.Ninject
{
    public static class NinjectExtensionMethods
    {
        public static T GetService<T>(this IServiceProvider kernel) where T : class
        {
            return kernel.GetService(typeof (T)) as T;
        }
    }
}
