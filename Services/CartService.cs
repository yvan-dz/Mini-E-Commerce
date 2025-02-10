using MiniECommerce.Shared;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniECommerce.Services
{
    public class CartService
    {
        private readonly IJSRuntime jsRuntime;

        public CartService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public List<Product> Cart { get; set; } = new();

        public event Action? OnCartChanged;

        public void AddToCart(Product product)
        {
            Cart.Add(product);
            NotifyCartChanged();
        }

        public void RemoveFromCart(Product product)
        {
            Cart.Remove(product);
            NotifyCartChanged();
        }

        public void ClearCart()
        {
            Cart.Clear();
            NotifyCartChanged();
        }

        private void NotifyCartChanged()
        {
            OnCartChanged?.Invoke();
        }

        // 🛒 Bestellung aus dem Warenkorb speichern
        public async Task SaveOrder()
        {
            try
            {
                var json = JsonSerializer.Serialize(Cart);
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", "orders", json);
                Console.WriteLine("✅ Bestellung im LocalStorage gespeichert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fehler beim Speichern der Bestellung: {ex.Message}");
            }
        }
    }
}
