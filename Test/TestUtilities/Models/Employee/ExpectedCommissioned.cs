namespace TestUtilities.Models.Employee;

public record ExpectedCommissioned
    (int Id, string Name, string Address, double Salary, double CommissionRate) : ExpectedBase(Id, Name, Address);