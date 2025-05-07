namespace InventoryMaintenance
{
    public class InventoryItemList
    {
        private List<InventoryItem> items;

        public delegate void ChangeHandler(InventoryItemList invItems);
        public event ChangeHandler Changed = null!;

        public InventoryItemList() => items = new();

        public int Count => items.Count;

        public InventoryItem this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                else if (i > items.Count)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                return items[i];
            }
            set
            {
                items[i] = value;
                if (Changed != null) 
                    Changed(this);
            }
        }

        public void Add(InventoryItem item)
        {
            items.Add(item);
            if (Changed != null)
                Changed(this);
        }

        public void Add(int itemNo, string description, decimal price)
        {
            InventoryItem item = new(itemNo, description, price);
            items.Add(item);
            if (Changed != null)
                Changed(this);
        }

        public void Remove(InventoryItem item)
        {
            items.Remove(item);
            if (Changed != null)
                Changed(this);
        }

        public static InventoryItemList operator + (InventoryItemList list, InventoryItem item)
        {
            list.Add(item);
            return list;
        }

        public static InventoryItemList operator - (InventoryItemList list, InventoryItem item)
        {
            list.Remove(item);
            return list;
        }

        public void Fill() => items = InventoryDB.GetItems();

        public void Save() => InventoryDB.SaveItems(items);
    }
}
