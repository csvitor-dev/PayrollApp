using Payroll.Application.Contracts.Affiliations;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change.Affiliation;

public class ChangeUnaffiliatedTransaction(int id) : ChangeAffiliationTransaction(id)
{
    protected override IAffiliation Affiliation
        => new NoAffiliation();

    protected override void RecordMembership(Employee employee)
    {
        if (employee.Affiliation is UnionAffiliation affiliation)
            PayrollDb.RemoveUnionMember(affiliation.MemberId);
    }
}