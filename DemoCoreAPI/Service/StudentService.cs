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

        public int DeleteStudent(int id)
        {
            return _studentsRepository.DeleteStudent(id);
        }

        public Student GetStudentById(int id)
        {
           return _studentsRepository.GetStudentById(id);
        }

        public List<Student> GetStudents()
        {
          return  _studentsRepository.GetStudents();
        }

        public int SaveStudent(Student student)
        {
            return _studentsRepository.SaveStudent(student);
        }

        public int UpdateStudent(int id, Student student)
        {
            return _studentsRepository.UpdateStudent(id, student);
        }
    }
}
