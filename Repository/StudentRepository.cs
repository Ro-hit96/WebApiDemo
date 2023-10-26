using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
                this.db = db;
        }
        public int AddStudent(Student student)
        {
            // added the book object in the DBSet
            db.Students.Add(student);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int Roll_No)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Roll_No == Roll_No).FirstOrDefault();
            if (result != null)
            {
                db.Students.Remove(result); // remove from DbSet
                res = db.SaveChanges();
            }
            return res;
        }

        public Student GetStudentByRno(int Roll_No)
        {
            var result = db.Students.Where(x => x.Roll_No == Roll_No).SingleOrDefault();
            return result;
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public int UpdateStudent(Student student)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Roll_No == student.Roll_No).FirstOrDefault();

            if (result != null)
            {
                result.Sname = student.Sname; // book contains new data, result contains old data
                result.City = student.City;
                result.SPercentage = student.SPercentage;

                res = db.SaveChanges();// update those changes in DB
            }
            return res;
        }
    }
}
