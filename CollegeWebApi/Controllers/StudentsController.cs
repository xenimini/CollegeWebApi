using CollegeConsole.Data;   // или твой namespace, если другой
using CollegeConsole.Models;
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
}