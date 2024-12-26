using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Transactions.Change.Affiliation;
using Payroll.Application.Transactions.Payday;
using Payroll.Core.Entities;
using Payroll.Test.Payday;

namespace Payroll.Test.Affiliation;

[TestFixture]
public class UnionMemberDuesTest
{
    [Test]
    public void Test_SalariedUnionMemberDues()
    {
        int empId = 33;
        int memId = 7734;
        AddSalariedEmployee t = new(empId, "Bob", "Home", 1522.59);
        ChangeMemberTransaction cmt = new(empId, memId, 9.42);
        DateTime payDate = new(2001, 11, 30);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        cmt.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(empId);
        
        PaycheckValidator.Validate(pc, payDate, 5 * 9.42, 1522.59 - 5 * 9.42);
    }

    [Test]
    public void HourlyUnionMemberServiceCharge()
    {
        int empId = 34;
        int memId = 7735;
        DateTime payDate = new(2001, 11, 9);
        AddHourlyEmployee t = new(empId, "David", "Home", 15.24);
        TimeCardTransaction tct = new(empId, payDate, 8.0);
        ChangeMemberTransaction cmt = new(empId, memId, 9.42);
        ServiceChargeTransaction sct = new(memId, payDate, 19.42);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        tct.Execute();
        cmt.Execute();
        sct.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(empId);
        
        PaycheckValidator.Validate(pc, payDate, 9.42 + 19.42, 8 * 15.24 - (9.42 + 19.42));
    }
}