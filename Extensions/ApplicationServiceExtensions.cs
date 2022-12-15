using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_course_management.Data;
using dotnet_course_management.Services.CourseService;
using dotnet_course_management.Services.StudentService;
using dotnet_course_management.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace dotnet_course_management.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
        {
        services.AddDbContext<DataContext>(options => {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });

        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddCors(options => options.AddPolicy(name: "CourseManagementOrigins",
            policy =>
            {
                policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
        }));

        services.AddSwaggerGen();
        services.AddSwaggerGen(c => {
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
            Description = "Standard Authorization header using the Bearer scheme, e.g. \"bearer {token} \"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
            });

            c.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        

        return services;
        }
    }
}