using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Entities;
using Todo.Core.Enums;
using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Repositories
{
    public class TodoRepository : Repository<TodoItem> , ITodoRepository
    {

        public TodoRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<TodoItem>> GetByStatusAsync(TodoStatus status)
        {
            return await _context.Todos.Where(t => t.Status == status).ToListAsync();
        }
    }
}
