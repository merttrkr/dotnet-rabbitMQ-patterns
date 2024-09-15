namespace BasketService.Domain.Entities
{
    public class Basket:Entity
    {
        public Guid UserId { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
        }

    }
}
