using Payroll.Application.Contracts.Affiliations;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Transactions.Delete;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test.Assets;

[TestFixture]
public class ServiceChargeTransactionTest
{
    [Test]
    public void Test_AddServiceChargeSuccess()
    {
        int empId = 9;
        AddHourlyEmployee t = new(empId, "Bill", "Home", 15.25);
        t.Execute();
        
        Employee? e = PayrollDb.GetEmployee(empId);
        Assert.That(e, Is.Not.Null);

        UnionAffiliation af = new();
        e.Affiliation = af;
        int memberId = 86; // Maxwell Smart
        PayrollDb.AddUnionMember(memberId, e);

        DateTime date = new(2005, 8, 8);
        ServiceChargeTransaction sct = new(memberId, date, 12.95);
        sct.Execute();
        
        ServiceCharge? sc = af.GetServiceCharge(date);
        Assert.That(sc, Is.Not.Null);
        Assert.That(sc.Amount, Is.EqualTo(12.95));
    }
}