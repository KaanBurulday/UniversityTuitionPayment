using Microsoft.EntityFrameworkCore;
using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Db
{
    public class UniversityAccess
    {
        private UniversityTuitionPaymentContext _context;
        
        public UniversityAccess(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<University> GetUniversities()
        {
            return _context.Universities;
        }

        public University GetUniversity(int id)
        {
            return _context.Universities.FirstOrDefault(u => u.Id == id);
        }

        public int insertUniversity(University university)
        {
            validateUniversity(university);
            _context.Universities.Add(university);
            return _context.SaveChanges();
        }

        public int updateUniversity(University university)
        {
            validateUniversity(university);
            University universityOld = GetUniversity(university.Id);
            if (universityOld != null)
            {
                universityOld.UniversityName = university.UniversityName;   
                universityOld.Students = university.Students;
                universityOld.TuitionFee = university.TuitionFee;
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteUniversity(int id)
        {
            University data = GetUniversity(id);
            if(data != null)
            {
                _context.Universities.Remove(data);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteUniversities()
        {
            foreach (var entity in _context.Universities)
            {
                _context.Universities.Remove(entity);
            }
            return _context.SaveChanges();   
        }

        private void validateUniversity(University university)
        {
            // throw new NotImplementedException();
        }
    }
}
