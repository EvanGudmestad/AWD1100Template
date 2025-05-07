namespace ProductMaintenance
{
    public class ProductList : List<Product>
    {
        // Modify the behavior of the Add method of the List<Product> class
        public new void Add(Product p) => base.Insert(0, p);

        // Provide two additional methods
        public void Fill()
        {
            List<Product> products = ProductDB.GetProducts();
            foreach (Product product in products)
                base.Add(product);
        }

        public void Save() => ProductDB.SaveProducts(this);
    }
}
