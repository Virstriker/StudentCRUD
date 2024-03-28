using CRUDWebApplication.Models;
using CRUDWebApplication.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var studList = _studentRepository.GetAllStudent();
            return Ok(studList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudent([FromRoute]int id)
        {

            var stud = _studentRepository.GetStudent(id);
            if  (stud != null) 
            {
                   return Ok(stud);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {

            int isAdded = _studentRepository.AddStudent(student);

            if (isAdded == 1)
            {
                return Ok("Record Added succesfully...!");
            }
            return BadRequest("something went to wrong...!");
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent([FromRoute]int id,[FromBody]Student student)
        {
            var isUpdate = _studentRepository.UpdateStudent(id,student);
            if(isUpdate == 1)
            {
                return Ok("Record updated succesfully...!");
            }
            return NotFound("Record not found");
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent([FromRoute]int id)
        {
            var isdeleted = _studentRepository.DeleteStudent(id);
            if(isdeleted == 1)
            {
                return Ok("Record deleted succesfully...!");
            }
            return NotFound("Record not found");
        }

        [HttpPatch("{id:int}")]
        public IActionResult UpdateStudentPatch([FromRoute]int id, [FromBody]StudentPatchModel student)
        {
            var isUpdate = _studentRepository.UpdateStudentPatch(id, student);
            if (isUpdate == 1)
            {
                return Ok("Record updated succesfully...!");
            }
            return NotFound("Record not found");
        }
    }
}
