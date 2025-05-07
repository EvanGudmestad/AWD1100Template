namespace ProductMaintenance
{
	public static class ProductDB
	{
		private const string dir = @"C:\C#\Files\";
		private const string path = dir + "Products.txt";

		public static List<Product> GetProducts()
		{
			// if the directory doesn't exist, create it
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			// create the object for the input stream for a text file
			StreamReader textIn =
				new StreamReader(
				new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

			// create the list
			List<Product> products = new();

			// read the data from the file and store it in the list
			while (textIn.Peek() != -1)
			{
				string row = textIn.ReadLine() ?? "";
				string[] columns = row.Split('|');

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

			// close the input stream for the text file
			textIn.Close();

			return products;
		}

		public static void SaveProducts(List<Product> products)
		{
			// create the output stream for a text file that exists
			StreamWriter textOut =
				new StreamWriter(
				new FileStream(path, FileMode.Create, FileAccess.Write));

			// write each product
			foreach (Product product in products)
			{
				textOut.Write(product.Code + "|");
				textOut.Write(product.Description + "|");
				textOut.WriteLine(product.Price);
			}

			// close the output stream for the text file
			textOut.Close();
		}
	}
}