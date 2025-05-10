using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Dtos;
using Todo.Application.Services.Interfaces;
using Todo.Core.Entities;
using Todo.Core.Enums;
using Todo.Core.Interfaces;

namespace Todo.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoDto>> GetAllTodosAsync()
        {
            var todos = await _repository.GetAllAsync();
            return todos.Adapt<List<TodoDto>>();
        }

        public async Task<IEnumerable<TodoDto>> GetByStatusAsync(TodoStatus status)
        {
            var todos = await _repository.GetByStatusAsync(status);
            return todos.Adapt<List<TodoDto>>();
        }

        public async Task<TodoDto> CreateTodoAsync(CreateTodoDto createDto)
        {
            var todo = createDto.Adapt<TodoItem>();
            todo.Id = Guid.NewGuid();
            var createdTodo = await _repository.AddAsync(todo);
            await _repository.SaveChangesAsync();
            return createdTodo.Adapt<TodoDto>();
        }

        public async Task UpdateTodoAsync(Guid id, UpdateTodoDto updateDto)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {id} not found");
            }
            updateDto.Adapt(todo);
            await _repository.UpdateAsync(todo);
            await _repository.SaveChangesAsync();

        }

        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(todo);
            await _repository.SaveChangesAsync();

        }

        public async Task<TodoDto> GetTodoByIdAsync(Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException($"Todo with ID {id} not found");
            }
            return todo.Adapt<TodoDto>();
        }
    }
}
