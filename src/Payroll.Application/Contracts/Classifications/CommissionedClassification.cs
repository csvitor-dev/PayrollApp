using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class CommissionedClassification(double salary, double commissionRate) : IPaymentClassification
{
    public double Salary { get; set; } = salary;
    public double CommissionRate { get; set; } = commissionRate;
    public IList<SalesReceipt> SalesReceipts { get; } = [];

    public void AddSalesReceipt(SalesReceipt sales)
        => SalesReceipts.Add(sales);

    public SalesReceipt? GetSalesReceipt(DateTime date)
        => SalesReceipts.FirstOrDefault(s => s.Date == date);

    public double CalculatePay(Paycheck paycheck)
        => Salary + CalculateCommission(paycheck.PayDate);

    private double CalculateCommission(DateTime payDate)
    {
        var salesReceiptInPeriod = from sales in SalesReceipts
            where IsCurrentPaymentPeriod(payDate, sales.Date)
            select sales;
        
        return salesReceiptInPeriod.Sum(CalculatePayForSalesReceipt);
    }

    private static bool IsCurrentPaymentPeriod(DateTime payDate, DateTime date)
        => date > payDate.AddDays(-12) && date <= payDate;
    
    private double CalculatePayForSalesReceipt(SalesReceipt sales)
        => sales.Amount * CommissionRate;
}