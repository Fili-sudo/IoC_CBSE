using System;
using System.Collections.Generic;

namespace IoC_CBSE.DependencyInjection
{
    public class DiServiceCollection
    {
        private Dictionary<Type, ServiceDescriptor> _serviceDescriptorDictionary = new Dictionary<Type, ServiceDescriptor>();

        public void RegisterSingleton<TService>()
        {
            var serviceType = typeof(TService);
            _serviceDescriptorDictionary.Add(serviceType, new ServiceDescriptor(serviceType, ServiceLifetime.Singleton));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            var serviceType = typeof(TService);
            _serviceDescriptorDictionary.Add(serviceType,
                new ServiceDescriptor(
                    serviceType,
                    typeof(TImplementation),
                    ServiceLifetime.Singleton)
                );
        }

        public void RegisterSingleton<TService>(TService implementation)
        {
            var serviceType = typeof(TService);
            _serviceDescriptorDictionary.Add(serviceType, new ServiceDescriptor(implementation, ServiceLifetime.Singleton));
        }

        public void RegisterTransient<TService>()
        {
            var serviceType = typeof(TService);
            _serviceDescriptorDictionary.Add(serviceType, new ServiceDescriptor(serviceType, ServiceLifetime.Transient));
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            var serviceType = typeof(TService);
            _serviceDescriptorDictionary.Add(serviceType,
                new ServiceDescriptor(
                    serviceType,
                    typeof(TImplementation),
                    ServiceLifetime.Transient)
                );
        }
        public void RegisterTransient(Type tService, Type TImplementation)
        {
            _serviceDescriptorDictionary.Add(tService,
                new ServiceDescriptor(
                    tService,
                    TImplementation,
                    ServiceLifetime.Transient)
                );
        }

        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptorDictionary);
        }
    }
}