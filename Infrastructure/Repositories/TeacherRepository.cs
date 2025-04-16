using AFTERCLASS.AMS.API.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFTERCLASS.AMS.API.Infrastructure.Repositories;
using AFTERCLASS.AMS.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AFTERCLAS.AMS.Infrastructure.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDataContext _context;

    public TeacherRepository(ApplicationDataContext context)
    {
        _context = context;
    }

    public IEnumerable<Teacher> GetAll()
    {
        return _context.Teacher.ToList();
    }

    public Teacher GetByEmail(string email)
    {
        var t =  _context.Teacher.FirstOrDefault(t => t.Email == email);
        if(t == null)
        {
            
        }
        return t;
    }

    public Teacher GetById(Guid id)
    {
        return _context.Teacher.Find(id);
    }

    public void Add( Teacher teacher)
    {
        var t = new Teacher()
        {
            Name = teacher.Name,
            Email = teacher.Email,
            Password = teacher.Password
        };
        _context.Teacher.Add(t);
        _context.SaveChanges();
    }

    public void Update(Guid id, Teacher teacher)
    {
        var t = _context.Teacher.Find(id);
        if (t != null)
        {Microsoft.EntityFrameworkCore.DbUpdateException: 'An error occurred while saving the entity changes. See the inner e
            t.Name = teacher.Name;
            t.Email = teacher.Email;
            t.Password = teacher.Password;
            _context.SaveChanges();
        }

    }

    public void DisableTeacher(Guid id)
    {
        var t = _context.Teacher.Find(id);
        if (t != null)
        {
            t.Disabled = true;
            _context.SaveChanges();
        }
    }

   
}
