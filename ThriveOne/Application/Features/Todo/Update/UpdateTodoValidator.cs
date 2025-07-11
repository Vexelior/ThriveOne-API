using FluentValidation;

namespace Application.Features.Todo.Update;

public class UpdateTodoValidator : AbstractValidator<UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.");
    }
}
