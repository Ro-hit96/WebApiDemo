using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddEmployee(Employee employee)
        {
            // added the book object in the DBSet
            db.employees.Add(employee);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int res = 0;
            var result = db.employees.Where(x => x.id == id).FirstOrDefault();
            if (result != null)
            {
                db.employees.Remove(result); // remove from DbSet
                res = db.SaveChanges();
            }
            return res;
        }

        public Employee GetEmployeeById(int id)
        {
            var result = db.employees.Where(x => x.id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return db.employees.ToList();
        }

        public int UpdateEmployee(Employee employee)
        {
            int res = 0;
            var result = db.employees.Where(x => x.id == employee.id).FirstOrDefault();

            if (result != null)
            {
                result.name = employee.name; // book contains new data, result contains old data
                result.email = employee.email;
                result.age = employee.age;
                result.salary = employee.salary;

                res = db.SaveChanges();// update those changes in DB
            }
            return res;
        }
    }
}
