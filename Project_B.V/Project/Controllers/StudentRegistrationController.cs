using Microsoft.AspNetCore.Mvc;
using Project.DB.Entities;
using Project.DTOs;
using Project.Repositories;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly IStudentRegistrationRepository _studentRegistrationRepository;

        public StudentRegistrationController(IStudentRegistrationRepository studentRegistrationRepository)
        {
            _studentRegistrationRepository = studentRegistrationRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent([FromQuery] StudentDto student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _studentRegistrationRepository.RegisterStudent(student);
                return Ok(result);
            }
           catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred."); 
            }
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _studentRegistrationRepository.GetStudentById(Id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudens()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _studentRegistrationRepository.GetStudents();
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromQuery] UpdateStudentDto updateStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _studentRegistrationRepository.UpdateStudent(updateStudent);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Student Not Found!");
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudentById(int Id)
        {
            try
            {
                var deletedStudent = await _studentRegistrationRepository.DeleteStudentById(Id);

                return Ok(deletedStudent); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred." });
            }
        }

    }
}
