using System;

namespace IoC_CBSE.DependencyInjection
{
    public class ServiceRegistration
    {
        public string Service { get; set; }
        public string Implementation { get; set; }

        public (Type, Type) GetTypes()
        {
            return (Type.GetType(Service), Type.GetType(Implementation));
        }

    }
}
