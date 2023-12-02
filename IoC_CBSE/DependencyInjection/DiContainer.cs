using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC_CBSE.DependencyInjection
{
    public class DiContainer
    {
        private readonly Dictionary<Type, ServiceDescriptor> _serviceDescriptorDictionary;

        public DiContainer(Dictionary<Type, ServiceDescriptor> serviceDescriptorDictionary)
        {
            _serviceDescriptorDictionary = serviceDescriptorDictionary;
        }

        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptorDictionary.GetValueOrDefault(serviceType);

            if (descriptor == null)
            {
                throw new Exception($"Service of type {serviceType.Name} isn't registered");
            }

            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate abstract classes or interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.Lifetime == ServiceLifetime.Singleton)
            {
                descriptor.Implementation = implementation;
            }

            return implementation;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}