using Payroll.Core.Contracts;
using Payroll.Core.Entities;

namespace Payroll.Application.Contracts.Classifications;

public class HourlyClassification(double hourlyRate) : IPaymentClassification
{
    public double HourlyRate { get; set; } = hourlyRate;
    public IList<TimeCard> TimeCards { get; } = [];

    public void AddTimeCard(TimeCard timeCard)
        => TimeCards.Add(timeCard);
    public TimeCard? GetTimeCard(DateTime dateTime)
        => TimeCards.FirstOrDefault(t => t.Date == dateTime);
}