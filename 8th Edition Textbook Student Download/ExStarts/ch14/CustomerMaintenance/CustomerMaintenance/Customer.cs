namespace CustomerMaintenance
{
    public class Customer
    {
        private string firstName = "";
        private string lastName = "";
        private string email = "";

        public Customer() { }

        public Customer(string firstName, string lastName, string email) =>
            (this.FirstName, this.LastName, this.Email) = (firstName, lastName, email);

        public string FirstName 
        { 
            get => firstName; 
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException(
                        "Maximum length of first name is 30 characters.");
                }
                firstName = value;
            } 
        }

        public string LastName 
        { 
            get => lastName; 
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException(
                        "Maximum length of last name is 30 characters.");
                }
                lastName = value;
            }
        }

        public string Email 
        { 
            get => email; 
            set
            {
                if (value.Length > 30)
                {
                    throw new ArgumentException(
                        "Maximum length of email address is 30 characters.");
                }
                email = value;
            }
        }

        public string GetDisplayText() => $"{FirstName} {LastName}, {Email}";
    }
}
