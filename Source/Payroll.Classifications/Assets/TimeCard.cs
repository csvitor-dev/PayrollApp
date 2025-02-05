namespace Payroll.Classifications.Assets;

public class TimeCard(DateTime date, double hours)
{
    public DateTime Date { get; } = date;
    public double Hours { get; } = hours;
}