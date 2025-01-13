using Payroll.Application.Contracts.Affiliations;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Change.Affiliation;

public class ChangeMemberTransaction
    (int empId, int memId, double dues) : ChangeAffiliationTransaction(empId)
{
    protected override IAffiliation Affiliation 
        => new UnionAffiliation(memId, dues);

    protected override void RecordMembership(Employee employee)
        => PayrollDb.AddUnionMember(memId, employee);
}