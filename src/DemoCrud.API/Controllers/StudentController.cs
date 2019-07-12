using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCrud.Repository.Models;
using DemoCrud.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCrud.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet("",Name ="Get")]
        public IActionResult GetStudents()
        {
            return Ok(_service.Get());
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