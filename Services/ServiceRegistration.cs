using _Services.Contracts;
using _Services.Services;
using API_Project.DataAccess.UoW;
using Application.DataAccessContracts;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace _Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterService(this IServiceCollection Services)
        {
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IPropertyService, PropertyService>();
            Services.AddScoped<IAmenitiesService, AmenitiesService>();
            Services.AddScoped<IPropertyImageService, PropertyImageService>();
            Services.AddScoped<IFavoriteService, FavoriteService>();
            Services.AddScoped<IInquiryService, InquiryService>();
            Services.AddScoped<ICityService, CityService>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();



            return Services;
        }
    }
}
