using Payroll.Core.Contracts;

namespace Payroll.Schedules.Contracts;

public class WeeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date) 
        => date.DayOfWeek == DayOfWeek.Friday;

    public DateTime GetPayPeriodStartDate(DateTime date)
        => date.AddDays(-4);
}