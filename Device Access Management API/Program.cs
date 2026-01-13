
using Device_Access_Management_API.ExecptionHandler;
using FluentValidation;
using Infrastructure.Persistence_Context;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Commands.Devices.Handler;
using Services.InterFaces;
using Services.Services;
using Services.ValidationBehavior;
using Services.Validations;
using System.Reflection;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

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
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
