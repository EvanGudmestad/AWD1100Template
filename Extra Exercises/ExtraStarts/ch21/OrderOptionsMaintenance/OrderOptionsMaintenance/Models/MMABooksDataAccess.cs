namespace OrderOptionsMaintenance.Models
{
    public class MMABooksDataAccess
    {
        public OrderOption GetOrderOptions()
        {
            throw new NotImplementedException();
        }

        public void SaveOrderOptions(OrderOption options)
        {

        }
    }

    public class DataAccessException : Exception
    {
        public DataAccessException(string msg, string errorType) : base(msg) =>
            ErrorType = errorType;

        public string ErrorType { get; init; }
    }
}
