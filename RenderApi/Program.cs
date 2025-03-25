using Microsoft.EntityFrameworkCore;
using RenderApi.Models;

namespace RenderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /*builder.Services.AddDbContext<AutotraderContext>(option =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MySql");
                option.UseMySQL(connectionString);
            });*/
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            builder.Services.AddDbContext<AutotraderContext>(options =>
                options.UseMySQL(connectionString));

            // Add services to the container.

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
