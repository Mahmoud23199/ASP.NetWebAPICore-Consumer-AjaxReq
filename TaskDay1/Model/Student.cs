using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TaskDay1.Model;

namespace TaskDay1
{
    public class Student
    {
        public int Id { get; set; }

        [RegularExpression("^(?=.*[a-zA-Z])[a-zA-Z ]{3,50}$")]
        public string Name { get; set; }

        [Range(20,60)]
        public int Age { get; set; }
        public string? Image { get; set; }

        [RegularExpression("^(cairo|alx|port|giza)$")]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        public Depertment? Department { get; set; }

        [JsonIgnore]
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
