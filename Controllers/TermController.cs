using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model.Dto;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Svc;
using static UniversityTuitionPayment.Model.Term;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TermController : ControllerBase
    {
        private ITermService _termService;

        public TermController(ITermService termService)
        {
            _termService = termService;
        }

        [HttpGet]
        public List<TermDto> Get()
        {
            List<Term> datas = _termService.getTerms();
            List<TermDto> ret = new List<TermDto>();
            datas.ForEach(data => ret.Add(createTermDto(data)));
            return ret;
        }

        [HttpGet("{id}")]
        public TermDto GetTermById(int id)
        {
            Term data = _termService.getTermById(id);
            return createTermDto(data);
        }

        [HttpPost("InsertTerm")]
        public TermResultDto InsertTerm([FromBody] TermDto term)
        {
            TermResultDto ret = new TermResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                int cnt = _termService.insertTerm(createTerm(term));
                if (cnt > 0)
                {
                    ret.Id = _termService.getTermById(term.Id).Id;
                }
            }
            catch (Exception ex)
            {
                ret.Status = "FAILURE";
                ret.Message = ex.StackTrace;
            }
            return ret;
        }

        [HttpPut("{id}")]
        public int UpdateTerm([FromBody] TermDto term)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public int DeleteAll()
        {
            return _termService.deleteTerms();
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(int id)
        {
            return _termService.deleteTermById(id);
        }

        private TermDto createTermDto(Term term)
        {
            TermDto ret = new TermDto()
            {
                Id = term.Id,
                StartYear = term.StartYear,
                EndYear = term.EndYear,
                Semester = term.Semester
            };
            return ret;
        }

        private Term createTerm(TermDto termDto)
        {
            Term ret = new Term()
            {
                StartYear = termDto.StartYear,
                EndYear = termDto.EndYear,
                Semester = termDto.Semester
            };
            return ret;
        }
    }
}
