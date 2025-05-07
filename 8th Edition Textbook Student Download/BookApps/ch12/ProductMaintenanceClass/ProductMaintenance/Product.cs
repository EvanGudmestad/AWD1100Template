namespace ProductMaintenance
{
    public class Product
    {
        public Product() { }

        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }

        public string GetDisplayText(string sep) =>
            $"{Code}{sep}{Price.ToString("c")}{sep}{Description}";
    }
}