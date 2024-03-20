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
    public class DepertmentController : ControllerBase
    {
        ApiStdContext context = new ApiStdContext();

        [HttpGet]
        public ActionResult GetAll()
        {

            //var stdData = context.Depertments.Include(s => s.Students)
            //             .Select(i => new { i.Name, i.Students }).ToList();

            var deptWStd = context.Depertments
                .Select(i => new DeptWithStd { DepertmentName = i.Name, Students = i.Students
                .Select(s => new StudentDto { Name = s.Name }).ToList() }).ToList();





            return Ok(deptWStd);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var data = context.Depertments.FirstOrDefault(x => x.Id == id);
            if (data == null)
                return NotFound("Invalid Id");

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Add(Depertment depertment)
        {
            if (string.IsNullOrWhiteSpace(depertment.Name))
            {
                return BadRequest("Name cannot be empty");
            }
            else if (ModelState.IsValid)
            {
                context.Depertments.Add(depertment);
                context.SaveChanges();
            }

            return CreatedAtAction(nameof(GetById), new { id = depertment.Id }, depertment);

        }

        [HttpPut("{id}")]
        public IActionResult EditById(int id, Depertment depertment)
        {
            var oldData = context.Depertments.FirstOrDefault(y => y.Id == id);

            if (string.IsNullOrEmpty(depertment.Name))
            {
                return BadRequest("Name cannotbe empty");
            }
            else if (ModelState.IsValid)
            {
                oldData.Name = depertment.Name;
                oldData.MgrName = depertment.MgrName;
                oldData.Location = depertment.Location;

                context.SaveChanges();
            }
            return Ok(oldData);

        }

        [HttpPut]
        public IActionResult EditAll(Depertment depertment)
        {
            if (string.IsNullOrEmpty(depertment.Name))
            {
                return BadRequest("Name cannotbe empty");
            }
            else if (ModelState.IsValid)
            {
                context.Update(depertment);
                context.SaveChanges();
            }
            return Ok(depertment);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var dept = context.Depertments.Find(id);

            if (dept == null)
                NotFound();

            context.Remove(dept);
            context.SaveChanges();

            return Ok(dept);

        }





    }
}
