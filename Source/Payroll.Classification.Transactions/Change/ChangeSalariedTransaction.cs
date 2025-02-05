using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;

namespace Payroll.Classification.Transactions.Change;

public class ChangeSalariedTransaction(int id, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new SalariedClassification(salary);
    protected override IPaymentSchedule Schedule 
        => new MonthlySchedule();
}