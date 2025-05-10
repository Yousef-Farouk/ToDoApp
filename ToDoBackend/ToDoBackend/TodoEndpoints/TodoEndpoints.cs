using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Dtos;
using Todo.Application.Services.Interfaces;
using Todo.Core.Enums;

namespace Todo.WebApi.TodoEndpoints
{
    public static class TodoEndpoints
    {
        public static RouteGroupBuilder MapTodoEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/todos");

            group.MapGet("/", GetAllTodos)
                .WithName("GetAllTodos")
                .WithOpenApi()
                .Produces<List<TodoDto>>(200);

            group.MapGet("/{id}", GetTodoById)
                .WithName("GetTodoById")
                .WithOpenApi()
                .Produces<TodoDto>(200)
                .Produces(404);

            group.MapPost("/add", CreateTodo)
                .WithName("CreateTodo")
                .WithOpenApi()
                .Produces<TodoDto>(200)
                .ProducesValidationProblem();

            group.MapPut("/{id}", UpdateTodo)
                .WithName("UpdateTodo")
                .WithOpenApi()
                .Produces(204)
                .ProducesValidationProblem()
                .Produces(404);

            group.MapDelete("/{id}", DeleteTodo)
                .WithName("DeleteTodo")
                .WithOpenApi()
                .Produces(204)
                .Produces(404);

            return group;
        }

        private static async Task<IResult> GetAllTodos(
            [FromQuery] TodoStatus? status,
            ITodoService service)
        {
            var todos = await service.GetAllTodosAsync();
            return Results.Ok(todos);
        }

        private static async Task<IResult> GetTodoById(
            Guid id,
            ITodoService service)
        {
            var todo = await service.GetTodoByIdAsync(id);
            return todo is not null ? Results.Ok(todo) : Results.NotFound();
        }

        private static async Task<IResult> CreateTodo(
            [FromBody]CreateTodoDto dto,
            ITodoService service,
            IValidator<CreateTodoDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var createdTodo = await service.CreateTodoAsync(dto);
            return Results.CreatedAtRoute("GetTodoById", new { id = createdTodo.Id }, createdTodo);
        }

        private static async Task<IResult> UpdateTodo(
            Guid id,
            UpdateTodoDto dto,
            ITodoService service,
            IValidator<UpdateTodoDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            await service.UpdateTodoAsync(id, dto);
            return Results.NoContent();
            
        }

        private static async Task<IResult> DeleteTodo(
            Guid id,
            ITodoService service)
        {

            await service.DeleteTodoAsync(id);
            return Results.NoContent();
        }
    }
}
