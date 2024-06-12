namespace ProductPreview.Components.Pages.Products
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Guid Id { get; private set; }

        public Product(string title, string description, double price, int count = 1)
        {
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Count = count;
            this.Id = Guid.NewGuid();
            Count = count;
        }

    }
}
