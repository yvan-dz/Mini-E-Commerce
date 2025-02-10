using MiniECommerce.Shared;

namespace MiniECommerce.Services
{
    public class ProductService
    {
        private List<Product> products = new()
{
    new Product { Id = 1, Name = "Laptop", Description = "Gaming Laptop", Price = 1299.99m, ImageUrl = "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_101244116?x=536&y=402&format=jpg&quality=80&sp=yes&strip=yes&trim&ex=536&ey=402&align=center&resizesource&unsharp=1.5x1+0.7+0.02&cox=0&coy=0&cdx=536&cdy=402" },
    new Product { Id = 2, Name = "Smartphone", Description = "iPhone 16 Pro Max", Price = 799.99m, ImageUrl = "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_144663410?x=536&y=402&format=jpg&quality=80&sp=yes&strip=yes&trim&ex=536&ey=402&align=center&resizesource&unsharp=1.5x1+0.7+0.02&cox=0&coy=0&cdx=536&cdy=402" },
    new Product { Id = 3, Name = "Kopfhörer", Description = "Noise Cancelling Kopfhörer mit Bluetooth", Price = 199.99m, ImageUrl = "https://cdn.teufelaudio.com/image/upload/c_lfill,f_auto,q_auto,w_800/v1/products/REAL_BLUE_NC_2021/real_blue_nc_2021-blue-set.jpg" },
    new Product { Id = 4, Name = "TV", Description = "65 Zoll 4K OLED Smart TV", Price = 1599.99m, ImageUrl = "https://asset.conrad.com/media10/isa/160267/c1/-/de/002255276PI00/image.jpg?x=1440&y=1440&format=jpg&ex=1440&ey=1440&align=center" },
    new Product { Id = 5, Name = "Smartwatch", Description = "Moderne Smartwatch mit Fitness-Tracking", Price = 299.99m, ImageUrl = "https://smartwatchesbrasil.com/wp-content/uploads/2022/11/hoylou-solar-plus-smartwatch-scaled.jpg" },
    new Product { Id = 6, Name = "PlayStation 5", Description = "Next-Gen Konsole mit 1TB SSD", Price = 499.99m, ImageUrl = "https://www.pcgameshardware.de/screenshots/1280x1024/2023/10/Playstation-5-Slim-und-Original-3-pcgh.jpg" },
    new Product { Id = 7, Name = "VR Brille", Description = "Virtual Reality Headset für ein immersives Erlebnis", Price = 399.99m, ImageUrl = "https://cdn.mos.cms.futurecdn.net/f4MurHWurjthg6mp79w8AV-1920-80.jpeg" },
    new Product { Id = 8, Name = "Nintendo Switch", Description = "Hybrid-Konsole für unterwegs und zuhause", Price = 349.99m, ImageUrl = "https://assets.nintendo.eu/image/upload/f_auto/q_auto/v1680678582/NAL/Articles/Nintendo%20Switch%20OLED%20TotK%20Edition%20Launches%20on%2012th%20May/TOTK_Lead.jpg" }

};


        public List<Product> GetProducts() => products;

        public void AddProduct(Product product)
        {
            product.Id = products.Count + 1; // Automatische ID-Vergabe
            products.Add(product);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Description = updatedProduct.Description;
                product.ImageUrl = updatedProduct.ImageUrl;
            }
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }
    }
}
