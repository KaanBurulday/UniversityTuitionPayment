using Microsoft.Identity.Client;
using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Db;

namespace UniversityTuitionPayment.Source.Svc
{
    public class UniversityService : IUniversityService
    {
        private UniversityTuitionPaymentContext _context;

        public UniversityService(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public List<University> getUniversities()
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.GetUniversities().ToList();
        }

        public University getUniversityById(int id)
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.GetUniversity(id);
        }

        public int insertUniversity(University university)
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.insertUniversity(university);
        }

        public int updateUniversity(University university)
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.updateUniversity(university);
        }

        public int deleteUniversities()
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.deleteUniversities();
        }

        public int deleteUniversityById(int id)
        {
            UniversityAccess access = new UniversityAccess(_context);
            return access.deleteUniversity(id);
        }
    }
}
