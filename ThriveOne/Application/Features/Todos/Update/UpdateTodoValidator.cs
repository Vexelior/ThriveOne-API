using FluentValidation;

namespace Application.Features.Todos.Update;

public class UpdateTodoValidator : AbstractValidator<UpdateTodo>
{
    public UpdateTodoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Todo ID is required.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.").MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}
