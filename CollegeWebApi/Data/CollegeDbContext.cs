using System.Collections.Generic;
using CollegeWebApi.Models;
using CollegeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeWebApi.Data;

public class CollegeDbContext : DbContext
{
    public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
}