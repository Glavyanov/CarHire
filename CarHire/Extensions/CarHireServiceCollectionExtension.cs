namespace Microsoft.Extensions.DependencyInjection
{
    using CarHire.Core.Contracts;
    using CarHire.Core.Services;
    using CarHire.Infrastructure.Data.Common;

    public static class CarHireServiceCollectionExtension
    {
        /// <summary>
        /// Custom Extension on IServiceCollection for CarHireSystem
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection services</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
