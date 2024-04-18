using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model.Dto;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Svc;
using static UniversityTuitionPayment.Model.Student;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public List<StudentDto> Get()
        {
            List<Student> datas = _studentService.getStudents();
            List<StudentDto> ret = new List<StudentDto>();
            datas.ForEach(data => ret.Add(createStudentDto(data)));
            return ret;
        }

        [HttpGet("{id}")]
        public StudentDto GetStudentById(int id)
        {
            Student data = _studentService.getStudentById(id);
            return createStudentDto(data);
        }

        [HttpPost("InsertStudent")]
        public StudentResultDto InsertStudent([FromBody] StudentDto student)
        {
            StudentResultDto ret = new StudentResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                int cnt = _studentService.insertStudent(createStudent(student));
                if (cnt > 0)
                {
                    ret.Id = _studentService.getStudentById(student.Id).Id;
                }
            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.Message;
            }
            return ret;
        }

        [HttpPut("{id}")]
        public int UpdateStudent([FromBody] StudentDto student)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public int DeleteAll()
        {
            return _studentService.deleteStudents();
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(int id)
        {
            return _studentService.deleteStudentById(id);
        }

        private StudentDto createStudentDto(Student student)
        {
            StudentDto ret = new StudentDto()
            {
                Id = student.Id,
                StudentCode = student.StudentCode,
                TCKimlik = student.TCKimlik,
                FullName = student.FullName,
                universityId = student.universityId,
                StudentStatus = student.StudentStatus
            };
            return ret;
        }

        private Student createStudent(StudentDto studentDto)
        {
            Student ret = new Student()
            {
                StudentCode = studentDto.StudentCode,
                TCKimlik = studentDto.TCKimlik,
                FullName = studentDto.FullName,
                universityId = studentDto.universityId,
                StudentStatus = studentDto.StudentStatus
            };
            return ret;
        }
    }
}