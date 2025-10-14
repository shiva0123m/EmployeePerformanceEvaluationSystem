public class Rating
{
    public Guid RatingId { get; set; }
    public int Score { get; set; }
    public string Comments { get; set; }

    // FK + Navigation for one-to-one
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
