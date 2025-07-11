using FluentValidation;

namespace Application.Features.Todo.Create;

public class CreateTodoValidator : AbstractValidator<CreateTodo>
{
    public CreateTodoValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.");

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
