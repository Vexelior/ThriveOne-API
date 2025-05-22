using FluentValidation;

namespace Application.Features.Todo.Create;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
    }
}
