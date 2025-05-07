namespace InventoryMaintenance
{
    /// <summary>
    /// Represents an inventory item.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public InventoryItem() { }

        /// <summary>
        /// A constructor that accepts the values for an item
        /// </summary>
        /// <param name="itemNo">The item's number.</param>
        /// <param name="description">The item's description.</param>
        /// <param name="price">The item's price.</param>
        public InventoryItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }

        /// <summary>
        /// A property that gets and sets the item's number.
        /// </summary>
        public int ItemNo { get; set; }

        /// <summary>
        /// A property that gets and sets the item's description.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// A property that gets and sets the item's price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// A method that formats the item's values for display.
        /// </summary>
        /// <returns>The formatted string</returns>
        public string GetDisplayText() => $"{ItemNo}    {Description} ({Price:c})";
    }
}
