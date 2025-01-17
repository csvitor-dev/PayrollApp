using Payroll.Application.Contracts.Affiliations;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Change.Affiliation;
using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test.Change;

[TestFixture]
public class ChangeAffiliationTransactionTest
{
    [Test]
    public void Test_ChangeMemberTransaction()
    {
        int empId = 18;
        int memId = 7743;
        AddHourlyEmployee t = new(empId, "Bill", "Home", 15.25);
        ChangeMemberTransaction cmt = new(empId, memId, 99.42);

        t.Execute();
        cmt.Execute();
        Employee? e = PayrollDb.GetEmployee(empId);
        IAffiliation? aff = e?.Affiliation;
        UnionAffiliation? uf = aff as UnionAffiliation;
        Employee? m = PayrollDb.GetUnionMember(memId);

        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(aff, Is.Not.Null);
            Assert.That(uf, Is.Not.Null);
            Assert.That(m, Is.Not.Null);
        });
        Assert.Multiple(() =>
        {
            Assert.That(aff is UnionAffiliation, Is.True);
            Assert.That(uf.Dues, Is.EqualTo(99.42));
            Assert.That(e, Is.EqualTo(m));
        });
    }

    [Test]
    public void Test_ChangeUnaffiliatedTransaction()
    {
        int empId = 19;
        int memId = 789;
        AddSalariedEmployee t = new(empId, "Johnson", "Home", 1528.50);
        ChangeMemberTransaction cmt = new ChangeMemberTransaction(empId, memId, 75.24);
        ChangeUnaffiliatedTransaction cut = new(empId);

        t.Execute();
        cmt.Execute();
        cut.Execute();
        Employee? e = PayrollDb.GetEmployee(empId);
        IAffiliation? aff = e?.Affiliation;
        Employee? m = PayrollDb.GetUnionMember(memId);

        Assert.Multiple(() =>
        {
            Assert.That(e, Is.Not.Null);
            Assert.That(aff, Is.Not.Null);
            Assert.That(m, Is.Null);
        });
        Assert.That(aff is NoAffiliation, Is.True);
    }
}