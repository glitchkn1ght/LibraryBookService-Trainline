using LibraryBookService_Trainline.DAL.Repositories;
using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Interfaces.Service;
using LibraryBookService_Trainline.Models.Response;
using LibraryBookService_Trainline.Service;
using LibraryBookService_Trainline.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace LibraryBookService_Trainline.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((hostingContext, loggerConfig) =>
                 loggerConfig.ReadFrom.Configuration(hostingContext.Configuration));

            // Add services to the container.
            builder.Services.AddScoped<IBookRepository, InMemoryBookRepository>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddControllers().ConfigureApiBehaviorOptions(a =>
            {
                a.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new CustomBadRequest(context);

                    var response = new GeneralResponse();

                    response.ResponseStatus.Code = -101;
                    response.ResponseStatus.Message = problemDetails.Title;
                    response.ResponseStatus.ValidationErrorDetails = problemDetails.Errors;

                    return new BadRequestObjectResult(response)
                    {
                        ContentTypes = { "application / problem + json", "application / problem + xml" }
                    };
                };
            }); 

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}