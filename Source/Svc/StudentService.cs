using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;
using UniversityTuitionPayment.Source.Db;

namespace UniversityTuitionPayment.Source.Svc
{
    public class StudentService : IStudentService
    {
        private UniversityTuitionPaymentContext _context;

        public StudentService(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public List<Student> getStudents()
        {
            StudentAccess access = new StudentAccess(_context);
            return access.GetStudents().ToList();
        }

        public Student getStudentById(int id)
        {
            StudentAccess access = new StudentAccess(_context);
            return access.GetStudent(id);
        }

        public int insertStudent(Student student)
        {
            StudentAccess access = new StudentAccess(_context);
            return access.insertStudent(student);
        }

        public int updateStudent(Student student)
        {
            StudentAccess access = new StudentAccess(_context);
            return access.updateStudent(student);
        }

        public int deleteStudents()
        {
            StudentAccess access = new StudentAccess(_context);
            return access.deleteStudents();
        }

        public int deleteStudentById(int id)
        {
            StudentAccess access = new StudentAccess(_context);
            return access.deleteStudent(id);
        }
    }
}
