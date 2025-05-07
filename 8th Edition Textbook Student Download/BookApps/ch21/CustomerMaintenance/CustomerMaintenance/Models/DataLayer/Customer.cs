namespace CustomerMaintenance.Models.DataLayer;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string City { get; set; } = "";
    public string State { get; set; } = "";
    public string ZipCode { get; set; } = "";

    public byte[] Rowversion { get; set; } = null!;

    public State StateNavigation { get; set; } = null!;
}
