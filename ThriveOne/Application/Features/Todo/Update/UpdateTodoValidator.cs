using FluentValidation;

namespace Application.Features.Todo.Update;

public class UpdateTodoValidator : AbstractValidator<UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.")
                                      .MaximumLength(100)
                                      .WithMessage("Title must not exceed 100 characters.");
    }
}
