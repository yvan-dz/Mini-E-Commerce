namespace MiniECommerce.Shared
{
    public class Review
    {
        public int ProductId { get; set; }  // Verknüpfung mit Produkt
        public string Username { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }  // 1-5 Sterne
    }
}
