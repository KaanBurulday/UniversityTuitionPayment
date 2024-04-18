using Microsoft.AspNetCore.Mvc;
using UniversityTuitionPayment.Model.Dto;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Svc;

namespace UniversityTuitionPayment.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BankAccountController : ControllerBase
    {
        private IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }


        [HttpGet]
        public List<BankAccountDto> Get()
        {
            List<BankAccount> datas = _bankAccountService.getBankAccounts();
            List<BankAccountDto> ret = new List<BankAccountDto>();
            datas.ForEach(data => ret.Add(CreateBankAccountDto(data)));
            return ret;
        }

        [HttpGet("{id}")]
        public BankAccountDto GetBankAccountById(int id)
        {
            BankAccount data = _bankAccountService.getBankAccountById(id);
            return CreateBankAccountDto(data);
        }

        [HttpPost("InsertBankAccount")]
        public BankAccountResultDto InsertBankAccount([FromBody] BankAccountDto bankAccount)
        {
            BankAccountResultDto ret = new BankAccountResultDto();
            if (!ModelState.IsValid)
            {
                ret.Status = "FAILURE";
                ret.Message = "Invalid Model";
                return ret;
            }
            try
            {
                int cnt = _bankAccountService.insertBankAccount(CreateBankAccount(bankAccount));
                if (cnt > 0)
                {
                    ret.Id = _bankAccountService.getBankAccountById(bankAccount.Id).Id;
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
        public int UpdateBankAccount([FromBody] BankAccountDto bankAccount)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Delete")]
        public int DeleteAll()
        {
            return _bankAccountService.deleteBankAccounts();
        }

        [HttpDelete("Delete/{id}")]
        public int Delete(int id)
        {
            return _bankAccountService.deleteBankAccountById(id);
        }

        private BankAccountDto CreateBankAccountDto(BankAccount bankAccount)
        {
            BankAccountDto ret = new BankAccountDto()
            {
                Id = bankAccount.Id,
                AccountCode = bankAccount.AccountCode,
                Balance = bankAccount.Balance,
                TCKimlik = bankAccount.TCKimlik
            };
            return ret;
        }

        private BankAccount CreateBankAccount(BankAccountDto bankAccountDto)
        {
            BankAccount ret = new BankAccount()
            {
                AccountCode = bankAccountDto.AccountCode,
                Balance = bankAccountDto.Balance,
                TCKimlik = bankAccountDto.TCKimlik
            };
            return ret;
        }
    }
}
