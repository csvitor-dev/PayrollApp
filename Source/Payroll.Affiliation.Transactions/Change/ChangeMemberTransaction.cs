using Payroll.Affiliations.Contracts;
using Payroll.Core.Contracts;
using Payroll.Core.Entities;
using Payroll.Infrastructure.Data;

namespace Payroll.Affiliation.Transactions.Change;

public class ChangeMemberTransaction
    (int empId, int memId, double dues) : ChangeAffiliationTransaction(empId)
{
    protected override IAffiliation Affiliation 
        => new UnionAffiliation(memId, dues);

    protected override void RecordMembership(Employee employee)
        => PayrollDb.AddUnionMember(memId, employee);
}