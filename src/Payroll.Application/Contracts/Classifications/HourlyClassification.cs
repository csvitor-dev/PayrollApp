using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class HourlyClassification(double hourlyRate) : IPaymentClassification
{
    public double HourlyRate { get; set; } = hourlyRate;
    public IList<TimeCard> TimeCards { get; } = [];

    public void AddTimeCard(TimeCard card)
        => TimeCards.Add(card);
    public TimeCard? GetTimeCard(DateTime date)
        => TimeCards.FirstOrDefault(t => t.Date == date);

    public double CalculatePay(Paycheck paycheck)
        => default; // because without time cards, your payment is 0
}