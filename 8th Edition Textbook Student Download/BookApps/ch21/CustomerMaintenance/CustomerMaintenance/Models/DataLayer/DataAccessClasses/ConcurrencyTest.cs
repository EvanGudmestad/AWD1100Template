using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CustomerMaintenance.Models.DataLayer;

public static class ConcurrencyTest
{
    private static string ConnectionString =>
        ConfigurationManager.ConnectionStrings["MMABooks"].ConnectionString;

    public static void SimulateCustomerUpdate(int customerId)
    {
        string updateStatement =
            "UPDATE Customers " +
            "SET Address = '123 Main' " +
            "WHERE CustomerID = @CustomerID";
        using SqlConnection connection = new(ConnectionString);
        using SqlCommand command = new(updateStatement, connection);
        command.Parameters.AddWithValue("@CustomerID", customerId);
        connection.Open();
        command.ExecuteNonQuery();
    }

    public static void SimulateCustomerDelete(int customerId)
    {
        string deleteStatement =
            "DELETE Customers " +
            "WHERE CustomerID = @CustomerID";
        using SqlConnection connection = new(ConnectionString);
        using SqlCommand command = new(deleteStatement, connection);
        command.Parameters.AddWithValue("@CustomerID", customerId);
        connection.Open();
        command.ExecuteNonQuery();
    }
}
