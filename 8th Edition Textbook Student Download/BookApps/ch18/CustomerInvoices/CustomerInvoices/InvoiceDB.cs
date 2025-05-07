namespace CustomerInvoices;

public static class InvoiceDB
{
    private const string Dir = @"C:\C#\Files\";
    private const string Path = Dir + "Invoices.txt";
    private const string sep = "|";

    public static List<Invoice> GetInvoices()
    {
        List<Invoice> invoices = new();

        using StreamReader textIn = new(
            new FileStream(Path, FileMode.Open, FileAccess.Read));

        while (textIn.Peek() != -1)
        {
            string row = textIn.ReadLine() ?? "";
            string[] columns = row.Split(sep);

            if (columns.Length == 7)
            {
                Invoice invoice = new()
                {
                    InvoiceID = Convert.ToInt32(columns[0]),
                    CustomerID = Convert.ToInt32(columns[1]),
                    InvoiceDate = Convert.ToDateTime(columns[2]),
                    ProductTotal = Convert.ToDecimal(columns[3]),
                    SalesTax = Convert.ToDecimal(columns[4]),
                    Shipping = Convert.ToDecimal(columns[5]),
                    InvoiceTotal = Convert.ToDecimal(columns[6])
                };
                invoices.Add(invoice);
            }
        }

        return invoices;
    }
}
