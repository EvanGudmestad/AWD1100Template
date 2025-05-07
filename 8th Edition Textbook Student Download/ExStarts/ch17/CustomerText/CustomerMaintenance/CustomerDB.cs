namespace CustomerMaintenance
{
    public static class CustomerDB
    {
        // TODO: Add the directory and path here

        public static void SaveCustomers(List<Customer> customers)
        {
            // TODO: Add code that writes the collection of Customer objects 
            // to a text file
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new();

            // TODO: Add code that reads a collection of Customer objects 
            // from a text file

            return customers;
        }
    }
}
