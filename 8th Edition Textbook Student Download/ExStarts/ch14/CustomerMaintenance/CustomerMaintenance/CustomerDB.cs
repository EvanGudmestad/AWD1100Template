namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        private const string dir = @"C:\C#\Files\";
        private const string path = dir + "Customers.txt";

        public static void SaveCustomers(List<Customer> customers)
        {
            // create the output stream for a text file that exists
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            // write each customer
            foreach (Customer customer in customers)
            {
                if (customer is WholesaleCustomer wholesale)
                {
                    WriteWholesale(wholesale, textOut);
                }
                else if (customer is RetailCustomer retail)
                {
                    WriteRetail(retail, textOut);
                }
            }

            // write the end of the document
            textOut.Close();
        }

        public static void WriteWholesale(WholesaleCustomer customer, StreamWriter textOut)
        {
            textOut.Write("Wholesale" + "|");
            textOut.Write(customer.FirstName + "|");
            textOut.Write(customer.LastName + "|");
            textOut.Write(customer.Email + "|");
            textOut.WriteLine(customer.Company);
        }

        public static void WriteRetail(RetailCustomer customer, StreamWriter textOut)
        {
            textOut.Write("Retail" + "|");
            textOut.Write(customer.FirstName + "|");
            textOut.Write(customer.LastName + "|");
            textOut.Write(customer.Email + "|");
            textOut.WriteLine(customer.HomePhone);
        }

        public static List<Customer> GetCustomers()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                    new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            // create the array list for customers
            List<Customer> customers = new();

            // read the data from the file and store it in the ArrayList
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                string[] columns = row.Split('|');
                if (columns[0] == "Wholesale")
                {
                    customers.Add(GetWholesale(columns));
                }
                else
                {
                    customers.Add(GetRetail(columns));
                }
            }

            textIn.Close();

            return customers;
        }

        public static WholesaleCustomer GetWholesale(string[] columns)
        {
            WholesaleCustomer customer = new()
            {
                FirstName = columns[1],
                LastName = columns[2],
                Email = columns[3],
                Company = columns[4]
            };
            return customer;
        }

        public static RetailCustomer GetRetail(string[] columns)
        {
            RetailCustomer customer = new()
            {
                FirstName = columns[1],
                LastName = columns[2],
                Email = columns[3],
                HomePhone = columns[4]
            };
            return customer;
        }
    }
}
