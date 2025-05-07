namespace ProductMaintenance
{
    public class Book : Product
    {
        public Book() { }

        public Book(string code, string description, decimal price,
            string author) : base(code, description, price) => Author = author;

        public string Author { get; set; } = "";

        public override string GetDisplayText(string sep) =>
            $"{base.GetDisplayText(sep)} ({Author})";
    }
}
