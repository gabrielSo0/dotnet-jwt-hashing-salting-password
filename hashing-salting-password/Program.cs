
using AutoMapper;
using hashing_salting_password.Config;
using hashing_salting_password.Data;
using hashing_salting_password.Repository;
using hashing_salting_password.Repository.Interfaces;
using hashing_salting_password.Services;
using hashing_salting_password.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace hashing_salting_password;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        
        // database context configuration
        builder.Services.AddDbContext<InMemoryContext>(options => {
            options.UseInMemoryDatabase("MyDatabase");
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Dependency Injection
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        //Adding automapper to the services
        IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
