using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model.Dto;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Svc;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class TuitionController : ControllerBase
    {
        private ITuitionService _tuitionService;

        public TuitionController(ITuitionService tuitionService)
        {
            _tuitionService = tuitionService;
        }

        [HttpGet]
        public List<TuitionDto> Get()
        {
            List<Tuition> datas = _tuitionService.getTuitions();
            List<TuitionDto> ret = new List<TuitionDto>();
            datas.ForEach(data => ret.Add(createTuitionDto(data)));
            return ret;
        }

        [HttpGet("{id}")]
        public TuitionDto GetTuitionById(int id)
        {
            Tuition data = _tuitionService.getTuitionById(id);
            return createTuitionDto(data);
        }

        [HttpPost("InsertTuition")]
        public TuitionResultDto InsertTuition([FromBody] TuitionDto tuition)
        {
            TuitionResultDto ret = new TuitionResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                int cnt = _tuitionService.insertTuition(createTuition(tuition));
                if (cnt > 0)
                {
                    ret.Id = _tuitionService.getTuitionById(tuition.Id).Id;
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
        public int UpdateTuition([FromBody] TuitionDto tuition)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public int DeleteAll()
        {
            return _tuitionService.deleteTuitions();
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(int id)
        {
            return _tuitionService.deleteTuitionById(id);
        }

        private TuitionDto createTuitionDto(Tuition tuition)
        {
            TuitionDto ret = new TuitionDto()
            {
                Id = tuition.Id,
                currentTermId = tuition.currentTermId,
                studentId = tuition.studentId,
                universityId = tuition.universityId,
                TuitionTotal = tuition.TuitionTotal,
                TuitionPaid = tuition.TuitionPaid,
                LastPaymentDate = tuition.LastPaymentDate,
                PaymentStatus = tuition.PaymentStatus
            };
            return ret;
        }

        private Tuition createTuition(TuitionDto tuitionDto)
        {
            Tuition ret = new Tuition()
            {
                currentTermId = tuitionDto.currentTermId,
                studentId = tuitionDto.studentId,
                universityId = tuitionDto.universityId,
                TuitionTotal = tuitionDto.TuitionTotal,
                TuitionPaid = tuitionDto.TuitionPaid,
                LastPaymentDate = tuitionDto.LastPaymentDate,
                PaymentStatus = tuitionDto.PaymentStatus
            };
            return ret;
        }
    }
}