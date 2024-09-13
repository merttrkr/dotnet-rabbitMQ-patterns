using Core.Persistence.Repositories;

namespace ProductService.Domain.Entities
{
    public class Product:Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        // Constructor to ensure required fields are set
        public Product(string name, string description, decimal price, int stock)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }

        // Optional method for updating stock (could be more domain-specific)
        public void UpdateStock(int quantity)
        {
            Stock = quantity;
        }
    }
}
