namespace ProductMaintenance;

public static class ProductDB
{
	private const string Dir = @"C:\C#\files\";
	private const string Path = Dir + "Products.dat";

	public static List<Product> GetProducts()
	{
		// if the directory doesn't exist, create it
		if (!Directory.Exists(Dir))
			Directory.CreateDirectory(Dir);

        // create the object for the input stream for a binary file
        using BinaryReader binaryIn = new(
            new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read));

        // create the list
        List<Product> products = new();

		// read the data from the file and store it in the list
		while (binaryIn.PeekChar() != -1)
		{
			Product product = new()
			{
				Code = binaryIn.ReadString(),
				Description = binaryIn.ReadString(),
				Price = binaryIn.ReadDecimal()
            };
			products.Add(product);
		}

		return products;
	}

	public static void SaveProducts(List<Product> products)
	{
        // create the output stream for a binary file that exists
        using BinaryWriter binaryOut = new(
            new FileStream(Path, FileMode.Create, FileAccess.Write));

        // write each product
        foreach (Product product in products)
        {
            binaryOut.Write(product.Code);
            binaryOut.Write(product.Description);
            binaryOut.Write(product.Price);
        }
    }
}