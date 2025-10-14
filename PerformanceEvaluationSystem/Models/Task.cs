public class Task
{
    public Guid TaskId { get; set; } // Use GUID to match Employee reference
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    // FK + Navigation
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
