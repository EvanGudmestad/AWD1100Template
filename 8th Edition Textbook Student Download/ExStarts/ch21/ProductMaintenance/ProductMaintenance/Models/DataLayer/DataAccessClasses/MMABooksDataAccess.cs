using Microsoft.Data.SqlClient;

namespace ProductMaintenance.Models.DataLayer;

public class MMABooksDataAccess
{
    // the code to get the connection string

    public Product? FindProduct(string productCode)
    {
        try
        {
            Product product = null!; // default return value

            // the code to get the product

            return product;
        }
        catch(SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void AddProduct(Product product)
    {
        try
        {
            // the code to add the product
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
            // the code to update the product
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
            // the code to delete the product
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    private DataAccessException CreateConcurrencyException(string status)
    {
        string msg = "";
        if (status.ToLower() == "deleted")
            msg = "Another user has deleted that record.";
        else
            msg = "Another user has updated that record.\n" +
            "The current database values will be displayed.";

        return new DataAccessException(msg, "Concurrency Error");
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
