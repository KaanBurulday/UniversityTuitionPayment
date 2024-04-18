using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Svc
{
    public interface IBankAccountService
    {
        public List<BankAccount> getBankAccounts();
        public BankAccount getBankAccountById(int id);
        public int insertBankAccount(BankAccount bankAccount);
        public int updateBankAccount(BankAccount bankAccount);
        public int deleteBankAccounts();
        public int deleteBankAccountById(int id);
    }
}
