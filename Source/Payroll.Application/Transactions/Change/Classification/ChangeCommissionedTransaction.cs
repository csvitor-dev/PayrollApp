using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;

namespace Payroll.Application.Transactions.Change.Classification;

public class ChangeCommissionedTransaction
    (int id, double commissionRate, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification
        => new CommissionedClassification(salary, commissionRate);

    protected override IPaymentSchedule Schedule
        => new BiweeklySchedule();
}