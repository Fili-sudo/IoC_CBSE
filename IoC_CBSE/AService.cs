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

        public IBService _bService { get; set; }
        public ICService _cService { get; set; }
        public void Print()
        {
            Console.WriteLine("Hello from A Service");
            _bService.PrintFromBService();
            _cService.PrintFromCService();
        }
    }
}
