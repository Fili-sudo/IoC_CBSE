using System;
using System.Collections.Generic;

namespace IoC_CBSE.DependencyInjection
{
    public static class DiServiceCollectionExtension
    {
        public static void RegisterServices(this DiServiceCollection diServiceCollection, List<(Type, Type)> services)
        {
            services.ForEach(service => { diServiceCollection.RegisterTransient(service.Item1, service.Item2); });
        }
    }
}
