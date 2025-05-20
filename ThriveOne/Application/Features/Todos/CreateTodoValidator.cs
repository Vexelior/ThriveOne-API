using FluentValidation;

namespace Application.Features.Todos;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
    }
}
