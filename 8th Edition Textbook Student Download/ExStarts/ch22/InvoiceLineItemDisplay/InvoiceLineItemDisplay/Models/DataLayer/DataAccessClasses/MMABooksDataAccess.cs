namespace InvoiceLineItemDisplay.Models.DataLayer;

public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public int CustomerCount => context.Customers.Count();

    public List<Invoice> GetInvoices() =>
        context.Invoices
            .OrderBy(i => i.InvoiceDate)
            .ToList();

    public List<InvoiceLineItem> GetInvoiceLineItems(int invoiceId) =>
        context.InvoiceLineItems
            .Where(li => li.InvoiceId == invoiceId)
            .OrderBy(li => li.ProductCode)
            .ToList();

}
