using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Todo.Application.Dtos;

namespace Todo.Application.Validators
{
    public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
    {
        public CreateTodoDtoValidator()
        {

            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);

            RuleFor(x => x.DueDate)
                .GreaterThan(DateTime.Now)
                .When(x => x.DueDate.HasValue)
                .WithMessage("Due date must be in the future");
        }
    }
}
