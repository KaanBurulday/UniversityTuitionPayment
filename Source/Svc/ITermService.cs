using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Svc
{
    public interface ITermService
    {
        public List<Term> getTerms();
        public Term getTermById(int id);
        public int insertTerm(Term term);
        public int updateTerm(Term term);
        public int deleteTerms();
        public int deleteTermById(int id);
    }
}
