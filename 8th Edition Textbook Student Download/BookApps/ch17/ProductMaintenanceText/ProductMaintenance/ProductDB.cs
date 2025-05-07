namespace ProductMaintenance;

public static class ProductDB
{
	private const string Dir = @"C:\C#\files\";
	private const string Path = Dir + "Products.txt";
    private const string Sep = "|";

    public static List<Product> GetProducts()
	{
		// if the directory doesn't exist, create it
		if (!Directory.Exists(Dir))
			Directory.CreateDirectory(Dir);

        // create the object for the input stream for a text file
        // use a using declaration so the stream automatically closes when it goes out of scope
        using StreamReader textIn = new (
			new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read));

		// create the list
		List<Product> products = new();

		// read the data from the file and store it in the list
		while (textIn.Peek() != -1)
		{
			string row = textIn.ReadLine() ?? "";
			string[] columns = row.Split(Sep);

			if (columns.Length == 3)
			{
				Product product = new()
				{
					Code = columns[0],
					Description = columns[1],
					Price = Convert.ToDecimal(columns[2])
				};
				products.Add(product);
			}
		}

		return products;
	}

	public static void SaveProducts(List<Product> products)
	{
		// create the output stream for a text file that exists
		// use a using declaration so the stream automatically closes when it goes out of scope
		using StreamWriter textOut = new(
			new FileStream(Path, FileMode.Create, FileAccess.Write));

		// write each product
		foreach (Product product in products)
		{
			textOut.Write(product.Code + Sep);
			textOut.Write(product.Description + Sep);
			textOut.WriteLine(product.Price);
		}
	}
}