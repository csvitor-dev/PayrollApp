using Payroll.Core.Contracts;
using Payroll.Application.Extensions;

namespace Payroll.Application.Contracts.Schedules;

public class BiweeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
        => IsFriday(date) && IsBiweeklyDay(date);
    
    private static bool IsFriday(DateTime date)
        => date.DayOfWeek == DayOfWeek.Friday;

    private static bool IsBiweeklyDay(DateTime date)
        => date.WeekOfMonth() == 1 || date.WeekOfMonth() == 3;
}