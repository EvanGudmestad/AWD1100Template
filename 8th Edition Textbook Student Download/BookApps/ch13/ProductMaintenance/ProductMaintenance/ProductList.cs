namespace ProductMaintenance
{
    public class ProductList
	{
		private List<Product> products;

		public delegate void ChangeHandler(ProductList products);
		public event ChangeHandler Changed = null!;  

		public ProductList() => products = new();

        public int Count => products.Count;

		public Product this[int i]
		{
			get
			{
				if (i < 0 || i >= products.Count)
				{
					throw new ArgumentOutOfRangeException(i.ToString());
				}
				return products[i];
			}
			set
			{
				products[i] = value;
				if (Changed != null)
					Changed(this);
			}
		}

		public Product this[string code]
		{
			get
			{
                ArgumentNullException.ThrowIfNull(code);

                foreach (Product p in products)
				{
					if (p.Code == code)
						return p;
				}
				return null!;
			}
		}

		public void Fill() => products = ProductDB.GetProducts();

		public void Save() => ProductDB.SaveProducts(products);

		public void Add(Product product)
		{
			products.Add(product);
            if (Changed != null)
                Changed(this);
        }

		public void Add(string code, string description, decimal price)
		{
			Product p = new(code, description, price);
			products.Add(p);
            if (Changed != null)
                Changed(this);
        }

		public void Remove(Product product)
		{
			products.Remove(product);
            if (Changed != null)
                Changed(this);
        }

        public static ProductList operator + (ProductList list, Product p)
        {
            list.Add(p);
            return list;
        }

        public static ProductList operator - (ProductList list, Product p)
		{
			list.Remove(p);
			return list;
		}

	}
}
