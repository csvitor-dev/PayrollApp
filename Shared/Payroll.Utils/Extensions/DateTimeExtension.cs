namespace Payroll.Utils.Extensions;

public static class DateTimeExtension
{
    public static int WeekOfMonth(this DateTime self)
    {
        var firstDayOfMonth = new DateTime(self.Year, self.Month, 1);
        var dayOfWeek = (int)firstDayOfMonth.DayOfWeek;

        return (self.Day + dayOfWeek - 1) / 7 % 4;
    }

    public static bool IsInPayPeriod(this DateTime self, DateTime start, DateTime payDate)
        => self >= start && self <= payDate;
}