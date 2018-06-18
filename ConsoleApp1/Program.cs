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
            /*The first thing we do is configure the dependency injection container by creating a ServiceCollection, 
             * adding our dependencies, and finally building an IServiceProvider*/
            var services = new ServiceCollection();
            services.AddSingleton<IData,Data>();
            services.AddSingleton<INetwork, Network>();

            /*The serviceProvider is our container we can use to resolve services in our application. */
            var serviceProvider = services.BuildServiceProvider();
            
            
            // Making Client Calls
            var client = serviceProvider.GetService<IData>();


            // Create
            RequestJSON createrequestJSON = new RequestJSON
            {
                user = "PQR34534, Inc"
            };
            Console.WriteLine(client.CreateUpdateAsync(createrequestJSON).Result); // parameter id is an optional field for CreateUpdateAsync method 
            //and will be passed in only for during update'

            // Read
            Console.WriteLine(client.ReadAsync("4D4C4B484D4C4C564254574C50485949").Result);

            //Update
            RequestJSON updaterequestJSON = new RequestJSON
            {
                expire = "1427822745",
                user = "Cylance, Inc"
            };
            Console.WriteLine(client.CreateUpdateAsync(updaterequestJSON, "4C47514B4357535642485644544E5945").Result);


            // Delete
            client.DeleteAsync("4C47514B4357535642485644544E5945");

            Console.ReadKey();
        }




    }
}
