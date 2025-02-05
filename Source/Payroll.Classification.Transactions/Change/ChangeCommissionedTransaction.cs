using Payroll.Classifications.Contracts;
using Payroll.Core.Contracts;
using Payroll.Schedules.Contracts;

namespace Payroll.Classification.Transactions.Change;

public class ChangeCommissionedTransaction
    (int id, double commissionRate, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification
        => new CommissionedClassification(salary, commissionRate);

    protected override IPaymentSchedule Schedule
        => new BiweeklySchedule();
}