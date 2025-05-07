namespace CustomerInvoices;

public static class CustomerDB
{
    private const string Dir = @"C:\C#\Files\";
    private const string Path = Dir + "Customers18.txt";
    private const string sep = "|";

    public static List<Customer> GetCustomers()
    {
        List<Customer> customers = new();

        using StreamReader textIn = new(
            new FileStream(Path, FileMode.Open, FileAccess.Read));

        while (textIn.Peek() != -1)
        {
            string row = textIn.ReadLine() ?? "";
            string[] columns = row.Split(sep);

            if (columns.Length == 2)
            {
                Customer customer = new()
                {
                    CustomerID = Convert.ToInt32(columns[0]),
                    Name = columns[1]
                };
                customers.Add(customer);
            }
        }

        return customers;
    }
}
