namespace Payroll.Core.Contracts;

public interface IPaymentSchedule
{
    public bool IsPayDate(DateTime date);
}