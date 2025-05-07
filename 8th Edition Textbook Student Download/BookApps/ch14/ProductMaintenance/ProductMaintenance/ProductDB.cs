namespace ProductMaintenance
{
    public static class ProductDB
    {
        private const string dir = @"C:\C#\Files\";
        private const string path = dir + "Products14.txt";

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
                if (columns[0] == "Book")
                {
                    Book b = new Book();
                    products.Add(GetBook(b, columns));
                }
                else    // Software
                {
                    Software s = new Software();
                    products.Add(GetSoftware(s, columns));
                }
            }
            textIn.Close();
            return products;
        }

        private static Book GetBook(Book b, string[] columns)
        {
            b = (Book)GetProduct(b, columns);
            b.Author = columns[4];
            return b;
        }

        private static Software GetSoftware(Software s, string[] columns)
        {
            s = (Software)GetProduct(s, columns);
            s.Version = columns[4];
            return s;
        }

        private static Product GetProduct(Product p, string[] columns)
        {
            p.Code = columns[1];
            p.Description = columns[2];
            p.Price = Convert.ToDecimal(columns[3]);
            return p;
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
                if (product is Book b)
                    WriteBook(b, textOut);
                else if (product is Software s)
                    WriteSoftware(s, textOut);
            }
            // write the end of the document
            textOut.Close();

        }
        private static void WriteBook(Book product,
            StreamWriter textOut)
        {
            textOut.Write("Book" + "|");
            WriteProduct(product, textOut);
            textOut.WriteLine(product.Author);
        }

        private static void WriteSoftware(Software product,
            StreamWriter textOut)
        {
            textOut.Write("Software" + "|");
            WriteProduct(product, textOut);
            textOut.WriteLine(product.Version);
        }

        private static void WriteProduct(Product product,
            StreamWriter textOut)
        {
            textOut.Write(product.Code + "|");
            textOut.Write(product.Description + "|");
            textOut.Write(Convert.ToString(product.Price) + "|");
        }
    }
}