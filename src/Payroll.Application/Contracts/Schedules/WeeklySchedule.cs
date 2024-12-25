using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Schedules;

public class WeeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date) 
        => date.DayOfWeek == DayOfWeek.Friday;

    public DateTime GetPayPeriodStartDate(DateTime date)
        => default;
}