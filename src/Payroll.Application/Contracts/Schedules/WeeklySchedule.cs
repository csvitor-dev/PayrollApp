using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Schedules;

public class WeeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return default;
    }
}