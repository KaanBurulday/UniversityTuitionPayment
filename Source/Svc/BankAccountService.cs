using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Db;

namespace UniversityTuitionPayment.Source.Svc
{
    public class BankAccountService : IBankAccountService
    {
        private UniversityTuitionPaymentContext _context;

        public BankAccountService(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public List<BankAccount> getBankAccounts()
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.GetBankAccounts().ToList();
        }

        public BankAccount getBankAccountById(int id)
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.GetBankAccount(id);
        }

        public int insertBankAccount(BankAccount bankAccount)
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.insertBankAccounty(bankAccount);
        }

        public int updateBankAccount(BankAccount bankAccount)
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.updateBankAccount(bankAccount);
        }

        public int deleteBankAccounts()
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.deleteBankAccounts();
        }

        public int deleteBankAccountById(int id)
        {
            BankAccountAccess access = new BankAccountAccess(_context);
            return access.deleteBankAccount(id);
        }
    }
}
