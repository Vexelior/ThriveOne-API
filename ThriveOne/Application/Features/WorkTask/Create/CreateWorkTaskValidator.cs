using FluentValidation;

namespace Application.Features.WorkTask.Create;

public class CreateWorkTaskValidator : AbstractValidator<CreateWorkTask>
{
    public CreateWorkTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.")
                                      .MaximumLength(100)
                                      .WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description).NotEmpty()
                                            .WithMessage("Description is required.")
                                            .MaximumLength(500)
                                            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Priority).NotEmpty()
                                        .WithMessage("Priority is required.")
                                        .WithMessage("Priority must be one of the following: Low, Medium, High.");

        RuleFor(x => x.Status).NotEmpty()
                                        .WithMessage("Status is required.")
                                        .WithMessage("Status must be one of the following: Not Started, In Progress, Completed.");

        RuleFor(x => x.Markdown).NotEmpty()
                                            .WithMessage("Markdown is required.");

        RuleFor(x => x.HTML).NotEmpty()
                                        .WithMessage("HTML is required.");
    }
}
