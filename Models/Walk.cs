using System.ComponentModel;
using SQLite;

namespace MySteps.Models;


public enum DayPeriod { Morning=0, Afternoon=1, Evening=2 }

public record WalkImport(string Date, string Duration, double Distance, double Calories, double AvgSpeed, string AvgPace, double MaxSpeed, string MaxPace, bool Arms, bool Legs, bool Chest, bool Back, bool Abs, int DayPeriod);

[Table("walks")]
public class Walk
{
    [PrimaryKey, AutoIncrement]
    public int? Id { get; set; }

    public String Date { get; set; }
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
    public bool WarmUpBack { get; set; } = false;
    public bool WarmUpChest { get; set; } = false;
    public bool WarmUpLegs { get; set; } = false;

    [Ignore]
    public DateTime DateTimeValue
    {
        get => DateTime.Parse(Date);
        set => Date = value.ToString("yyyy-MM-dd");
    }
    public string DateFormated => DateTimeValue.ToString("dd/MM/yyyy");
    public DayOfWeek WeekDay => DateTimeValue.DayOfWeek;
    public double DistanceKm => DistanceMeters / 1000;
    public string Duration => TimeSpan.FromSeconds((long)DurationSec).ToString(@"mm:ss");
    public string AvgPace => AvgPaceSecPerKm is null ? "00:00" : TimeSpan.FromSeconds((long)AvgPaceSecPerKm).ToString(@"mm:ss");
    public string MaxPace => MaxPaceSecPerKm is null ? "00:00" :  TimeSpan.FromSeconds((long)MaxPaceSecPerKm).ToString(@"mm:ss");
    public string WarmUp()
    {
        List<string> warmUps = new List<string>();
        if (WarmUpAbs)
            warmUps.Add("Abs");
        if (WarmUpArms)
            warmUps.Add("Arms");
        if (WarmUpBack)
            warmUps.Add("Back");
        if (WarmUpChest)
            warmUps.Add("Chest");
        if (WarmUpLegs)
            warmUps.Add("Legs");
        return String.Join(", ", warmUps)??"";
    }
}