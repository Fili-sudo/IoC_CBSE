using System;

namespace IoC_CBSE
{
    public class BService : IBService
    {
        public void PrintFromBService()
        {
            Console.WriteLine("Hello from B Service");
        }
    }
}
