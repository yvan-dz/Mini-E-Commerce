using MiniECommerce.Shared;
using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniECommerce.Services
{
    public class OrderService
    {
        private readonly IJSRuntime jsRuntime;

        public OrderService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var savedOrders = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "orders");
                return !string.IsNullOrEmpty(savedOrders)
                    ? JsonSerializer.Deserialize<List<Order>>(savedOrders) ?? new()
                    : new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fehler beim Laden der Bestellungen: {ex.Message}");
                return new();
            }
        }

        public async Task AddOrder(Order order)
        {
            try
            {
                var orders = await GetOrders();

                if (string.IsNullOrWhiteSpace(order.CustomerName))
                {
                    order.CustomerName = "Unbekannter Kunde";
                }

                orders.Add(order);
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", "orders", JsonSerializer.Serialize(orders));

                Console.WriteLine($"✅ Bestellung #{order.Id} für {order.CustomerName} gespeichert.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fehler beim Speichern der Bestellung: {ex.Message}");
            }
        }

        public async Task ClearOrders()
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "orders");
                Console.WriteLine("🗑️ Alle Bestellungen wurden gelöscht.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Fehler beim Löschen der Bestellungen: {ex.Message}");
            }
        }
    }
}
