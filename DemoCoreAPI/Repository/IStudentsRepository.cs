using DemoCoreAPI.Model;

namespace DemoCoreAPI.Repository
{
    public interface IStudentsRepository
    {
        List<Student> GetStudents();
    }
}
