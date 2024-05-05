namespace DevIO.Business.Models;

/// <summary>
/// Classe base para as entidades.
/// </summary>
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
