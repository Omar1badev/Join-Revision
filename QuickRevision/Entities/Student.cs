namespace QuickRevision.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;
    public Dep Dep { get; set; } = default!;

    public ICollection<Dev> devs { get; set; } = [];
}
