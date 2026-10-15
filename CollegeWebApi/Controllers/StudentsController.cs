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

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _repo.GetAll();
        return Ok(students);
    }

    [HttpGet("hello")]
    public IActionResult Hello()
    {
        return Ok("Привет из ASP.NET Core Web API! Урок 12 выполнен.");
    }
}