
using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.Repositories;
using API_Project.DataAccess.UoW;
using API_Project.DataAccessContracts;
using application.DataAccess;
using Application.DataAccessContracts;
using Application.ServiceContracts;
using Application.Services;


namespace Project_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.





            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);




            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IInquiryRepository, InquiryRepository>();
            builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>();

            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IInquiryService, InquiryService>();
            builder.Services.AddScoped<IFavoriteService, FavoriteService>();

            builder.Services.AddScoped<IPropertyService_Dto, PropertyService_Dto>();
            builder.Services.AddScoped<IUserService_Dto, UserService_Dto>();
            builder.Services.AddScoped<IInquiryService_Dto, InquiryService_Dto>();
            builder.Services.AddScoped<IFavoriteService_Dto, FavoriteService_Dto>();

            builder.Services.AddDbContext<AppDbContext>();




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
