using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuring Dependency Injection
            var services = new ServiceCollection();
            services.AddSingleton<IData,Data>();
            services.AddSingleton<INetwork, Network>();

            var serviceProvider = services.BuildServiceProvider();
            // Making Client Calls
            var bar = serviceProvider.GetService<IData>();

            // Read
            //Console.WriteLine(bar.ReadAsync("4E4458434948444647514D4D4B485944").Result);

            //// Create
            //RequestJSON createrequestJSON = new RequestJSON
            //{
            //    user = "XYZ, Inc"
            //};
            //Console.WriteLine(bar.CreateUpdateAsync(requestJSON).Result);

            //// Update
            //RequestJSON updaterequestJSON = new RequestJSON
            //{
            //    user = "XYZ, Inc"
            //};
            //Console.WriteLine(bar.CreateUpdateAsync(requestJSON).Result);

            Console.ReadKey();
        }




    }
}
