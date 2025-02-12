namespace TestUtilities.Models.Employee;

public record ExpectedSalaried
    (int Id, string Name, string Address, double Salary) : ExpectedBase(Id, Name, Address);