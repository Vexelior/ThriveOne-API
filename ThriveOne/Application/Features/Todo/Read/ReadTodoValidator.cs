using Application.Features.Todo.Create;
using FluentValidation;

namespace Application.Features.Todo.Read;

public class ReadTodoValidator : AbstractValidator<CreateTodo>
{
    public ReadTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
    }
}
