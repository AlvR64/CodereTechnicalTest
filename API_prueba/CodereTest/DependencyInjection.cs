using CodereTest.Domain.Repositories;
using CodereTest.Domain.Services;
using CodereTest.Infrastructure.Context;
using CodereTest.Infrastructure.Repositories;
using CodereTest.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodereTest.API
{
    public static class DependencyInjection
    {
        public static void AddInMemoryDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CodereTestContext>(options =>
            {
                options.UseInMemoryDatabase("CodereTestDB");
            });
        }

        public static void AddAppServices(this IServiceCollection services)
        {
            AddMediatR(services);
            AddRepositories(services);
        }

        private static void AddMediatR(this IServiceCollection services)
        {
            Assembly application = AppDomain.CurrentDomain.Load("CodereTest.Application");
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(application);
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<Domain.Services.IHttpClientFactory, HttpClientFactory>();
            services.AddScoped<IShowItemRepository, ShowItemRepository>();
            services.AddScoped<ITvMazeService, TvMazeService>();
        }
    }
}
