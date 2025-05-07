namespace ProductMaintenance
{
    public class Software : Product
    {
        public Software() { }

        public Software(string code, string description, decimal price,
            string version) : base(code, description, price) => Version = version;

        public string Version { get; set; } = "";

        public override string GetDisplayText(string sep) =>
            $"{base.GetDisplayText(sep)}, Version {Version}";
    }
}
