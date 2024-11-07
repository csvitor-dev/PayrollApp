using Payroll.Application.Transactions.Add;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class ServiceChargeTransactionTest
{
    [Test]
    public void Test_AddServiceCharge()
    {
        int empId = 9;
        AddHourlyEmployee t = new(empId, "Bill", "Home", 15.25);
        t.Execute();
        
        Employee? e = PayrollDB.GetEmployee(empId);
        Assert.That(e, Is.Not.Null);

        UnionAffiliation af = new();
        e.Affiliation = af;
        int memberId = 86;
        PayrollDB.AddUnionMember(memberId, e);

        DateTime date = new(2005, 8, 8);
        ServiceChargeTransaction sct = new(memberId, date, 12.95);
        sct.Execute();
        
        ServiceCharge sc = af.GetServiceCharge(date);
        Assert.That(sc, Is.Not.Null);
        Assert.That(sc.Amount, Is.EqualTo(12.95));
    }
}