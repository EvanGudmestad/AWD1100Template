namespace ProductMaintenance
{
    public class Product
    {
        public Product() { }
        public Product(string code, string description, decimal price) =>
            (Code, Description, Price) = (code, description, price);

        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }

        public string GetDisplayText() => GetDisplayText(", ");

        public string GetDisplayText(string sep) => 
            $"{Code}{sep}{Price.ToString("c")}{sep}{Description}";
    }
}