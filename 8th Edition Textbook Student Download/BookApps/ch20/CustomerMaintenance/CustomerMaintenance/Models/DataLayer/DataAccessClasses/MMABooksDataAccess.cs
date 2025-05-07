using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CustomerMaintenance.Models.DataLayer;

public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public Customer? FindCustomer(int customerId)
    {
        try
        {
            Customer customer = context.Customers
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.StateNavigation)
                .FirstOrDefault()!;

            return customer;
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }

    }

    public List<State> GetStates()
    {
        try
        {
            return context.States.OrderBy(s => s.StateName).ToList();
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void AddCustomer(Customer customer)
    {
        try
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw CreateUpdateException(ex);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void UpdateCustomer(Customer customer)
    {
        try
        {
            //ConcurrencyTest.SimulateCustomerUpdate(context, customer.CustomerId);
            //ConcurrencyTest.SimulateCustomerDelete(context, customer.CustomerId);
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = context.Entry(customer).State;
            throw CreateConcurrencyException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateUpdateException(ex);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void RemoveCustomer(Customer customer)
    {
        try
        {
            //ConcurrencyTest.SimulateCustomerUpdate(context, customer.CustomerId);
            //ConcurrencyTest.SimulateCustomerDelete(context, customer.CustomerId);
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = context.Entry(customer).State;
            throw CreateConcurrencyException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateUpdateException(ex);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    private DataAccessException CreateConcurrencyException(EntityState state)
    {
        string msg = "";
        if (state == EntityState.Detached)
        {
            msg = "Another user has deleted that record.";
        }
        else
        {
            msg = "Another user has updated that record.\n" +
            "The current database values will be displayed.";
        }

        return new DataAccessException(msg, "Concurrency Error");
    }

    private DataAccessException CreateUpdateException(DbUpdateException ex)
    {
        var sqlException = (SqlException)ex.InnerException!;
        return CreateDataAccessException(sqlException);
    }

    private DataAccessException CreateDataAccessException(SqlException ex)
    {
        string msg = "";
        foreach (SqlError error in ex.Errors)
        {
            msg += $"ERROR CODE {error.Number}: {error.Message}\n";
        }

        return new DataAccessException(msg, "Database Error");
    }

}
