using DemoCoreAPI.Model;

namespace DemoCoreAPI.Repository
{
    public interface IStudentsRepository
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        int SaveStudent(Student student);
        int UpdateStudent(int id, Student student);
        int DeleteStudent(int id);
    }
}
