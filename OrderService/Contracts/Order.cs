namespace OrderService.Contracts;

public class Order
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; private set; }

    public Order()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.Now;  // Automatically set when an Order is created
    }
}
