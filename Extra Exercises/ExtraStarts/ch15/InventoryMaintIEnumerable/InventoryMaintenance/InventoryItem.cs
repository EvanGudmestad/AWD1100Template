namespace InventoryMaintenance
{
    public class InventoryItem : IDisplayable
    {
        public InventoryItem() { }

        public InventoryItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        public int ItemNo { get; set; }
        public string Description { get; set; } = "";
        public decimal Price { get; set; }

        public virtual string GetDisplayText() => $"{ItemNo}    {Description} ({Price:c})";
    }
}
