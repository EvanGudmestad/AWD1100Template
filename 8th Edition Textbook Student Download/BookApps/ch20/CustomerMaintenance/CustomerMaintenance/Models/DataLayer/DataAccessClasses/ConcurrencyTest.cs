using Microsoft.EntityFrameworkCore;

namespace CustomerMaintenance.Models.DataLayer;

public static class ConcurrencyTest
{
    public static void SimulateCustomerUpdate(MMABooksContext context, int customerId)
    {
        context.Database.ExecuteSqlRaw(
            "UPDATE Customers " +
            "SET address = '123 Main St' " +
            "WHERE CustomerId = " + customerId);
    }

    public static void SimulateCustomerDelete(MMABooksContext context, int customerId)
    {
        context.Database.ExecuteSqlRaw(
            "DELETE Customers " +
            "WHERE CustomerId = " + customerId);
    }
}
