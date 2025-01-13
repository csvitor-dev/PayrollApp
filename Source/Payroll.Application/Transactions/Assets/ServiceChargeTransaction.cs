using Payroll.Application.Contracts.Affiliations;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Assets;

public class ServiceChargeTransaction(int id, DateTime date, double charge) : ITransaction
{
    public void Execute()
    {
        Employee? e = PayrollDb.GetUnionMember(id);
        
        if (e is null)
            throw new InvalidOperationException("No such union member");
        
        if (e.Affiliation is not UnionAffiliation ua)
            throw new InvalidOperationException("Member without a union affiliation");
        ua.AddServiceCharge(new(date, charge));
    }
}