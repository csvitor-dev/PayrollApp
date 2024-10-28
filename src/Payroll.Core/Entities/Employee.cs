using Payroll.Core.Contracts;

namespace Payroll.Core.Entities;

public class Employee
{
    public int ID { get; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public IPaymentClassification Classification { get; set; } = null!;
    public IPaymentSchedule Schedule { get; set; } = null!;
    public IPaymentMethod Method { get; set; } = null!;
   
    public Employee(int id, string name, string address)
    {
        ID = id;
        Name = name;
        Address = address;
    }
}