//using Microsoft.Data.SqlClient;

namespace ProductMaintenance.Models.DataLayer;

public class MMABooksDataAccess
{
    public Product? FindProduct(string productCode)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void RemoveProduct(Product product)
    {
        throw new NotImplementedException();
    }

    private string Reload(Product product)
    {
        // get current database values
        Product current = FindProduct(product.ProductCode)!;

        if (current == null)
        {
            return "Deleted";
        }
        else
        {
            // load current database values 
            product.ProductCode = current.ProductCode;
            product.Description = current.Description;
            product.UnitPrice = current.UnitPrice;
            product.OnHandQuantity = current.OnHandQuantity;
            product.Rowversion = current.Rowversion;

            return "Updated";
        }
    }

    private DataAccessException CreateConcurrencyException(string status)
    {
        string msg = "";

        if (status.ToLower() == "deleted")
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

    //private DataAccessException CreateDataAccessException(SqlException ex)
    //{
    //    string msg = "";
    //    foreach (SqlError error in ex.Errors)
    //    {
    //        msg += $"ERROR CODE {error.Number}: {error.Message}\n";
    //    }

    //    return new DataAccessException(msg, "Database Error");
    //}

}
