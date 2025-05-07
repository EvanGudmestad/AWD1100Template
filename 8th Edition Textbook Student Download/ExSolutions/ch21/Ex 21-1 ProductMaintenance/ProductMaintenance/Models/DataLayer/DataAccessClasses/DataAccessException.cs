namespace ProductMaintenance.Models.DataLayer;

public class DataAccessException : Exception
{
    public DataAccessException(string msg, string type) : base(msg) =>
        ErrorType = type;

    public string ErrorType { get; init; }

    public bool IsConcurrencyError =>
        ErrorType.ToLower().Contains("concurrency");

    public bool IsDeleted => Message.ToLower().Contains("deleted");
}
