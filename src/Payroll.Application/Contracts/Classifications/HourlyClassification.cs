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
    {
        var currentTimeCards = from cards in TimeCards
            where IsCurrentPaymentPeriod(paycheck.PayDate, cards.Date)
            select cards;

        return currentTimeCards.Sum(CalculatePayForTimeCard);
    }

    private double CalculatePayForTimeCard(TimeCard card)
    {
        var overtime = Math.Max(0.0, card.Hours - 8.0);
        var normal = card.Hours - overtime;

        return normal * HourlyRate +
               overtime * 1.5 * HourlyRate;
    }

    private static bool IsCurrentPaymentPeriod(DateTime payDate, DateTime date)
        => date >= payDate.AddDays(-5) && date <= payDate;
}