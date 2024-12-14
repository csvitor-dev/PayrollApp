namespace Payroll.Application.Extensions;

public static class DateTimeExtension
{
    public static int WeekOfMonth(this DateTime date)
    {
        var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
        var dayOfWeek = (int)firstDayOfMonth.DayOfWeek;

        return (date.Day + dayOfWeek - 1) / 7 % 4;
    }
}