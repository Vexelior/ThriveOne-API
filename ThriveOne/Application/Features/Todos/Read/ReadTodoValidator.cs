using Application.Features.Todos.Create;
using FluentValidation;

namespace Application.Features.Todos.Read;

public class ReadTodoValidator : AbstractValidator<CreateTodo>
{
    public ReadTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
    }
}
