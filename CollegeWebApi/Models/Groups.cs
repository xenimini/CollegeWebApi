using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeWebApi.Models;

public class Group
{
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; } = string.Empty;
}