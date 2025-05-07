namespace ProductMaintenance
{
	public record Product(string Code, string Description, decimal Price)
	{
		public string GetDisplayText() => GetDisplayText(", ");

		public string GetDisplayText(string sep) =>
			$"{Code}{sep}{Price.ToString("c")}{sep}{Description}";
	}

}