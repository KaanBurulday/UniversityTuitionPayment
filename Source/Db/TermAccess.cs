using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Db
{
    public class TermAccess
    {
        private UniversityTuitionPaymentContext _context;

        public TermAccess(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<Term> GetTerms()
        {
            return _context.Terms;
        }

        public Term GetTerm(int id)
        {
            return _context.Terms.FirstOrDefault(u => u.Id == id);
        }

        public int insertTerm(Term term)
        {
            validateTerm(term);
            _context.Terms.Add(term);
            return _context.SaveChanges();
        }

        public int updateTerm(Term term)
        {
            validateTerm(term);
            Term termOld = GetTerm(term.Id);
            if (termOld != null)
            {
                termOld.StartYear = term.StartYear;
                termOld.EndYear = term.EndYear;
                termOld.Semester = term.Semester;
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteTerm(int id)
        {
            Term data = GetTerm(id);
            if (data != null)
            {
                _context.Terms.Remove(data);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteTerms()
        {
            foreach (var entity in _context.Terms)
            {
                _context.Terms.Remove(entity);
            }
            return _context.SaveChanges();
        }

        private void validateTerm(Term term)
        {
            // throw new NotImplementedException();
        }
    }
}
