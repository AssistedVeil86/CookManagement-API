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

        //Obtener Limites Locales
        var startOfDayLocal = userLocalNow.Date;
        var endOfDayLocal = startOfDayLocal.AddDays(1);

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

        var userLocalDate = TimeZoneInfo.ConvertTime(requestedDate, userTimeZone);

        var startOfDayLocal = userLocalDate.Date;
        var endOfDayLocal = startOfDayLocal.AddDays(1);

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
