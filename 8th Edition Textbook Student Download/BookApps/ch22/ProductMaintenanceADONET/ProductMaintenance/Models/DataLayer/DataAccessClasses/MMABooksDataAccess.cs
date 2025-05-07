using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ProductMaintenance.Models.DataLayer;

public record ProductDTO(string ProductCode, string Description, decimal UnitPrice);

public class MMABooksDataAccess
{
    private string ConnectionString =>
        ConfigurationManager.ConnectionStrings["MMABooks"].ConnectionString;

    public Product? FindProduct(string productCode)
    {
        try
        {
            Product product = null!; // default return value

            string selectStatement =
                "SELECT ProductCode, Description, UnitPrice, " +
                "    OnHandQuantity, Rowversion " +
                "FROM Products " +
                "WHERE ProductCode = @ProductCode";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(selectStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", productCode);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);

            if (reader.Read())
            {
                product = new()
                {
                    ProductCode = reader["ProductCode"].ToString()!,
                    Description = reader["Description"].ToString()!,
                    UnitPrice = (decimal)reader["UnitPrice"],
                    OnHandQuantity = (int)reader["OnHandQuantity"],
                    Rowversion = (byte[])reader["Rowversion"]
                };
            }
            return product;
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public List<ProductDTO> GetAllProducts()
    {
        try
        {
            List<ProductDTO> products = new();

            string selectStatement =
                "SELECT ProductCode, Description, UnitPrice " +
                "FROM Products " +
                "ORDER BY Description";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(selectStatement, connection);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                products.Add(new ProductDTO(
                    reader["ProductCode"].ToString()!,
                    reader["Description"].ToString()!,
                    (decimal)reader["UnitPrice"]));
            }
            return products;
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    public void AddProduct(Product product)
    {
        try
        {
            string insertStatement =
                "INSERT Products (ProductCode, Description, UnitPrice) " +
                "VALUES (@ProductCode, @Description, @UnitPrice)";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(insertStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            connection.Open();
            int count = command.ExecuteNonQuery();

            if (count > 0)
            {  
                Reload(product);  // to get rowversion 
            }
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
            string updateStatement =
              "UPDATE Products SET " +
                  "Description = @Description, " +
                  "UnitPrice = @UnitPrice " +
              "WHERE ProductCode = @ProductCode " +
              "AND Rowversion = @Rowversion";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(updateStatement, connection);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Rowversion", product.Rowversion);
            connection.Open();
            int count = command.ExecuteNonQuery();

            string status = Reload(product); 
            if (count == 0)
            {
                throw CreateConcurrencyException(status);
            }
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
            string deleteStatement =
              "DELETE FROM Products " +
              "WHERE ProductCode = @ProductCode " +
              "AND Rowversion = @Rowversion";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(deleteStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Rowversion", product.Rowversion);
            connection.Open();
            int count = command.ExecuteNonQuery();

            if (count == 0)
            {
                string status = Reload(product);
                throw CreateConcurrencyException(status);
            }
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
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

    private DataAccessException CreateDataAccessException(SqlException ex)
    {
        string msg = "";
        foreach (SqlError error in ex.Errors)
        {
            msg += $"ERROR CODE {error.Number}: {error.Message}\n";
        }

        return new DataAccessException(msg, "Database Error");
    }

    public void SimulateConcurrentUpdate(string productCode)
    {
        string updateStatement =
            "UPDATE Products SET OnHandQuantity = -1 " +
            "WHERE ProductCode = @ProductCode";

        using SqlConnection connection = new(ConnectionString);
        using SqlCommand command = new(updateStatement, connection);
        command.Parameters.AddWithValue("@ProductCode", productCode);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
