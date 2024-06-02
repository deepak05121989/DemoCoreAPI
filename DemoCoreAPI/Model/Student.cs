using System.ComponentModel.DataAnnotations;

namespace DemoCoreAPI.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public long Mobile { get; set; }
    }
}
