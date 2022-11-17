using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Model;
using Student.Repo;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacher;
        public TeacherController(ITeacherService teacher)
        {
            this.teacher = teacher;
        }
        [HttpGet("GetTeacher")]
        public IActionResult GetTeacher()
        {
            try
            {
                var rest=teacher.GetTeachers();
                return Ok(rest);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PostTeacher")]
        public IActionResult PostTeacher(TeacherClass teachers)
        {
            try
            {
                teacher.postData(teachers);
                return Ok("Data Added SuccesFully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
