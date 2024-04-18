using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Svc
{
    public interface IStudentService
    {
        public List<Student> getStudents();
        public Student getStudentById(int id);
        public int insertStudent(Student student);
        public int updateStudent(Student student);
        public int deleteStudents();
        public int deleteStudentById(int id);
    }
}
