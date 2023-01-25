using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMyService
    {
        string GetConstructorParameter();
    }

    public class MyService : IMyService
    {
        private string connectionString;
        public MyService(string connString)
        {
            this.connectionString = connString;
        }

        public string GetConstructorParameter()
        {
            return connectionString;
        }
    }
    public class NetCoreDIDemo
    {
        // https://cmatskas.com/net-core-dependency-injection-with-constructor-parameters-2/
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IMyService>(s => new MyService("MyConnectionString"));
            var provider = services.BuildServiceProvider();
            var myService = provider.GetService<IMyService>();

            Console.WriteLine($"The constructor parameter is: {myService.GetConstructorParameter()}");
        }
    }
}
