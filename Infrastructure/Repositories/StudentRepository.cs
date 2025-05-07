using AFTERCLASS.AMS.API.Domain.Entities;
using AFTERCLASS.AMS.API.Infrastructure.Data;

namespace AFTERCLASS.AMS.API.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDataContext _context;
        public StudentRepository( ApplicationDataContext context)
        {
            _context = context;
        }
        public void Add(Student student)
        {
            var t = _context.Teacher.FirstOrDefault();
            var s = new Student()
            {
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                
            };
            _context.Student.Add(s);
            _context.SaveChanges();

        }

        public void DisableStudent(Guid id)
        {
            var s = _context.Student.Find(id);

            if (s != null)
            {
                s.IsActive = false;
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Student.ToList();
        }

        public Student GetByEmail(string email)
        {
            var s = _context.Student.FirstOrDefault(t => t.Email == email);
            if (s == null)
            {

            }
            return s;
        }

        public Student GetById(Guid id)
        {
            return _context.Student.Find(id);
        }

        public void InableStudent(Guid id)
        {
            var s = _context.Student.Find(id);
            if (s != null)
            {
               s.IsActive = true;
                _context.SaveChanges();
            }
        }

        public void Update(Guid id, Student student)
        {
            var s = _context.Student.Find(id);
            if (s != null)
            {
                s.Name = student.Name;
                s.Email = student.Email;
                s.Password = student.Password;
                _context.SaveChanges();
            }
        }
    }
}
