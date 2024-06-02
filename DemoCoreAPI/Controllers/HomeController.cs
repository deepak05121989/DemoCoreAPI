using DemoCoreAPI.Model;
using DemoCoreAPI.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.GetStudents();
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _studentService.GetStudentById(id);
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post(Student student)
        {
            _studentService.SaveStudent(student);


        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, Student student)
        {
            _studentService.UpdateStudent(id,student);
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
