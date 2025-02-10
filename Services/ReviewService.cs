using MiniECommerce.Shared;
using Microsoft.JSInterop;  // Für LocalStorage

namespace MiniECommerce.Services
{
    public class ReviewService
    {
        private readonly IJSRuntime jsRuntime;
        private List<Review> reviews = new();

        public ReviewService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<List<Review>> GetReviews()
        {
            var savedReviews = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "reviews");
            if (!string.IsNullOrEmpty(savedReviews))
            {
                reviews = System.Text.Json.JsonSerializer.Deserialize<List<Review>>(savedReviews) ?? new();
            }
            return reviews;
        }

        public async Task AddReview(Review review)
        {
            reviews.Add(review);
            await SaveReviews();
        }

        private async Task SaveReviews()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(reviews);
            await jsRuntime.InvokeVoidAsync("localStorage.setItem", "reviews", json);
        }
    }
}
