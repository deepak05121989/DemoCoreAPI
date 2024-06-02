using DemoCoreAPI.Model;

namespace DemoCoreAPI.Service
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        int SaveStudent(Student student);
        int UpdateStudent(int id, Student student);
        int DeleteStudent(int id);
    }
}
