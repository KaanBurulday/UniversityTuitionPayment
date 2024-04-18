using Microsoft.AspNetCore.Mvc;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Midterm : ControllerBase
    {

        /* Parameters: Student No
         * Response: Tuition Total, Balance
         * Description: Returns tuition amount and current balance
         */
        [HttpGet("QueryTuition")]
        public void QueryTuition() 
        {
            throw new NotImplementedException();
        }

        /* Parameters: Student No, Term
         * Response: Transaction status
         * Description: Adds a tuition amount for given student term 
         */
        [HttpPost("PayTuition")]
        public void PayTuition()
        {
            throw new NotImplementedException();
        }

        /* Parameters: Student No, Term
         * Response: Transaction status
         * Description: Adds a tuition amount for given student term 
         */
        [HttpPost("AddTuition")]
        public void AddTuition()
        {
            throw new NotImplementedException();
        }

        /* Parameters: Term
         * Response: List of students with unpaid tuition amounts
         * Description 
         */
        [HttpGet("UnpaidTuitionStatus")]
        public void UnpaidTuitionStatus() 
        {
            throw new NotImplementedException();
        }

    }
}
