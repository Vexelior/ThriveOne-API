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

        RuleFor(x => x.Description).NotEmpty()
                                            .WithMessage("Description is required.")
                                            .MaximumLength(500)
                                            .WithMessage("Description must not exceed 500 characters.");


        RuleFor(x => x.IsCompleted).NotEmpty()
                                            .WithMessage("IsCompleted is required.")
                                            .Must(x => x || !x)
                                            .WithMessage("IsCompleted must be true or false.");
    }
}
