public class Team
{
    public int TeamId { get; set; } // Changed from Id to TeamId for clarity
    public string Name { get; set; }
    public string Description { get; set; }

    public string TeamLead { get; set; }
    public string Manager { get; set; }

    // Navigation
    public List<Employee> Employees { get; set; }
}
