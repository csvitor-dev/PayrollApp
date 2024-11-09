using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Transactions.Add;
using Payroll.Application.Transactions.Assets;

using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Test;

[TestFixture]
public class SalesReceiptTransactionTest
{
    [Test]
    public void Test_SalesReceiptTransactionSuccess()
    {
        int id = 7;
        AddCommissionedEmployee t = new(id, "Thomas", "Home", 1350.00, 2.5);
        t.Execute();
        
        DateTime date = new(2008, 11, 25);
        SalesReceiptTransaction srt = new(id, date, 250.50);
        srt.Execute();

        Employee? e = PayrollDb.GetEmployee(id);
        Assert.That(e, Is.Not.Null);

        IPaymentClassification pc = e.Classification;
        Assert.That(pc is CommissionedClassification, Is.True);
        CommissionedClassification cc = (pc as CommissionedClassification)!;

        SalesReceipt? sale = cc.GetSalesReceipt(date);
        Assert.IsNotNull(sale);
        Assert.That(sale.Amount, Is.EqualTo(250.50));
    }

    [Test]
    public void Test_SalesReceiptTransactionFail()
    {
        int id = 8;
        AddSalariedEmployee t = new(id, "Eliot", "Home", 1890.00);
        t.Execute();
        
        DateTime date = new(2009, 12, 15);
        SalesReceiptTransaction srt = new(id, date, 500.50);
        
        Assert.Throws<InvalidOperationException>(() => srt.Execute());
    }
}