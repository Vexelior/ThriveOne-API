namespace Persistence.Entities.Debt;

public class Image
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Source { get; set; }
    public DateTime Uploaded { get; set; }
}
