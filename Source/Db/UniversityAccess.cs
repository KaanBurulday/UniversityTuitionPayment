using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Db
{
    public class UniversityAccess
    {
        private static List<University> sampleUniversities = new List<University>(new University[]
        {
            new University() { UniversityName="University 1", Students = new List<Student>(), TuitionFee = 30000 },
            new University() { UniversityName="University 2", Students = new List<Student>(), TuitionFee = 20000 },
            new University() { UniversityName="University 3", Students = new List<Student>(), TuitionFee = 15000 }
        });

        public List<University> GetUniversities()
        {
            return sampleUniversities;
        }

        public University GetUniversityById(Guid id)
        {
            return sampleUniversities.Find(u => u.Id == id);
        }

        public List<Student> GetStudentsOfUniversityById(Guid id)
        {
            return GetUniversityById(id).Students;
        }

        public void insertUniversity(University university)
        {
            validateUniversity(university);
            sampleUniversities.Add(university);
        }

        public void updateUniversity(University university)
        {
            validateUniversity(university);
            University universityOld = GetUniversityById(university.Id);
            if (universityOld != null)
            {
                universityOld.UniversityName = university.UniversityName;   
                universityOld.Students = university.Students;
                universityOld.TuitionFee = university.TuitionFee;
            }
        }

        public void updateUniversityTuitionFee(University university)
        {
            validateUniversity(university);
            University universityOld = GetUniversityById(university.Id);
            if (universityOld != null)
            {
                universityOld.TuitionFee = university.TuitionFee;
            }
        }

        public int deleteCourse(Guid id)
        {
            return sampleUniversities.RemoveAll(u => u.Id == id);
        }

        private void validateUniversity(University university)
        {
            throw new NotImplementedException();
        }
    }
}
