using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Svc
{
    public interface IUniversityService
    {
        public List<University> getUniversities();
        public University getUniversityById(int id);
        public int insertUniversity(University university);
        public int updateUniversity(University university);
        public int deleteUniversities();
        public int deleteUniversityById(int id);
    }
}
