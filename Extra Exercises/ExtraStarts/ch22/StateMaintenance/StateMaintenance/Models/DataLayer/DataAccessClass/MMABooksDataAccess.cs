using Microsoft.EntityFrameworkCore;

namespace StateMaintenance.Models.DataLayer
{
    public record StateDTO(string StateCode, string StateName);

    public class MMABooksDataAccess
    {
        private MMABooksContext context = new();

        public List<StateDTO> GetStates()
        {
            return context.States
                    .OrderBy(s => s.StateName)
                    .Select(s => new StateDTO(s.StateCode, s.StateName))
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
