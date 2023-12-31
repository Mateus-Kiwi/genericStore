namespace Core.Entitites.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity, int quantityStock)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
            QuantityStock = quantityStock;
        }

        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int QuantityStock { get; set; }
    }
}