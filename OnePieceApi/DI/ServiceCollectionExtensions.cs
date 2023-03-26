using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OnePieceApi.Entities;
using OnePieceApi.Models.Dtos;
using OnePieceApi.Models.Validators;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace OnePieceApi.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        return services;
    }
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();
        services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();
        return services;
    }
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        return services;
    }
}