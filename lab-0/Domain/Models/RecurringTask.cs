namespace Domain.Models;

public class RecurringTask : Task
{
    public int Frequency { get; private set; } 

    public int FrequencyInDays { get; private set; }

    public RecurringTask(string title, string description, int frequencyInDays)
        : base(title, description)
    {
        FrequencyInDays = frequencyInDays;
    }
    
    public void SetFrequency(int frequencyInDays)
    {
        FrequencyInDays = frequencyInDays;
    }

    
    public override string GetTaskDetails()
    {
        return base.GetTaskDetails() + $", Recurs every {FrequencyInDays} days.";
    }
}