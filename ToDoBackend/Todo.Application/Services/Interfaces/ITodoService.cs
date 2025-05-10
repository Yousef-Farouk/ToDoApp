using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Dtos;
using Todo.Core.Entities;
using Todo.Core.Enums;

namespace Todo.Application.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDto>> GetAllTodosAsync();
        Task<TodoDto> CreateTodoAsync(CreateTodoDto createDto);
        Task UpdateTodoAsync(Guid id, UpdateTodoDto updateDto);
        Task DeleteTodoAsync(Guid id);
        Task<IEnumerable<TodoDto>> GetByStatusAsync(TodoStatus status);

        Task<TodoDto> GetTodoByIdAsync(Guid id); 

    }
}
