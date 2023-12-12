using System;

namespace IoC_CBSE
{
    public class AService : IAService
    {
        public AService(IBService bService, ICService cService)
        {
            _bService = bService;
            _cService = cService;
        }

        private readonly IBService _bService;
        private readonly ICService _cService;
        public void Print()
        {
            Console.WriteLine("Hello from A Service");
            _bService.PrintFromBService();
            _cService.PrintFromCService();
        }
    }
}
