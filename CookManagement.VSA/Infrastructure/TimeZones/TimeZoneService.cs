using System;

namespace CookManagement.VSA.Infrastructure.TimeZones;

public class TimeZoneService
{
    private const string DefaultTimeZoneId = "Central America Standard Time";

    public (DateTime startOfDayUtc, DateTime endOfDayUtc) GetTodayBoundariesInUtc(
        string? timeZoneId)
    {
        var userTimeZone = GetTimeZoneInfo(timeZoneId);
        var utcNow = DateTime.UtcNow;

        var userLocalNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, userTimeZone);

        if (userLocalNow.Hour < 10)
        {
            userLocalNow = userLocalNow.AddDays(-1);
        }

        var baseDate = userLocalNow.Date;

        //Obtener Limites Locales
        var startOfDayLocal = baseDate.AddHours(10);
        var endOfDayLocal = baseDate.AddDays(1).AddHours(2);

        //Obtener Limites en UTC
        var startOfDayUtc = TimeZoneInfo.ConvertTimeToUtc(
            startOfDayLocal,
            userTimeZone);

        var endOfDayUtc = TimeZoneInfo.ConvertTimeToUtc(
            endOfDayLocal,
            userTimeZone);

        return (startOfDayUtc, endOfDayUtc);
    }
    
    // public DateTimeOffset GetUserCurrentTime(string? timeZoneId)
    // {
    //     var userTimeZone = GetTimeZoneInfo(timeZoneId);
    //     var utcNow = DateTimeOffset.UtcNow;
        
    //     return TimeZoneInfo.ConvertTime(utcNow, userTimeZone);
    // }

    // public DateTimeOffset ConvertUtcToUserTime(
    //     DateTime utcDateTime, 
    //     string? timeZoneId)
    // {
    //     var userTimeZone = GetTimeZoneInfo(timeZoneId);
    //     return TimeZoneInfo.ConvertTime(utcDateTime, userTimeZone);
    // }

    public (DateTime startOfDayUtc, DateTime endOfDayUtc) GetCurrentDateBoundariesInUtc
        (string? timeZoneId, DateTime requestedDate)
    {
        var userTimeZone = GetTimeZoneInfo(timeZoneId);
        var userLocalNow = TimeZoneInfo.ConvertTime(requestedDate, userTimeZone);

        var baseDate = userLocalNow.Date;

        //Obtener Limites Locales
        var startOfDayLocal = baseDate.AddHours(10);
        var endOfDayLocal = baseDate.AddDays(1).AddHours(2);

        //Obtener Limites en UTC
        var startOfDayUtc = TimeZoneInfo.ConvertTimeToUtc(
            startOfDayLocal,
            userTimeZone);

        var endOfDayUtc = TimeZoneInfo.ConvertTimeToUtc(
            endOfDayLocal,
            userTimeZone);

        return (startOfDayUtc, endOfDayUtc);
    }
    
    private TimeZoneInfo GetTimeZoneInfo(string? timeZoneId)
    {
        var zoneId = string.IsNullOrWhiteSpace(timeZoneId) 
            ? DefaultTimeZoneId 
            : timeZoneId;

        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById(zoneId);
        }
        catch (TimeZoneNotFoundException)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(DefaultTimeZoneId);
        }
        catch (InvalidTimeZoneException)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(DefaultTimeZoneId);
        }
    }
}
