
public class Employee
{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }

    // Foreign Keys
    public int TeamId { get; set; }

    // Navigation Properties
    public Team Team { get; set; }

    public ICollection<Task> Tasks { get; set; } // One-to-many
    public Rating Rating { get; set; } // One-to-one
}
