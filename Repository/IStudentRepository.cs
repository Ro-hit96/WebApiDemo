using WebApiDemo.Models;

namespace WebApiDemo.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentByRno(int Roll_No);
        int AddStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int Roll_No);
    }
}
