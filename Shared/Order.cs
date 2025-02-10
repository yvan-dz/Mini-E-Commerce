namespace MiniECommerce.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; } = new();
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
