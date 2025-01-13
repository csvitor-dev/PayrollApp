using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Classification;

public class ChangeSalariedTransaction(int id, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new SalariedClassification(salary);
    protected override IPaymentSchedule Schedule 
        => new MonthlySchedule();
}