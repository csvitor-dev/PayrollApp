namespace TestUtilities.Models.Employee;

public record ExpectedHourly
    (int Id, string Name, string Address, double HourlyRate) : ExpectedBase(Id, Name, Address);