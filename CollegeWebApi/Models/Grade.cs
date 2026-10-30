namespace CollegeWebApi.Models;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public int Score { get; set; }
    public DateTime GradeDate { get; set; } = DateTime.Now;
}