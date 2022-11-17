using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Model;
using Student.Repo;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService reg;
        public RegisterController(IRegisterService reg)
        {
            this.reg = reg;
        }
        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var res = reg.GetRegister();
            return Ok(res);
        }
        [HttpPost("AddData")]
        public IActionResult AddData(RegisterClass register)
        {
            reg.Register(register);
            return Ok("Data added successfully");
        }
        [HttpDelete("DeleteData")]
        public IActionResult Delete(int id)
        {
           var rest= reg.Unregister(id);
            return Ok("Data deleted successfully"+ rest);
        }
        [HttpPost("UpdateData")]
        public IActionResult Update(RegisterClass register)
        {
            reg.UpdateData(register);
            return Ok("Data updated successfully");
        }
        [HttpGet("GetDataList")]
        public IActionResult GetDataList()
        {
            var res = reg.GetRegisteredList();
            return Ok(res);
        }

        [HttpGet("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var res = reg.GetStudentById(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
    }
}
