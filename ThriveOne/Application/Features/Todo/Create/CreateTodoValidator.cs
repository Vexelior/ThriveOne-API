using FluentValidation;

namespace Application.Features.Todo.Create;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.")
                                      .MaximumLength(100)
                                      .WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description).NotEmpty()
                                            .WithMessage("Description is required.")
                                            .MaximumLength(500)
                                            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Created).NotEmpty()
                                        .WithMessage("Created date is required.")
                                        .Must(BeAValidDate)
                                        .WithMessage("Created date must be a valid date.");
    }

    private static bool BeAValidDate(DateTime date)
    {
        return date != default;
    }
}
