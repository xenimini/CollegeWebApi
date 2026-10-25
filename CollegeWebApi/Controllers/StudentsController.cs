using CollegeWebApi.Data;   // или твой namespace, если другой
using CollegeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentRepository _repo;

    public StudentsController()
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=CollegeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        _repo = new StudentRepository(connectionString);
    }

    [HttpGet("all")]
    public IActionResult GetAllForView()
    {
        var students = _repo.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _repo.GetAll().FirstOrDefault(s => s.Id == id);
        if (student == null)
            return NotFound("Студент не найден");
        return Ok(student);
    }
    [HttpPost]
    public IActionResult Create([FromBody] Student student)
    {
        int newId = _repo.Create(student);
        return Ok(new { Id = newId, Message = "Студент создан" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Student student)
    {
        student.Id = id;
        _repo.Update(student);
        return Ok("Студент обновлён");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return Ok("Студент удалён");
    }
}