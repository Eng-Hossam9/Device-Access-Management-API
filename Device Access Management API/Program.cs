
using Device_Access_Management_API.ExecptionHandler;
using FluentValidation;
using Infrastructure.Persistence_Context;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Commands.Devices.Handler;
using Services.InterFaces;
using Services.Services;
using Services.ValidationBehavior;
using Services.Validations;


namespace Device_Access_Management_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddMediatR(typeof(CreateDeviceHandler).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(CreateDeviceCommandValidator).Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddScoped(typeof(IRepositoryEntityBase<,>),typeof(RepositoryEntityBase<,>));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        int statusCode = contextFeature.Error switch
                        {
                            ArgumentNullException => 400,
                            KeyNotFoundException => 404,
                            _ => 500
                        };

                        var response = new ApiResponse<object>
                        (
                            data: null,
                            success: false,
                            message: contextFeature.Error.Message
                        );

                        context.Response.StatusCode = statusCode;
                        await context.Response.WriteAsJsonAsync(response);
                    }
                });
            });


            app.MapControllers();

            app.Run();
        }
    }
}
