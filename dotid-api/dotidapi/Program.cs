
using dotidapi.Context;
using dotidapi.Interfaces;
using dotidapi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using dotidapi.DataAccess;

namespace dotidapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IFactRepository, FactRepository>();
            builder.Services.AddTransient<IRegionRepository, RegionRepository>();

            builder.Services.AddTransient<IAgeStructureDiffService, AgeStructureDiffService>();
            builder.Services.AddTransient<IAgeStructureService, AgeStructureService>();
            builder.Services.AddTransient<IAgeStructureDataAccess, AgeStructureDataAccess>();

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

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