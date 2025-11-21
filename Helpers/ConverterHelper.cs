using System;
using System.Globalization;

namespace MySteps.Helpers;

public class ConverterHelper
{
    public static int GetSecondsFromTimeString(string? timeString)
    {
        if (timeString == null)
            return 0;
        TimeSpan duration = TimeSpan.ParseExact(timeString, @"mm\:ss", CultureInfo.InvariantCulture);
        return (int)duration.TotalSeconds;
    }

    public static string GetDateFromFormated(string? dateString)
    {
        if (dateString == null)
            return "";
        return DateTime.ParseExact( dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture ).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}