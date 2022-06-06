
namespace TestNinja.Mocking
{

    public interface IEmployeeService
    {
        void DeleteEmployee(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _db;

        public EmployeeService()
        {
            _db = new EmployeeContext();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Find(id);

            if (employee == null) return;

            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
