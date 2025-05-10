using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core.Enums;

namespace Todo.Application.Dtos
{
    public class UpdateTodoDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public TodoStatus Status { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
