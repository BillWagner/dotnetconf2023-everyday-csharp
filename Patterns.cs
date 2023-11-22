namespace patterns;

class Simulation
{
    // Taken from https://docs.microsoft.com/dotnet/csharp/language-reference/operators/switch-expression
    string WaterState(int tempInFahrenheit) =>
        tempInFahrenheit switch
        {
            > 212 => "gas",
            (> 32) and (< 212) => "liquid",
            32 => "solid/liquid transition",
            < 32 => "solid",
            212 => "liquid / gas transition",
        };

    string WaterState2(int tempInFahrenheit) =>
        tempInFahrenheit switch
        {
            < 32 => "solid",
            32 => "solid/liquid transition",
            < 212 => "liquid",
            212 => "liquid / gas transition",
            _ => "gas",
        };


    // Taken from https://learn.microsoft.com/dotnet/csharp/fundamentals/tutorials/pattern-matching
    public decimal PeakTimePremiumIfElse(DateTime timeOfToll, bool inbound)
    {
        if ((timeOfToll.DayOfWeek == DayOfWeek.Saturday) ||
            (timeOfToll.DayOfWeek == DayOfWeek.Sunday))
        {
            return 1.0m;
        }
        else
        {
            int hour = timeOfToll.Hour;
            if (hour < 6)
            {
                return 0.75m;
            }
            else if (hour < 10)
            {
                if (inbound)
                {
                    return 2.0m;
                }
                else
                {
                    return 1.0m;
                }
            }
            else if (hour < 16)
            {
                return 1.5m;
            }
            else if (hour < 20)
            {
                if (inbound)
                {
                    return 1.0m;
                }
                else
                {
                    return 2.0m;
                }
            }
            else // Overnight
            {
                return 0.75m;
            }
        }
    }

    private static bool IsWeekDay(DateTime timeOfToll) =>
    timeOfToll.DayOfWeek switch
    {
        DayOfWeek.Saturday => false,
        DayOfWeek.Sunday => false,
        _ => true,
    };

    private enum TimeBand
    {
        MorningRush,
        Daytime,
        EveningRush,
        Overnight
    }

    private static TimeBand GetTimeBand(DateTime timeOfToll) =>
        timeOfToll.Hour switch
        {
            < 6 or > 19 => TimeBand.Overnight,
            < 10 => TimeBand.MorningRush,
            < 16 => TimeBand.Daytime,
            _ => TimeBand.EveningRush,
        };

    public decimal PeakTimePremiumFull(DateTime timeOfToll, bool inbound) =>
    (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
    {
        (true, TimeBand.MorningRush, true) => 2.00m,
        (true, TimeBand.MorningRush, false) => 1.00m,
        (true, TimeBand.Daytime, true) => 1.50m,
        (true, TimeBand.Daytime, false) => 1.50m,
        (true, TimeBand.EveningRush, true) => 1.00m,
        (true, TimeBand.EveningRush, false) => 2.00m,
        (true, TimeBand.Overnight, true) => 0.75m,
        (true, TimeBand.Overnight, false) => 0.75m,
        (_, _, _) => 1.00m,
    };

    public decimal PeakTimePremiumSimplified(DateTime timeOfToll, bool inbound) =>
    (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
    {
        (true, TimeBand.Overnight, _) => 0.75m,
        (true, TimeBand.Daytime, _) => 1.5m,
        (true, TimeBand.MorningRush, true) => 2.0m,
        (true, TimeBand.EveningRush, false) => 2.0m,
        _ => 1.0m,
    };

}