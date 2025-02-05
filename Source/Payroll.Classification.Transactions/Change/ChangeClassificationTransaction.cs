using Payroll.Core.Contracts;
using Payroll.Core.Entities;
using Payroll.Transactions.Base;

namespace Payroll.Classification.Transactions.Change;

public abstract class ChangeClassificationTransaction(int id) : ChangeEmployeeTransaction(id)
{
    protected sealed override void Change(Employee employee)
    {
        employee.Classification = Classification;
        employee.Schedule = Schedule;
    }
    protected abstract IPaymentClassification Classification { get; }
    protected abstract IPaymentSchedule Schedule { get; }
}