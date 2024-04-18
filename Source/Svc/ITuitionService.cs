using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Svc
{
    public interface ITuitionService
    {
        public List<Tuition> getTuitions();
        public Tuition getTuitionById(int id);
        public int insertTuition(Tuition tuition);
        public int updateTuition(Tuition tuition);
        public int deleteTuitions();
        public int deleteTuitionById(int id);
    }
}
