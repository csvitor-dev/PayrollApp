namespace Payroll.Core.Entities;

public class SalesReceipt(DateTime date, double amount)
{
    public DateTime Date { get; } = date;
    public double Amount { get; } = amount;
}