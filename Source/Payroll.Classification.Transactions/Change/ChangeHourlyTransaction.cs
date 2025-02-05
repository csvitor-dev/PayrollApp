using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;

namespace Payroll.Classification.Transactions.Change;

public class ChangeHourlyTransaction(int id, double hourlyRate) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new HourlyClassification(hourlyRate);
    protected override IPaymentSchedule Schedule 
        => new WeeklySchedule();
}