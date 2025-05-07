using Microsoft.EntityFrameworkCore;

namespace CustomerMaintenance.Models.DataLayer;

public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public Customer? FindCustomer(int customerId) =>
        context.Customers
            .Where(c => c.CustomerId == customerId)
            .Include(c => c.StateNavigation)
            .FirstOrDefault();

    public List<State> GetStates() => 
        context.States.OrderBy(s => s.StateName).ToList();

    public void AddCustomer(Customer customer)
    {
        context.Customers.Add(customer);
        context.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        context.SaveChanges();
    }

    public void RemoveCustomer(Customer customer)
    {
        context.Customers.Remove(customer);
        context.SaveChanges();
    }
}
