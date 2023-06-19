using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services) where T: DbContext
        {
            services.AddScoped(serviceProvider =>
            {
                IConfiguration? configuration = services.BuildServiceProvider().GetService<IConfiguration>();

                if (configuration == null)
                    throw new ArgumentNullException(nameof(configuration));

                DbContextOptionsBuilder<T> optionsBuilder = new DbContextOptionsBuilder<T>().UseSqlServer(configuration["Database:ConnectionString"]);

                T dbContext = (T) Activator.CreateInstance(typeof(T), optionsBuilder.Options)!;
                return dbContext;
            });
            return services;
        }
    }
}