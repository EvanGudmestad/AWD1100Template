namespace InventoryMaintenance
{
    public class InventoryItemList
    {
        private List<InventoryItem> items;

        public InventoryItemList()
        {
            items = new List<InventoryItem>();
        }

        public int Count => items.Count;

        public InventoryItem GetItemByIndex(int i) => items[i];

        public void Add(InventoryItem item) => items.Add(item);

        public void Add(int itemNo, string description, decimal price)
        {
            InventoryItem i = new(itemNo, description, price);
            items.Add(i);
        }

        public void Remove(InventoryItem item) => items.Remove(item);

        public void Fill() => items = InventoryDB.GetItems();

        public void Save() => InventoryDB.SaveItems(items);
    }
}
