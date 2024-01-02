namespace Core.Entitites
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public decimal Price { get; set; }  
        public int Quantity  { get; set; }
        public int QuantityStock { get; set; }
        public string PictureUrl { get; set; }  
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}