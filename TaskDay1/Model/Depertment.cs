using System.ComponentModel.DataAnnotations;

namespace TaskDay1.Model
{
    public class Depertment
    {
        public int Id { get; set; }

        [RegularExpression("^(?=.*[a-zA-Z])[a-zA-Z ]{3,50}$")]
        public string Name { get; set; }

        [RegularExpression("^(cairo|alx|port|giza)$")]
        public string Location { get; set; }

        [RegularExpression("^(?=.*[a-zA-Z])[a-zA-Z ]{3,50}$")]
        public string MgrName { get; set; }

        public ICollection<Student> ?Students { get; set; } = new List<Student>();
    }
}
