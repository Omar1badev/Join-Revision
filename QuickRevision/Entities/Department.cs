namespace QuickRevision.Entities;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; } = [];
}
public class Dev
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set; } = [];
}

public class Dep
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int StudentId { get; set; }
    public Student Students { get; set; } = default!;
}
