using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Db;

namespace UniversityTuitionPayment.Source.Svc
{
    public class TermService : ITermService
    {
        private UniversityTuitionPaymentContext _context;

        public TermService(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public List<Term> getTerms()
        {
            TermAccess access = new TermAccess(_context);
            return access.GetTerms().ToList();
        }

        public Term getTermById(int id)
        {
            TermAccess access = new TermAccess(_context);
            return access.GetTerm(id);
        }

        public int insertTerm(Term term)
        {
            TermAccess access = new TermAccess(_context);
            return access.insertTerm(term);
        }

        public int updateTerm(Term term)
        {
            TermAccess access = new TermAccess(_context);
            return access.updateTerm(term);
        }

        public int deleteTerms()
        {
            TermAccess access = new TermAccess(_context);
            return access.deleteTerms();
        }

        public int deleteTermById(int id)
        {
            TermAccess access = new TermAccess(_context);
            return access.deleteTerm(id);
        }
    }
}
