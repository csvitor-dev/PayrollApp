using Payroll.Application.Contracts.Classifications;
using Payroll.Application.Contracts.Schedules;
using Payroll.Core.Contracts;
using Payroll.Transactions.Change;

namespace Payroll.Application.Transactions.Change.Classifications;

public class ChangeCommissionedTransaction
    (int id, double commissionRate, double salary) : ChangeClassificationTransaction(id)
{
    protected override IPaymentClassification Classification
        => new CommissionedClassification(salary, commissionRate);

    protected override IPaymentSchedule Schedule
        => new BiweeklySchedule();
}