using JDPodrozeAPI.Core.Extensions;

namespace JDPodrozeAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.AddConfiguration(args);
            builder.ValidateConfiguration();
            builder.AddDatabaseContexts();
            builder.InitServices();
            builder.AddServicesToDI();
            builder.AddValidators();

            WebApplication application = builder.Build();
            application.AddMiddlewares();
            application.UseDeveloperExceptionPage();
            application.Run();
        }
    }
}