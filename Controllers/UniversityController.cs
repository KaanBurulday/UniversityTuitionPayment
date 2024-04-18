using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Model.Dto;
using UniversityTuitionPayment.Source.Svc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UniversityController : ControllerBase
    {
        private IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet]
        public List<UniversityDto> Get()
        {
            List<University> datas = _universityService.getUniversities();
            List<UniversityDto> ret = new List<UniversityDto>();
            datas.ForEach(data => ret.Add(createUniversityDto(data)));
            return ret;
        }

        [HttpGet("{id}")]
        public UniversityDto GetUniversityById(int id)
        {
            University data = _universityService.getUniversityById(id);
            return createUniversityDto(data);
        }

        [HttpGet("{id}/StudentsEnrolled")]
        public List<Student> GetStudents(int id)
        {
            University data = _universityService.getUniversityById(id);
            UniversityDto ret = createUniversityDto(data);
            return ret.Students;
        }

        [HttpGet("{id}/Terms")]
        public List<Term> Terms(int id)
        {
            University data = _universityService.getUniversityById(id);
            UniversityDto ret = createUniversityDto(data);
            return ret.Terms;
        }

        [HttpPost("InsertUniversity")]
        public UniversityResultDto InsertUniversity([FromBody] UniversityDto university) 
        {
            UniversityResultDto ret = new UniversityResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                int cnt = _universityService.insertUniversity(createUniversity(university));
                if (cnt > 0)
                {
                    ret.Id = _universityService.getUniversityById(university.Id).Id;
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
        public int UpdateUniversity([FromBody] UniversityDto university)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public int DeleteAll()
        {
            return _universityService.deleteUniversities(); 
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(int id)
        {
            return _universityService.deleteUniversityById(id);
        }

        private UniversityDto createUniversityDto(University university)
        {
            UniversityDto ret = new UniversityDto()
            {
                Id = university.Id,
                UniversityCode = university.UniversityCode,
                UniversityName = university.UniversityName,
                TuitionFee = university.TuitionFee,
                Students = university.Students,
                CurrentTerm = university.CurrentTerm,
                Terms = university.Terms
            };
            return ret;
        }

        private University createUniversity(UniversityDto universityDto)
        {
            University ret = new University()
            {
                UniversityCode = universityDto.UniversityCode,
                UniversityName = universityDto.UniversityName,
                TuitionFee = universityDto.TuitionFee,
                Students = universityDto.Students,
                CurrentTerm = universityDto.CurrentTerm,
                Terms = universityDto.Terms
            };
            return ret;
        }
    }
}