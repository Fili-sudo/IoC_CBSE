using System;

namespace IoC_CBSE
{
    public class InnerCService : IInnerCService
    {
        public void PrintFromInnerCService()
        {
            Console.WriteLine("Hello from Inner C Service");
        }
    }
}
