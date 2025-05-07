using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoiceDisplay.Models.DataLayer;

public partial class OrderOption
{
    [Key]
    [Column("OptionID")]
    public int OptionId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal SalesTaxRate { get; set; }

    [Column(TypeName = "money")]
    public decimal FirstBookShipCharge { get; set; }

    [Column(TypeName = "money")]
    public decimal AdditionalBookShipCharge { get; set; }
}
