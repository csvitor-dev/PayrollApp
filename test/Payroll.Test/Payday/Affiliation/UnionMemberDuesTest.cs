using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;
using Payroll.Application.Transactions.Change.Affiliation;
using Payroll.Application.Transactions.Payday;

namespace Payroll.Test.Payday.Affiliation;

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
    public void Test_HourlyUnionMember_WithOneServiceCharge()
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
    
    [Test]
    public void Test_CommissionedUnionMember_WithServiceCharges_OnMultiplePayPeriods()
    {
        int empId = 35;
        int memId = 7736;
        DateTime earlyPayDate = new(2001, 11, 2);
        DateTime payDate = new(2001, 11, 9);
        DateTime latePayDate = new(2001, 11, 16);
        AddCommissionedEmployee t = new(empId, "Frank", "Home", 1250.15, 12.1);
        SalesReceiptTransaction srt = new(empId, earlyPayDate, 315.7);
        ChangeMemberTransaction cmt = new(empId, memId, 9.42);
        ServiceChargeTransaction sct1 = new(memId, earlyPayDate, 20.15);
        ServiceChargeTransaction sct2 = new(memId, payDate, 100.0);
        ServiceChargeTransaction sct3 = new(memId, latePayDate, 200.0);
        PaydayTransaction pt = new(payDate);
        
        t.Execute();
        srt.Execute();
        cmt.Execute();
        sct1.Execute();
        sct2.Execute();
        sct3.Execute();
        pt.Execute();
        var pc = pt.GetPaycheck(empId);
        
        PaycheckValidator.Validate(pc, payDate,
            2 * 9.42 + 20.15 + 100.0, 1250.15 + 12.1 * 315.7 - (2 * 9.42 + 20.15 + 100.0));
    }
}