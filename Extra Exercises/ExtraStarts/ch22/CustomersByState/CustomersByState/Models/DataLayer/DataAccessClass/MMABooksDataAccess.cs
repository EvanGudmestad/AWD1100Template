using Microsoft.EntityFrameworkCore;

namespace CustomersByState.Models.DataLayer
{
    public record StateDTO(string StateCode, string StateName);
    public record CustomerDTO(string Name, string Address, string City, string ZipCode);

    public class MMABooksDataAccess
    {
        private MMABooksContext context = new();

        public int StateCount => context.States.Count();

        public List<StateDTO> GetStates()
        {
            return context.States
                    .OrderBy(s => s.StateName)
                    .Select(s => new StateDTO(s.StateCode, s.StateName))
                    .ToList();
        }

        public List<StateDTO> GetStates(int skip, int take)
        {
            return context.States
                    .OrderBy(s => s.StateName)
                    .Select(s => new StateDTO(s.StateCode, s.StateName))
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }

        public List<CustomerDTO> GetCustomers(string stateCode)
        {
            return context.Customers
                    .Where(c => c.State == stateCode)
                    .OrderBy(c => c.Name)
                    .Select(c => new CustomerDTO(c.Name, c.Address, c.City, c.ZipCode))
                    .ToList();
        }

        public State GetState(string code)
        {
            return context.States.Find(code)!;
        }

        public void AddState(State state)
        {
            try
            {
                context.States.Add(state);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw GetDataAccessException(ex, "Insert Failed");
            }
        }

        public void UpdateState(State state)
        {
            try
            {
                context.States.Update(state);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw GetDataAccessException(ex, "Update Failed");
            }
        }

        public void RemoveState(State state)
        {
            try
            {
                context.States.Remove(state);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw GetDataAccessException(ex, "Delete Failed");
            }
        }

        public DataAccessException GetDataAccessException(DbUpdateException ex, string type)
        {
            string msg = ex.InnerException?.Message ?? ex.Message;
            return new DataAccessException(msg, type);
        }
    }

    public class DataAccessException : Exception
    {
        public DataAccessException(string msg, string errorType) : base(msg) =>
            ErrorType = errorType;

        public string ErrorType { get; init; }
    }
}
