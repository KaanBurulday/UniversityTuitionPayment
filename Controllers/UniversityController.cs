using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class UniversityController : ControllerBase
    {
        

        [HttpGet(Name="GetAll")]
        public List<University> GetAll()
        {
            return null;   
        }

        [HttpGet("Get/{id}")]
        public University GetUniversityById(Guid id)
        {
            return null;
        }

        [HttpGet(Name = "StudentsEnrolled")]
        public List<Student> GetStudents()
        {
            return null;
        }

        [HttpGet(Name = "Terms")]
        public List<Student> Terms()
        {
            return null;
        }

        [HttpPost("Post")]
        public University CreateUniversity([FromBody] string values) 
        {
            return null;
        }


        [HttpPut("Put/{id}")]
        public int UpdateUniversity(Guid id, [FromBody] string value)
        {
            return -1;
        }



        [HttpDelete(Name = "DeleteAll")]
        public int DeleteAll()
        {
            return -1;
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(Guid id)
        {
            return -1;
        }
    }
}
