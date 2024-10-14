using Domain.Models;

namespace Domain.Interfaces;

public interface IRecurringTaskRepository
{
    
    int GetRecurrenceFrequency(RecurringTask recurringTask);
    bool SetRecurrenceFrequency(int recurringTaskId , int frequencyInDays);
}
