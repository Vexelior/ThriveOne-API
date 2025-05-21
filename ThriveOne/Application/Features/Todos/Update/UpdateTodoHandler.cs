using Application.Features.Todos.Read;
using MediatR;
using Persistence;
using Persistence.Entities;

namespace Application.Features.Todos.Update;

public class UpdateTodoHandler(ApplicationDbContext context) : IRequestHandler<UpdateTodo, Todo>
{
    public async Task<Todo?> Handle(UpdateTodo request, CancellationToken cancellationToken)
    {
        var todo = await context.Todos.FindAsync([request.Id], cancellationToken);
        if (todo == null)
        {
            return null;
        }
        todo.Title = request.Title;
        todo.Description = request.Description;
        todo.Created = request.Created ?? todo.Created;
        todo.Completed = request.Completed ?? todo.Completed;
        todo.Due = request.Due ?? todo.Due;
        todo.IsCompleted = request.IsCompleted;
        await context.SaveChangesAsync(cancellationToken);
        return todo;
    }
}
