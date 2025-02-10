using MiniECommerce.Shared;
using Microsoft.JSInterop;

namespace MiniECommerce.Services
{
    public class WishlistService
    {
        private readonly IJSRuntime jsRuntime;
        private List<Product> wishlist = new();

        public WishlistService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public IReadOnlyList<Product> Wishlist => wishlist; // Synchron verfügbar

        public async Task LoadWishlist()
        {
            var savedWishlist = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "wishlist");
            if (!string.IsNullOrEmpty(savedWishlist))
            {
                wishlist = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(savedWishlist) ?? new();
            }
        }

        public async Task AddToWishlist(Product product)
        {
            if (!wishlist.Any(p => p.Id == product.Id))
            {
                wishlist.Add(product);
                await SaveWishlist();
            }
        }

        public async Task RemoveFromWishlist(Product product)
        {
            wishlist.RemoveAll(p => p.Id == product.Id);
            await SaveWishlist();
        }

        private async Task SaveWishlist()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(wishlist);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "wishlist", json);
        }
    }
}
