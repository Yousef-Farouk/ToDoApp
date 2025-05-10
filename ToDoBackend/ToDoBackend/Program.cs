
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Todo.Application;
using Todo.Application.Validators;
using Todo.Infrastructure;
using Todo.WebApi.Exceptions;
using Todo.WebApi.TodoEndpoints;

namespace ToDoBackend
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            //builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

            builder.Services.AddProblemDetails();

            builder.Services.AddApplication();

           builder.Services.AddInfraStructure(builder.Configuration);


            builder.Services.AddValidatorsFromAssemblyContaining<CreateTodoDtoValidator>();

            builder.Services.AddValidatorsFromAssemblyContaining<UpdateTodoDtoValidator>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy => policy
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin());
            });
            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication();

            var app = builder.Build();


           


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAngular"); 
            app.UseAuthentication(); 
            app.UseAuthorization();
            app.UseStaticFiles(); 

            app.MapTodoEndpoints();

        
            await app.RunAsync();
        }
    }
}
