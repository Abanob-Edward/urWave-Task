
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Product_Management_System.Application.Contract;
using Product_Management_System.Application.Services;
using Product_Management_System.Context;
using Product_Management_System.Infrastructure;
using Product_Management_System.Middleware;

namespace Product_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy", builder =>
            //        builder
            //            .WithOrigins("http://localhost:4200") // Allow requests from your Angular frontend
            //            .AllowAnyMethod() // Adjust to specific methods (GET, POST, PUT, DELETE) if needed
            //            .AllowAnyHeader()); // Adjust to specific headers (Content-Type, Authorization) if needed
            //});

            builder.Services.AddCors(op =>
            {

                op.AddPolicy("AllowLocalhost",
                       builder => builder.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod());
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<ApplicationDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("ProductSystemBD"));

            });

            var app = builder.Build();
            app.UseCors("AllowLocalhost");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            // exception handling
            var loggerFactory = new LoggerFactory();
            app.UseErrorHandlingMiddleware(loggerFactory.CreateLogger<ErrorHandlingMiddleware>());

            app.Run();
        }
    }
}
