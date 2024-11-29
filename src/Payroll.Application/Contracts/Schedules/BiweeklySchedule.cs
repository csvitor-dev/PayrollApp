using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Schedules;

public class BiweeklySchedule : IPaymentSchedule
{
    public bool IsPayDate(DateTime date)
    {
        return default;
    }
}