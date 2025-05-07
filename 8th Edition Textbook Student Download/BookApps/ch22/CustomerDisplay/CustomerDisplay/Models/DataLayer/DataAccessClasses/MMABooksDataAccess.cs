namespace CustomerDisplay.Models.DataLayer;


public record CustomerDTO(string Name, string Address,
    string City, string State, string ZipCode);


public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public int CustomerCount => context.Customers.Count();

    public List<CustomerDTO> GetCustomers(int skip, int take) =>
        context.Customers
            .OrderBy(c => c.Name)
            .Select(c => new CustomerDTO(c.Name, c.Address, c.City, c.State, c.ZipCode))
            .Skip(skip)
            .Take(take)
            .ToList();
}
