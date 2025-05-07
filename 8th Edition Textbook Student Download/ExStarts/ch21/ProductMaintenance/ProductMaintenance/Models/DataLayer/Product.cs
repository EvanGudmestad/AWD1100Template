namespace ProductMaintenance.Models.DataLayer;

public partial class Product
{
    public string ProductCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int OnHandQuantity { get; set; }

    public byte[] Rowversion { get; set; } = null!;
}
