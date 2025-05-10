using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Dtos;
using Todo.Core.Entities;

namespace Todo.Application.Mapping
{
    internal class TodoMapping
    {
        public static void Configure()
        {
            //TypeAdapterConfig<TodoItem, TodoDto>
            //    .NewConfig()
            //    .Map(dest => dest.DaysRemaining, src =>
            //        src.DueDate.HasValue ? (src.DueDate.Value - DateTime.Now).Days : null);

            TypeAdapterConfig<CreateTodoDto, TodoItem>
                .NewConfig()
                .Map(dest => dest.CreatedDate, _ => DateTime.UtcNow)
                .Map(dest => dest.LastModifiedDate, _ => DateTime.UtcNow);
        }
    }
}
