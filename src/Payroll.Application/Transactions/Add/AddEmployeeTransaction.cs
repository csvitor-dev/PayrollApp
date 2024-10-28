using Payroll.Core.Contracts;
using Payroll.Core.Data;
using Payroll.Core.Entities;
using Payroll.Application.Contracts.Classifications;

namespace Payroll.Application.Transactions.Add;

public abstract class AddEmployeeTransaction(int empID, string name, string address) 
    : ITransaction
{
    private readonly int _empID = empID;
    private readonly string _name = name;
    private readonly string _address = address;

    protected abstract IPaymentClassification MakeClassification(); // FACTORY METHOD
    protected abstract IPaymentSchedule MakeSchedule(); // FACTORY METHOD

    public void Execute()
    {
        IPaymentClassification pc = MakeClassification();
        IPaymentSchedule ps = MakeSchedule();
        IPaymentMethod pm = new HoldMethod();

        Employee e = new(_empID, _name, _address);
        e.Classification = pc;
        e.Schedule = ps;
        e.Method = pm;

        PayrollDB.AddEmployee(_empID, e);
    }
}