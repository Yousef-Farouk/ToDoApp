using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Enums;

namespace Todo.Core.Interfaces
{
    public interface ITodoRepository : IRepository<TodoItem>
    {
        Task <IEnumerable<TodoItem>> GetByStatusAsync(TodoStatus status);

    }
}
