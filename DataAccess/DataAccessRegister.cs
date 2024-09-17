using _DataAccess.Contracts;
using _DataAccess.Repositories;
using API_Project.DataAccess.Repositories;
using API_Project.DataAccess.UoW;
using API_Project.DataAccessContracts;
using application.DataAccess;
using Application.DataAccessContracts;
using Microsoft.Extensions.DependencyInjection;


namespace _DataAccess
{
    public static class DataAccessRegister
    {
        public static IServiceCollection RegisterDataAccess(this IServiceCollection Services)
        {

            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IPropertyRepository, PropertyRepository>();
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<IInquiryRepository, InquiryRepository>();
            Services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            Services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            Services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();

            Services.AddDbContext<AppDbContext>();

            return Services;
        }
    }
}
