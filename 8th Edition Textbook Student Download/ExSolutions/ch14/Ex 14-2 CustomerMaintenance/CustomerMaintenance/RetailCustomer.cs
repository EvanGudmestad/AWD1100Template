namespace CustomerMaintenance
{
    public class RetailCustomer : Customer
    {
        public RetailCustomer() { }

        public RetailCustomer(string lastName, string firstName,
            string email, string homePhone) : base(lastName, firstName, email) => 
            HomePhone = homePhone;

        public string HomePhone { get; set; } = "";

        public override string GetDisplayText() =>
            $"{base.GetDisplayText()} ph: {HomePhone}";
    }
}
