using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Schedules;

public class MonthlySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
        => IsLastDayOfMonth(date);

    public DateTime GetPayPeriodStartDate(DateTime date)
        => new(date.Year, date.Month, 1);

    private bool IsLastDayOfMonth(DateTime date) 
        => date.Month != date.AddDays(1).Month;
}