using IoC_CBSE.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace IoC_CBSE
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var projectDirectory = Directory.GetParent(
                Environment.CurrentDirectory).Parent.Parent.FullName;
            var fileName = Path.Combine(projectDirectory, "config.json");

            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<ServiceRegistration> serviceRegistrations = JsonSerializer
                .Deserialize<List<ServiceRegistration>>(jsonString, options)!;

            var serviceList = new List<(Type, Type)>();
            serviceRegistrations.ForEach(serviceRegistration => { serviceList.Add(serviceRegistration.GetTypes()); });

            var services = new DiServiceCollection();

            services.RegisterServices(serviceList);
            var container = services.GenerateContainer();

            var serviceFirst = container.GetService<ISomeService>();
            var serviceSecond = container.GetService<ISomeService>();
            var aService = container.GetService<IAService>();
            var movieFinderService = container.GetService<IMovieFinder>();


            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();
            aService.Print();
            var movie = movieFinderService.GetMovie("Star Wars");
            Console.WriteLine(movie);

        }
    }
}