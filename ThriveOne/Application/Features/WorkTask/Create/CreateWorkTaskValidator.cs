using FluentValidation;

namespace Application.Features.WorkTask.Create;

public class CreateWorkTaskValidator : AbstractValidator<CreateWorkTask>
{
    public CreateWorkTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
                                         .WithMessage("Title is required.");

        RuleFor(x => x.Description).NotEmpty()
                                               .WithMessage("Description is required.");

        RuleFor(x => x.Priority).NotEmpty()
                                            .WithMessage("Priority is required.");

        RuleFor(x => x.Status).NotEmpty()
                                          .WithMessage("Status is required.");

        RuleFor(x => x.Markdown).NotEmpty()
                                            .WithMessage("Markdown is required.");

        RuleFor(x => x.HTML).NotEmpty()
                                        .WithMessage("HTML is required.");
    }
}
