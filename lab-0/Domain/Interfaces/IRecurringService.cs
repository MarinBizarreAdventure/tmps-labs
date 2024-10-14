using Domain.Models;

namespace Domain.Interfaces;

public interface IRecurringTaskService
{
    int GetRecurrenceFrequency(RecurringTask recurringTask);
    bool SetRecurrenceFrequency(int recurringTaskId, int frequencyInDays);
}
