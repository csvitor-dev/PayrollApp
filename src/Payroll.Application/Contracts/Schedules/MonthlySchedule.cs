using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Schedules;

public class MonthlySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
        => IsLastDayOfMonth(date);
    private bool IsLastDayOfMonth(DateTime date) 
        => date.Month != date.AddDays(1).Month;
}