using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ProductMaintenance.Models.DataLayer;

public record ProductDTO(string ProductCode, string Description, decimal UnitPrice);

public class MMABooksDataAccess
{
    private MMABooksContext context = new();

    public Product? FindProduct(string productCode)
    {
        try
        {
            return context.Products.Find(productCode);
        }
        catch(SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public List<ProductDTO> GetAllProducts() =>
        context.Products
            .OrderBy(p => p.Description)
            .Select(p => new ProductDTO(p.ProductCode, p.Description,
                p.UnitPrice))
            .ToList();

    public void AddProduct(Product product)
    {
        try
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void UpdateProduct(Product product)
    {
        try
        {
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = context.Entry(product).State;
            throw CreateDataAccessException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }

        catch (SqlException ex) 
        { 
            throw CreateDataAccessException(ex);
        }
    }

    public void RemoveProduct(Product product)
    {
        try
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            ex.Entries.Single().Reload();
            var state = context.Entry(product).State;
            throw CreateDataAccessException(state);
        }
        catch (DbUpdateException ex)
        {
            throw CreateDataAccessException(ex);
        }

        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    private DataAccessException CreateDataAccessException(
        EntityState state)
    {
        string msg = "";
        if (state == EntityState.Detached)
            msg = "Another user has deleted that record.";
        else
            msg = "Another user has updated that record.\n" +
            "The current database values will be displayed.";

        return new DataAccessException(msg, "Concurrency Error");
    }

    private DataAccessException CreateDataAccessException(
        DbUpdateException ex)
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
