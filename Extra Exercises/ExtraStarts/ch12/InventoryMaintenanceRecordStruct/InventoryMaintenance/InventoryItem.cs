using System.Diagnostics.CodeAnalysis;

namespace InventoryMaintenance
{
    public class InventoryItem
    {
        public InventoryItem() { }

        [SetsRequiredMembers]
        public InventoryItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        public required int ItemNo { get; set; }
        public required string Description { get; set; } = "";
        public required decimal Price { get; set; }

        public string GetDisplayText() => $"{ItemNo}    {Description} ({Price:c})";
    }
}
