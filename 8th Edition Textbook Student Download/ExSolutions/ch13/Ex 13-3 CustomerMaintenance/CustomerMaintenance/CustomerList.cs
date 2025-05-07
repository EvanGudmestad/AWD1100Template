namespace CustomerMaintenance
{
    public class CustomerList
    {
        private List<Customer> customers;

        public CustomerList() => customers = new();

        public delegate void ChangeHandler(CustomerList customers);
        public event ChangeHandler Changed = null!;

        public int Count => customers.Count;

        public Customer this[int i]
        {
            get => customers[i];
            set
            {
                customers[i] = value;
                if (Changed != null)
                    Changed(this);
            }
        }

        public void Fill() => customers = CustomerDB.GetCustomers();

        public void Save() => CustomerDB.SaveCustomers(customers);

        public void Add(Customer customer)
        {
            customers.Add(customer);
            if (Changed != null)
                Changed(this);
        }

        public void Remove(Customer customer) 
        { 
            customers.Remove(customer);
            if (Changed != null)
                Changed(this);
        }

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
