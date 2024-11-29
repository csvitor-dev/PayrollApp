using Payroll.Core.Contracts;

namespace Payroll.Core.Entities;

public class Employee(int id, string name, string address)
{
    public int ID { get; } = id;
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
    public IAffiliation Affiliation { get; set; } = null!;
    public IPaymentClassification Classification { get; set; } = null!;
    public IPaymentSchedule Schedule { get; set; } = null!;
    public IPaymentMethod Method { get; set; } = null!;

    public bool IsPayDate(DateTime date)
        => Schedule.IsPayDate(date);

    public void Payday(Paycheck paycheck)
    {
        var grossPay = Classification.CalculatePay(paycheck);
        var deductions = Affiliation.CalculateDeductions(paycheck);
        var netPay = grossPay - deductions;
        
        paycheck.GrossPay = grossPay;
        paycheck.Deductions = deductions;
        paycheck.NetPay = netPay;
        
        Method.Pay(paycheck);
    }
}