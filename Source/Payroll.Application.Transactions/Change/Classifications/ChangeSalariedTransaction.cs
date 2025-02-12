using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;
using Payroll.Transactions.Change;

namespace Payroll.Application.Transactions.Change.Classifications;

public class ChangeSalariedTransaction(int id, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification 
        => new SalariedClassification(salary);
    protected override IPaymentSchedule Schedule 
        => new MonthlySchedule();
}