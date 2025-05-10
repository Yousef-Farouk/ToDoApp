using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Todo.Application.Mapping;
using Todo.Application.Services.Interfaces;
using Todo.Application.Services;
using Todo.Application.Validators;
using FluentValidation;
using Todo.Application.Dtos;

namespace Todo.Application;

public static class ServiceConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        TodoMapping.Configure();

        services.AddScoped<ITodoService, TodoService>();

        services.AddValidatorsFromAssemblyContaining<CreateTodoDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTodoDtoValidator>();


        return services;
    }
}
