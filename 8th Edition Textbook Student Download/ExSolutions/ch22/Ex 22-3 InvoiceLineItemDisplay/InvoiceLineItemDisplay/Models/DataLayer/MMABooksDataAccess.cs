namespace InvoiceLineItemDisplay.Models.DataLayer;

public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public int CustomerCount => context.Customers.Count();

    public object GetInvoices() =>
        context.Invoices
            .OrderBy(i => i.InvoiceDate)
            .Select(i => new { i.InvoiceId, i.InvoiceDate, i.ProductTotal, 
                i.SalesTax, i.Shipping, i.InvoiceTotal })
            .ToList();

    public object GetInvoiceLineItems(int invoiceId) =>
        context.InvoiceLineItems
            .Where(li => li.InvoiceId == invoiceId)
            .OrderBy(li => li.ProductCode)
            .Select(li => new { li.ProductCode, li.Quantity, li.UnitPrice, li.ItemTotal })
            .ToList();

}
