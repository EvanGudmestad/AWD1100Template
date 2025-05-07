namespace InventoryMaintenance
{
	public static class InventoryDB
	{
		private const string Path = @"..\..\..\InventoryItems.txt";
		private const string Delimiter = "|";

		public static List<InventoryItem> GetItems()
		{
			// create the object for the input stream for a text file
			using StreamReader textIn =
				new StreamReader(
				new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read));

			// create the list
			List<InventoryItem> items = new();

			// read the data from the file and store it in the list
			while (textIn.Peek() != -1)
			{
				string row = textIn.ReadLine() ?? "";
				string[] columns = row.Split(Delimiter);

				if (columns.Length == 5)
				{
					InventoryItem item = null!;
					if (columns[0] == nameof(Plant))
					{
						item = new Plant(Convert.ToInt32(columns[1]),
							columns[2], Convert.ToDecimal(columns[3]),
							columns[4]);
                        
                    }
					else if (columns[0] == nameof(Supply))
					{
                        item = new Supply(Convert.ToInt32(columns[1]),
                            columns[2], Convert.ToDecimal(columns[3]),
                            columns[4]);
                    }

					if (item != null)
                        items.Add(item);
                }
			}

			return items;
		}

		public static void SaveItems(List<InventoryItem> items)
		{
			// create the output stream for a text file that exists
			using StreamWriter textOut =
				new StreamWriter(
				new FileStream(Path, FileMode.Create, FileAccess.Write));

			// write each product
			foreach (InventoryItem item in items)
			{
                textOut.Write(item.GetType().Name + Delimiter);
                if (item is Plant p)
				{
					WriteBase(p, textOut);
					textOut.WriteLine(p.Size);
                }
				else if (item is Supply s)
				{
                    WriteBase(s, textOut);
                    textOut.WriteLine(s.Manufacturer);
                }
			}
		}

		private static void WriteBase(InventoryItem item, StreamWriter textOut)
		{
            textOut.Write(item.ItemNo + Delimiter);
            textOut.Write(item.Description + Delimiter);
            textOut.Write(item.Price + Delimiter);
        }
	}
}