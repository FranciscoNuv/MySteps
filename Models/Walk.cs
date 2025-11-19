using System.ComponentModel;
using SQLite;

namespace MySteps.Models;

public enum DayPeriod { Morning=0, Afternoon=1, Evening=2 }

[Table("walks")]
public class Walk
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public DateTime DateUtc { get; set; }
    public DayPeriod DayPeriod { get; set; }

    public int DurationSec { get; set; }
    public double DistanceMeters { get; set; }
    public double? Calories { get; set; }

    public double? AvgSpeedKmh { get; set; }
    public double? MaxSpeedKmh { get; set; }

    public int? AvgPaceSecPerKm { get; set; }
    public int? MaxPaceSecPerKm { get; set; }

    public int? AvgHrBpm { get; set; }
    public int? MaxHrBpm { get; set; }

    public bool WarmUpAbs { get; set; } = false;
    public bool WarmUpArms { get; set; } = false;
    public bool WarmUpLegs { get; set; } = false;
    public bool WarmUpBack { get; set; } = false;
    public bool WarmUpChest { get; set; } = false;

    public double DistanceKm => DistanceMeters / 1000.0;
}