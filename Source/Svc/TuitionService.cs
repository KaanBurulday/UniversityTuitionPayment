using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Db;

namespace UniversityTuitionPayment.Source.Svc
{
    public class TuitionService : ITuitionService
    {
        private UniversityTuitionPaymentContext _context;

        public TuitionService(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public List<Tuition> getTuitions()
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.GetTuitions().ToList();
        }

        public Tuition getTuitionById(int id)
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.GetTuition(id);
        }

        public int insertTuition(Tuition tuition)
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.insertTuitions(tuition);
        }

        public int updateTuition(Tuition tuition)
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.updateTuition(tuition);
        }

        public int deleteTuitions()
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.deleteTuitions();
        }

        public int deleteTuitionById(int id)
        {
            TuitionAccess access = new TuitionAccess(_context);
            return access.deleteTuition(id);
        }
    }
}
