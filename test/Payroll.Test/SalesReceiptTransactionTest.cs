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

        Employee? e = PayrollDB.GetEmployee(id);
        Assert.IsNotNull(e);

        IPaymentClassification pc = e.Classification;
        Assert.IsTrue(pc is CommissionedClassification);
        CommissionedClassification cc = (pc as CommissionedClassification)!;

        SalesReceipt? sale = cc.GetSalesReceipt(date);
        Assert.IsNotNull(sale);
        Assert.That(sale.Amount, Is.EqualTo(250.50));
    }
}