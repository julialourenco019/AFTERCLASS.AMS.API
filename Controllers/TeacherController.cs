using Microsoft.AspNetCore.Mvc;
using AFTERCLASS.AMS.API.Application.DTOs;
using AFTERCLASS.AMS.API.Domain.Entities;
using AFTERCLASS.AMS.API.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace AFTERCLASS.AMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _repository;

    public TeacherController(ITeacherRepository repository)
    {
        _repository = repository;
    }

    [Authorize]
    [HttpGet]
    [Route("api/v1/Teacher/all")]
    public IActionResult GetAll()
    {
        var t = _repository.GetAll();
        return Ok(t);
    }
    [Authorize]
    [HttpGet]
    [Route("{id:Guid}")]
   

    public IActionResult GetById(Guid id)
    {
        var t = _repository.GetById(id);
        if (t == null)
        {
            return NotFound();
        }
        return Ok(t);
    }
    [Authorize]
    [HttpGet]
    [Route("api/v1/Teacher/email{email}")]
    public IActionResult GetByEmail(string email)
    {
        var t = _repository.GetByEmail(email);
        return Ok(t);
    }

    [Authorize]
    [HttpPost]
    public IActionResult Post(Teacher teacher)
    {
        _repository.Add(teacher);
        return Ok(teacher);
    }

    [Authorize]
    [HttpPut]
    [Route("{id:Guid}")]
    public IActionResult Update(Guid id, Teacher teacher)
    {
        _repository.Update(id, teacher);
        return Ok();
    }

    [Authorize]
    [HttpPatch]
    [Route("api/v1/Teacher/disable{id:Guid}")]
    
    public IActionResult Disable(Guid id)
    {
        _repository.DisableTeacher(id);
        return Ok();
    }
}
