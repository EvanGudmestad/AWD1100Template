namespace CustomerInvoiceDisplay.Models.DataLayer;

public record CustomerDTO(int CustomerId, string Name, string Address,
    string City, string State, string ZipCode);

public record InvoiceDTO(int InvoiceId, DateTime InvoiceDate, decimal ProductTotal, 
    decimal SalesTax, decimal Shipping, decimal InvoiceTotal);


public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public int CustomerCount => context.Customers.Count();

    public List<CustomerDTO> GetCustomers(int skip, int take) => 
        context.Customers
            .OrderBy(c => c.Name)
            .Select(c => new CustomerDTO(c.CustomerId, c.Name, c.Address, c.City, c.State, c.ZipCode))
            .Skip(skip)
            .Take(take)
            .ToList();

    public List<InvoiceDTO> GetCustomerInvoices(int customerID) => 
        context.Invoices
            .Where(i => i.CustomerId == customerID)
            .OrderBy(i => i.InvoiceId)
            .Select(i => new InvoiceDTO(i.InvoiceId, i.InvoiceDate, i.ProductTotal, i.SalesTax, i.Shipping, i.InvoiceTotal))
            .ToList();

}
