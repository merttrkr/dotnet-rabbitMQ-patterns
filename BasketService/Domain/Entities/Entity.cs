using System;
using System.Linq;

namespace BasketService.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public Entity()
    {
        Id = Guid.NewGuid();           // Generate a new unique identifier
        CreatedDate = DateTime.UtcNow;    // Set the creation time to current UTC    
    }
}