using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CustomerMaintenance.Models.DataLayer;

public class MMABooksDataAccess
{
    private string ConnectionString =>
        ConfigurationManager.ConnectionStrings["MMABooks"].ConnectionString;

    public Customer? FindCustomer(int customerId)
    {
        try
        {
            Customer customer = null!; // default return value

            string selectStatement =
                "SELECT c.CustomerID, c.Name, c.Address, c.City, c.State, s.StateName, " +
                    "c.ZipCode, c.Rowversion " +
                "FROM Customers AS c " +
                "JOIN States AS s " +
                "ON c.State = s.StateCode " +
                "WHERE c.CustomerID = @CustomerID";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(selectStatement, connection);
            command.Parameters.AddWithValue("@CustomerID", customerId);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                customer = new()
                {
                    CustomerId = (int)reader["CustomerID"],
                    Name = reader["Name"].ToString()!,
                    Address = reader["Address"].ToString()!,
                    City = reader["City"].ToString()!,
                    State = reader["State"].ToString()!,
                    ZipCode = reader["ZipCode"].ToString()!,
                    StateNavigation = new()
                    {
                        StateCode = reader["State"].ToString()!,
                        StateName = reader["StateName"].ToString()!,
                    },
                    Rowversion = (byte[])reader["Rowversion"]
                };
            }

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
            List<State> states = new();

            string selectStatement = 
                "SELECT StateCode, StateName " + 
                "FROM States " + 
                "ORDER BY StateName";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(selectStatement, connection);
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                State state = new()
                {
                    StateCode = reader["StateCode"].ToString()!,
                    StateName = reader["StateName"].ToString()!
                };
                states.Add(state);
            }

            return states;
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
            string insertStatement =
                "INSERT Customers (Name, Address, City, State, ZipCode) " +
                "VALUES (@Name, @Address, @City, @State, @ZipCode)";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(insertStatement, connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@State", customer.State);
            command.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            connection.Open();
            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                // get newly created CustomerId from database - use it to
                // get updated rowversion and state info from database
                command.CommandText = 
                    "SELECT IDENT_CURRENT('Customers') " + 
                    "FROM Customers";
                customer.CustomerId = Convert.ToInt32(command.ExecuteScalar());
                Reload(customer);
            }
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
            //ConcurrencyTest.SimulateCustomerUpdate(customer.CustomerId);
            //ConcurrencyTest.SimulateCustomerDelete(customer.CustomerId);

            string updateStatement =
              "UPDATE Customers SET " +
                  "Name = @Name, " +
                  "Address = @Address, " +
                  "City = @City, " +
                  "State = @State, " +
                  "ZipCode = @ZipCode " +
              "WHERE CustomerID = @CustomerID " +
                "AND Rowversion = @Rowversion";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(updateStatement, connection);
            command.Parameters.AddWithValue("@Name", customer.Name);
            command.Parameters.AddWithValue("@Address", customer.Address);
            command.Parameters.AddWithValue("@City", customer.City);
            command.Parameters.AddWithValue("@State", customer.State);
            command.Parameters.AddWithValue("@ZipCode", customer.ZipCode);
            command.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
            command.Parameters.AddWithValue("@Rowversion", customer.Rowversion);
            connection.Open();
            int count = command.ExecuteNonQuery();

            // need to reload values from database no matter what - if update successful,
            // need to get new rowversion value and make sure state name is correct. If
            // concurrency error, need to get database values to display to user. 
            string status = Reload(customer);

            // check for concurrency error
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

    public void RemoveCustomer(Customer customer)
    {
        try
        {
            //ConcurrencyTest.SimulateCustomerUpdate(customer.CustomerId);
            
            string deleteStatement =
              "DELETE FROM Customers " +
              "WHERE CustomerID = @CustomerID " +
                  "AND Rowversion = @Rowversion";

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(deleteStatement, connection);
            command.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
            command.Parameters.AddWithValue("@Rowversion", customer.Rowversion);
            connection.Open();
            int count = command.ExecuteNonQuery();

            // check for concurrency error
            if (count == 0)
            {
                string status = Reload(customer);
                throw CreateConcurrencyException(status);
            }
        }
        catch (SqlException ex)
        {
            throw CreateDataAccessException(ex);
        }
    }

    private string Reload(Customer customer)
    {
        // get current database values
        Customer current = FindCustomer(customer.CustomerId)!;

        if (current == null)
        {
            return "Deleted";
        }
        else
        {
            // load current values in Customer object
            customer.Name = current.Name;
            customer.Address = current.Address;
            customer.City = current.City;
            customer.State = current.State;
            customer.ZipCode = current.ZipCode;
            customer.Rowversion = current.Rowversion;
            customer.StateNavigation = new()
            {
                StateCode = current.State,
                StateName = current.StateNavigation.StateName
            };

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

}
