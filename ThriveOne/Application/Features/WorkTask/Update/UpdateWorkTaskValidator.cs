using FluentValidation;

namespace Application.Features.WorkTask.Update;

public class UpdateWorkTaskValidator : AbstractValidator<UpdateWorkTask>
{
    public UpdateWorkTaskValidator()
    {
        RuleFor(x => x.Title).NotEmpty()
            .WithMessage("Title is required.");

        RuleFor(x => x.Description).NotEmpty()
                                            .WithMessage("Description is required.");
    }
}
