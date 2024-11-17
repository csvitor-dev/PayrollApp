using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change.Affiliation;

public abstract class ChangeAffiliationTransaction(int id) : ChangeEmployeeTransaction(id)
{
    protected sealed override void Change(Employee employee)
    {
        RecordMembership(employee);
        employee.Affiliation = Affiliation;
    }
    protected abstract IAffiliation Affiliation { get; }
    protected abstract void RecordMembership(Employee employee);
}