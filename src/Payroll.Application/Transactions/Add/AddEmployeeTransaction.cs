using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;
using Payroll.Application.Contracts.Classifications;

namespace Payroll.Application.Transactions.Add;

public abstract class AddEmployeeTransaction(int empID, string name, string address) 
    : ITransaction
{
    protected abstract IPaymentClassification MakeClassification(); // FACTORY METHOD
    protected abstract IPaymentSchedule MakeSchedule(); // FACTORY METHOD

    public void Execute()
    {
        IPaymentClassification pc = MakeClassification();
        IPaymentSchedule ps = MakeSchedule();
        IPaymentMethod pm = new HoldMethod();

        Employee e = new(empID, name, address);
        e.Classification = pc;
        e.Schedule = ps;
        e.Method = pm;

        PayrollDb.AddEmployee(empID, e);
    }
}