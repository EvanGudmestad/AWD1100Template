namespace CloneCustomer
{
    public class Customer : ICloneable, IDisplayable
    {
        public Customer() { }

        public Customer(string firstName, string lastName, string email) =>
            (this.FirstName, this.LastName, this.Email) = (firstName, lastName, email);

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";

        public string GetDisplayText() => $"{FirstName} {LastName}, {Email}";

        public object Clone() => new Customer(FirstName, LastName, Email);
    }
}
