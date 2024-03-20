using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskDay1.Model
{
    public class Course
    {
        public int Id { get; set; }


        [RegularExpression("^(?=.*[a-zA-Z])[a-zA-Z ]{3,50}$")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<StudentCourse>? StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
