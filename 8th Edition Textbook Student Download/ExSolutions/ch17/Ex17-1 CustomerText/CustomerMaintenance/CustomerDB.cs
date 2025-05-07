namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        private const string Dir = @"C:\C#\files\";
        private const string Path = Dir + "Customers.txt";
        private const string Sep = "|";

        public static void SaveCustomers(List<Customer> customers)
        {
            using StreamWriter textOut = new(
                new FileStream(Path, FileMode.Create, FileAccess.Write));

            foreach (Customer customer in customers)
            {
                textOut.Write(customer.FirstName + Sep);
                textOut.Write(customer.LastName + Sep);
                textOut.WriteLine(customer.Email);
            }
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new();

            if (!Directory.Exists(Dir))
                Directory.CreateDirectory(Dir);

            using StreamReader textIn = new(
                new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read));

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                string[] columns = row.Split(Sep);

                if (columns.Length == 3)
                {
                    Customer customer = new()
                    {
                        FirstName = columns[0],
                        LastName = columns[1],
                        Email = columns[2]
                    };
                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}
