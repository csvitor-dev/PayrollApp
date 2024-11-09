namespace Payroll.Core.Entities;

public class ServiceCharge(DateTime date, double charge)
{
    public DateTime Date { get; } = date;
    public double Amount { get; } = charge;
}