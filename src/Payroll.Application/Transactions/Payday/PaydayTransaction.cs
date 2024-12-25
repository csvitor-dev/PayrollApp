using Payroll.Core.Data;
using Payroll.Core.Entities;

namespace Payroll.Application.Transactions.Payday;

public class PaydayTransaction(DateTime payDate) : ITransaction
{
    private readonly Dictionary<int, Paycheck> _paychecks = [];
    
    public void Execute()
    {
        var employees = PayrollDb.GetEmployees();

        foreach (var employee in employees)
            if (employee.IsPayDate(payDate))
            {
                var startDate = employee.GetPayPeriodStartDate(payDate);
                Paycheck pc = new(startDate, payDate);
                _paychecks.Add(employee.ID, pc);
                employee.Payday(pc);
            }
    }

    public Paycheck? GetPaycheck(int id) 
        => _paychecks.GetValueOrDefault(id);
}