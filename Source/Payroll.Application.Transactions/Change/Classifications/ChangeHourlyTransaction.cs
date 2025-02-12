using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;
using Payroll.Transactions.Change;

namespace Payroll.Application.Transactions.Change.Classifications;

public class ChangeHourlyTransaction(int id, double hourlyRate) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new HourlyClassification(hourlyRate);
    protected override IPaymentSchedule Schedule 
        => new WeeklySchedule();
}