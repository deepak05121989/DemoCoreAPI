using DemoCoreAPI.Model;
using DemoCoreAPI.Repository;
using System.Data.SqlClient;

namespace DemoCoreAPI.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentService(IStudentsRepository studentsRepository) 
        {
           _studentsRepository= studentsRepository;
        }
        public List<Student> GetStudents()
        {
          return  _studentsRepository.GetStudents();
        }
    }
}
