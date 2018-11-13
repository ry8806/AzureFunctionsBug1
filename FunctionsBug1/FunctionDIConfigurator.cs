using EfLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FunctionsBug1
{
    public class FunctionDiConfigurator
    {
        private static ServiceProvider _provider;
        static FunctionDiConfigurator()
        {
            Initialize();
        }

        public static void Initialize()
        {
            var services = new ServiceCollection();

            string dbConnection = Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection");
            services.AddDbContext<ApplicationDbContext>((opts) => 
            {
                opts.UseSqlServer(dbConnection);
            });

            _provider = services.BuildServiceProvider();
        }

        public static T GetService<T>() => _provider.GetService<T>();
    }
}
