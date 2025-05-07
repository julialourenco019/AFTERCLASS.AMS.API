using AFTERCLASS.AMS.API.Domain.Entities;

namespace AFTERCLASS.AMS.API.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(Guid id);
        Student GetByEmail(string email);
        void Add(Student student);
        void Update(Guid id, Student student);
        void DisableStudent(Guid id);
        void InableStudent(Guid id);
    }
}
