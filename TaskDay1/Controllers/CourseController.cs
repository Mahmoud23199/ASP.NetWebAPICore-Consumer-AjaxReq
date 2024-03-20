using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskDay1.Dtos;
using TaskDay1.Entity;
using TaskDay1.Model;

namespace TaskDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ApiStdContext context = new ApiStdContext();

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var CoursWStd = context.Courses.Include(c => c.StudentCourses).ThenInclude(s=>s.Student).Where(i=>i.Id==id)
                .Select(c =>new CourseDto { Course=c.Name,studentDtos=c.StudentCourses
                .Select(s=>new StudentDto { Name=s.Student.Name}).ToList() }).ToList();
                


        return Ok (CoursWStd);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var CoursWStd=context.Courses.Include(sc=>sc.StudentCourses).ThenInclude(s=>s.Student)
            //    .Select(sc=>new CourseDto { Course=sc.Name ,studentDtos=
            //    sc.StudentCourses.Select( i=>new StudentDto {Name=i.Student.Name}).ToList() }).ToList();  

            var CoursWStd = context.Courses.Include(c => c.StudentCourses).ThenInclude(s => s.Student)
                .Select(c => new CourseDto
                {
                    Course = c.Name,
                    studentDtos = c.StudentCourses
                .Select(s => new StudentDto { Name = s.Student.Name }).ToList()
                }).ToList();



            return Ok(CoursWStd);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) 
        {
            var course = context.Courses.Find(id);
            if (course == null)
                return NotFound();

            context.Courses.Remove(course);
            context.SaveChanges();

            return Ok(course);
        
        }

        [HttpPost]
        public IActionResult Add(Course course) 
        {
            if (string.IsNullOrEmpty(course.Name)) 
            {
                return BadRequest("Course Name Invalid");
            }
          else if(ModelState.IsValid) 
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return CreatedAtAction(nameof(DeleteById), new { id = course.Id }, course);
             
            
            }
           else
                return BadRequest("Course data Invalid");
        
        }

        [HttpPut("{id}")]
        public IActionResult EditById(int id, Course course)
        {
            var oldData = context.Courses.FirstOrDefault(y => y.Id == id);

            if (oldData == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(course.Name))
            {
                return BadRequest("Name cannot be empty");
            }

            if (ModelState.IsValid)
            {
                oldData.Name = course.Name;
                oldData.Description = course.Description;

                context.SaveChanges();
                return Ok(oldData);
            }

            return BadRequest(ModelState);
        }

    }
}
