using System;

namespace IoC_CBSE
{
    public class CService : ICService
    {
        public CService(IInnerCService innerCService)
        {
            _innerCService = innerCService;
        }

        private readonly IInnerCService _innerCService;
        public void PrintFromCService()
        {
            Console.WriteLine("Hello from C Service");
            _innerCService.PrintFromInnerCService();
        }
    }
}
