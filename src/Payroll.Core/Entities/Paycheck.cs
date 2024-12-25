namespace Payroll.Core.Entities;

public class Paycheck(DateTime start, DateTime payDate)
{
    public double GrossPay { get; set; }
    public double Deductions { get; set; }
    public double NetPay { get; set; }
    public DateTime StartDate { get; } = start;
    public DateTime PayDate { get; } = payDate;

    public string GetField(string field)
        => "Hold";
}