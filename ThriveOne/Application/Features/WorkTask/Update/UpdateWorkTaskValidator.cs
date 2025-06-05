using FluentValidation;

namespace Application.Features.WorkTask.Update;

public class UpdateWorkTaskValidator : AbstractValidator<UpdateWorkTask>
{
    public UpdateWorkTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                      .WithMessage("Title is required.")
                                      .MaximumLength(100)
                                      .WithMessage("Title must not exceed 100 characters.");

        RuleFor(x => x.Description).NotEmpty()
                                            .WithMessage("Description is required.")
                                            .MaximumLength(500)
                                            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.CompletedAt).LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Completed date cannot be in the future.");
        RuleFor(x => x.DueDate).GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Due date must be in the future or today.")
            .GreaterThanOrEqualTo(x => x.CompletedAt)
            .WithMessage("Due date must be after the completed date.");
        RuleFor(x => x.Priority).NotEmpty()
            .WithMessage("Priority is required.")
            .Must(p => p == "Low" || p == "Medium" || p == "High")
            .WithMessage("Priority must be Low, Medium, or High.");
        RuleFor(x => x.Status).NotEmpty()
            .WithMessage("Status is required.")
            .Must(s => s == "Pending" || s == "InProgress" || s == "Completed")
            .WithMessage("Status must be Pending, InProgress, or Completed.");
        RuleFor(x => x.Markdown).NotEmpty()
            .WithMessage("Markdown content is required.")
            .MaximumLength(5000)
            .WithMessage("Markdown content must not exceed 5000 characters.");
        RuleFor(x => x.HTML).NotEmpty()
            .WithMessage("HTML content is required.")
            .MaximumLength(5000)
            .WithMessage("HTML content must not exceed 5000 characters.");
    }
}
