using Payroll.Core.Contracts;

namespace Payroll.Application.Contracts.Classifications;

public class HourlyClassification(double hourlyRate) : IPaymentClassification
{
    public double HourlyRate { get; set; } = hourlyRate;
    public IList<string> TimeCards { get; } = new List<string>();
}