namespace API.DTOs
{
    public class OrderDto
    {
        public string basketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShipToAddress { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}