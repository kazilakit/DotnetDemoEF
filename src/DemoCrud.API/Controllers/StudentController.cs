using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCrud.Repository.Models;
using DemoCrud.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoCrud.API.Controllers
{
    [Route("api/students")]
    //[ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger, IStudentService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("",Name ="Get")]
        public IActionResult GetStudents()
        {
            var data = _service.Get();
            if(data==null || data.Count()==0)
            {
                _logger.LogInformation("GetStudents() : No data ");
                return StatusCode(204, "No data found");
            }
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(long id)
        {
            return Ok(_service.Get(id));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(long id)
        {
            _service.Delete(id);
            return StatusCode(204,"Deleted");
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _service.Insert(student);
            return CreatedAtRoute("Get", new { Id = student.Id }, student);
        }
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            _service.Update(student);
            return Ok(student);
        }
    }
}