namespace TaskDay1.Dtos
{
    public class DeptWithStd
    {
        public string DepertmentName { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();


    }
}
