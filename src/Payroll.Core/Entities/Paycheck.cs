namespace Payroll.Core.Entities;

public class Paycheck(DateTime payDate)
{
    public double GrossPay { get; set; }
    public double Deductions { get; set; }
    public double NetPay { get; set; }
    public DateTime PayDate { get; set; } = payDate;

    public string GetField(string field)
        => "Hold";
}