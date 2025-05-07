using System.Security.Cryptography.X509Certificates;

namespace CustomerMaintenance
{
    public class WholesaleCustomer : Customer
    {
        public WholesaleCustomer() { }

        public WholesaleCustomer(string lastName, string firstName,
            string email, string company) : base(lastName, firstName, email) =>
            Company = company;

        public string Company { get; set; } = "";

        public override string GetDisplayText() => 
            $"{base.GetDisplayText()} ({Company})";
    }
}
