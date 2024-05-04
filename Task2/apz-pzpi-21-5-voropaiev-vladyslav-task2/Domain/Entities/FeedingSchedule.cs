namespace Domain.Entities;

public class FeedingSchedule : BaseEntity
{
    public Guid PondId { get; set; }
    
    public required Pond Pond { get; set; }
    
    public int FeedingFrequencyInHours { get; set; }
    
    public double FoodAmount { get; set; }
}