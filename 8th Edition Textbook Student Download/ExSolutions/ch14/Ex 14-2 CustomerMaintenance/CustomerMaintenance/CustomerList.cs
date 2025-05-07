namespace CustomerMaintenance
{
    public class CustomerList : List<Customer>
    {
        public delegate void ChangeHandler(CustomerList customers);
        public event ChangeHandler Changed = null!;

        public new void Add(Customer customer)
        {
            base.Add(customer);
            if (Changed != null)
                Changed(this);
        }

        public new void Remove(Customer customer)
        {
            base.Remove(customer);
            if (Changed != null)
                Changed(this);
        }

        public void Fill() 
        {
            List<Customer> customers = CustomerDB.GetCustomers();
            foreach (Customer customer in customers)
            {
                base.Add(customer);
            }
        } 

        public void Save() => CustomerDB.SaveCustomers(this);
        
        public static CustomerList operator + (CustomerList list, Customer c)
        {
            list.Add(c);
            return list;
        }

        public static CustomerList operator - (CustomerList list, Customer c)
        {
            list.Remove(c);
            return list;
        }

    }
}
