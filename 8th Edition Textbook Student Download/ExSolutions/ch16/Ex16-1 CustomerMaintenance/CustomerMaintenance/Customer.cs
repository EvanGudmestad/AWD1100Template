namespace CustomerMaintenance;

/// <summary>
/// Customer class
/// </summary>
public class Customer
{
    /// <summary>
	/// Creates a Customer object with default values.
	/// </summary>
    public Customer() { }

    /// <summary>
	/// Creates a Customer object with the specified values.
	/// </summary>
	/// <param name="firstName">The first name to be stored in the object.</param>
	/// <param name="lastName">The last name to be stored in the object.</param>
	/// <param name="email">The email address to be stored in the object.</param>
    public Customer(string firstName, string lastName, string email) =>
        (this.FirstName, this.LastName, this.Email) = (firstName, lastName, email);

    /// <summary>
	/// Gets or sets the customer's first name.
	/// </summary>
    public string FirstName { get; set; } = "";

    /// <summary>
	/// Gets or sets the customer's last name.
	/// </summary>
    public string LastName { get; set; } = "";

    /// <summary>
	/// Gets or sets the customer's email address.
	/// </summary>
    public string Email { get; set; } = "";

    /// <summary>
	/// Concatenates the first name, last name, and email address for display.
	/// </summary>
	/// <returns>The formatted string.</returns>
    public string GetDisplayText() => $"{FirstName} {LastName}, {Email}";
}