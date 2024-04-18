using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Db
{
    public class TuitionAccess
    {
        private UniversityTuitionPaymentContext _context;

        public TuitionAccess(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<Tuition> GetTuitions()
        {
            return _context.Tuitions;
        }

        public Tuition GetTuition(int id)
        {
            return _context.Tuitions.FirstOrDefault(u => u.Id == id);
        }

        public int insertTuitions(Tuition tuition)
        {
            validateTuition(tuition);
            _context.Tuitions.Add(tuition);
            return _context.SaveChanges();
        }

        public int updateTuition(Tuition tuition)
        {
            validateTuition(tuition);
            Tuition tuitionOld = GetTuition(tuition.Id);
            if (tuitionOld != null)
            {
                tuitionOld.currentTermId = tuition.currentTermId;
                tuitionOld.studentId = tuition.studentId;
                tuitionOld.universityId = tuition.universityId;
                tuitionOld.TuitionTotal = tuition.TuitionTotal;
                tuitionOld.TuitionPaid = tuition.TuitionPaid;
                tuitionOld.LastPaymentDate = tuition.LastPaymentDate;
                tuitionOld.PaymentStatus = tuition.PaymentStatus;
                return _context.SaveChanges();
            } 
            return 0;
        }

        public int deleteTuition(int id)
        {
            Tuition data = GetTuition(id);
            if (data != null)
            {
                _context.Tuitions.Remove(data);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteTuitions()
        {
            foreach (var entity in _context.Tuitions)
            {
                _context.Tuitions.Remove(entity);
            }
            return _context.SaveChanges();
        }

        private void validateTuition(Tuition tuition)
        {
            // throw new NotImplementedException();
        }
    }
}
