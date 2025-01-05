using _02.DI.Core.Interfaces;
using DI.Demo;
using DI.Demo.Interfaces;
using DI.Demo.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class Program
    {
        public static void Main()
        {
            DemoCustomDI();
            //DemotBuiltInDI();
        }

        private static void DemoCustomDI()
        {
            IModule module = new DemoModule();
            module.Configure();

            GetAllEntities<Organization>(module);
            GetAllEntities<Group>(module);
            GetAllEntities<User>(module);
        }

        private static void GetAllEntities<T>(IModule module)
        {
            IService<T>? service = module.GetService<IService<T>>();
            ArgumentNullException.ThrowIfNull(service);

            _ = service.GetAll();
        }

        private static void DemotBuiltInDI()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IWriter, ConsoleWriter>();
            serviceCollection.AddScoped<IService<User>, DefaultService<User>>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            IService<User> userService = scope.ServiceProvider.GetRequiredService<IService<User>>();
            _ = userService.GetAll();
        }
    }
}
