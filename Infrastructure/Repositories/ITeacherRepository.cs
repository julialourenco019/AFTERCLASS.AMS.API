using AFTERCLASS.AMS.API.Domain.Entities;

namespace AFTERCLASS.AMS.API.Infrastructure.Repositories;


public interface ITeacherRepository
{
    IEnumerable<Teacher> GetAll();
    Teacher GetById(Guid id);
    Teacher GetByEmail(string email);
    void Add(Teacher teacher);
    void Update(Guid id, Teacher teacher);
    void DisableTeacher(Guid id);
}
