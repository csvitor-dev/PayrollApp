using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Classification;

public class ChangeHourlyTransaction(int id, double hourlyRate) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new HourlyClassification(hourlyRate);
    protected override IPaymentSchedule Schedule 
        => new WeeklySchedule();
}