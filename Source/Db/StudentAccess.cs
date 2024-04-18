using UniversityTuitionPayment.Context;
using UniversityTuitionPayment.Model;

namespace UniversityTuitionPayment.Source.Db
{
    public class StudentAccess
    {
        private UniversityTuitionPaymentContext _context;

        public StudentAccess(UniversityTuitionPaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(u => u.Id == id);
        }

        public int insertStudent(Student student)
        {
            validateStudent(student);
            _context.Students.Add(student);
            return _context.SaveChanges();
        }

        public int updateStudent(Student student)
        {
            validateStudent(student);
            Student studentOld = GetStudent(student.Id);
            if (studentOld != null)
            {
                studentOld.StudentCode = student.StudentCode;
                studentOld.TCKimlik = student.TCKimlik;
                studentOld.FullName = student.FullName;
                studentOld.universityId = student.universityId;
                studentOld.StudentStatus = student.StudentStatus;
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteStudent(int id)
        {
            Student data = GetStudent(id);
            if (data != null)
            {
                _context.Students.Remove(data);
                return _context.SaveChanges();
            }
            return 0;
        }

        public int deleteStudents()
        {
            foreach (var entity in _context.Students)
            {
                _context.Students.Remove(entity);
            }
            return _context.SaveChanges();
        }

        private void validateStudent(Student student)
        {
            // throw new NotImplementedException();
        }
    }
}
