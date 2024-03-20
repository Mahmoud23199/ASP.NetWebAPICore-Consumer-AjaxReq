using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskDay1.Entity;
using TaskDay1.Model;

namespace TaskDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ApiStdContext context = new ApiStdContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = context.Students.ToList();

            if (!data.Any() || data is null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var data = context.Students.FirstOrDefault(x => x.Id == id);

            if (data is null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetByName(string name)
        {
            var data = context.Students.Where(x => x.Name == name).ToList();

            if (!data.Any() || data is null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(Student student) 
        {
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                return BadRequest("Name cannot be empty");
            }
            if (ModelState.IsValid) 
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
         
         return CreatedAtAction(nameof(GetById), new {id =student.Id },student);
        
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id,Student student) 
        {
            var oldStd = context.Students.FirstOrDefault(i => i.Id == id);
            if (ModelState.IsValid) 
            {
                oldStd.Name = student.Name;
                oldStd.Address = student.Address;
                oldStd.Age = student.Age;

                context.SaveChanges();

            }

            return Ok(oldStd);

        }
        [HttpPut]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid) 
            {
                context.Update(student);
                context.SaveChanges();

            }
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            var std = context.Students.Find(id);
            if(std == null)
                NotFound();

            context.Remove(std);
            context.SaveChanges();
            return Ok(std);

        }

    }
}
