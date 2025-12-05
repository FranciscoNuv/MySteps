using LocalizationResourceManager.Maui.ComponentModel;
using System.Collections.ObjectModel;
using MySteps.Models;

namespace MySteps.ViewModels;
public class WalkViewModel: ObservableObject
{
    private int? _id = null;
    private string? _date = null;
    private DayOfWeek? _weekDay = null;
    private DayPeriod? _dayPeriod = null;
    private string? _duration = null;
    private double? _distance = null;
    private double? _calories = null;
    private double? _avgSpeed = null;
    private double? _maxSpeed = null;
    private string? _avgPace = null;
    private string? _maxPace = null;
    private int? _avgBpm = null;
    private int? _maxBpm = null;
    private string? _warmUp = null;
    private bool? _warmUpAbs = null;
    private bool? _warmUpArms = null;
    private bool? _warmUpBack = null;
    private bool? _warmUpChest = null;
    private bool? _warmUpLegs = null;

    public int? Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
    public string? Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }
    public DayOfWeek? WeekDay
    {
        get => _weekDay;
        set => SetProperty(ref _weekDay, value);
    }
    public DayPeriod? DayPeriod
    {
        get => _dayPeriod;
        set => SetProperty(ref _dayPeriod, value);
    }
    public string? Duration
    {
        get => _duration;
        set => SetProperty(ref _duration, value);
    }
    public double? Distance
    {
        get => _distance;
        set => SetProperty(ref _distance, value);
    }
    public double? Calories
    {
        get => _calories;
        set => SetProperty(ref _calories, value);
    }
    public double? AvgSpeed
    {
        get => _avgSpeed;
        set => SetProperty(ref _avgSpeed, value);
    }
    public double? MaxSpeed
    {
        get => _maxSpeed;
        set => SetProperty(ref _maxSpeed, value);
    }
    public string? AvgPace
    {
        get => _avgPace;
        set => SetProperty(ref _avgPace, value);
    }
    public string? MaxPace
    {
        get => _maxPace;
        set => SetProperty(ref _maxPace, value);
    }
    public int? AvgBpm
    {
        get => _avgBpm;
        set => SetProperty(ref _avgBpm, value);
    }
    public int? MaxBpm
    {
        get => _maxBpm;
        set => SetProperty(ref _maxBpm, value);
    }
    public string? WarmUp
    {
        get => _warmUp;
        set => SetProperty(ref _warmUp, value);
    }
    public bool? WarmUpAbs
    {
        get => _warmUpAbs;
        set => SetProperty(ref _warmUpAbs, value);
    }
    public bool? WarmUpArms
    {
        get => _warmUpArms;
        set => SetProperty(ref _warmUpArms, value);
    }
    public bool? WarmUpBack
    {
        get => _warmUpBack;
        set => SetProperty(ref _warmUpBack, value);
    }
    public bool? WarmUpChest
    {
        get => _warmUpChest;
        set => SetProperty(ref _warmUpChest, value);
    }
    public bool? WarmUpLegs
    {
        get => _warmUpLegs;
        set => SetProperty(ref _warmUpLegs, value);
    }
    public WalkViewModel(Walk? walk = null)
    {
        if (walk is not null)
        {
            _id = walk.Id;
            _date = walk.DateFormated;
            _weekDay = walk.WeekDay; 
            _dayPeriod = walk.DayPeriod;
            _duration = walk.Duration;
            _distance = walk.DistanceKm;
            _calories = walk.Calories??0;
            _avgSpeed = walk.AvgSpeedKmh??0;
            _maxSpeed = walk.MaxSpeedKmh??0;
            _avgPace = walk.AvgPace;
            _maxPace = walk.MaxPace;
            _avgBpm = walk.AvgHrBpm??0;
            _maxBpm = walk.MaxHrBpm??0;
            _warmUpAbs = walk.WarmUpAbs;
            _warmUpArms = walk.WarmUpArms;
            _warmUpBack = walk.WarmUpBack;
            _warmUpChest = walk.WarmUpChest;
            _warmUpLegs = walk.WarmUpLegs;
            _warmUp = walk.WarmUp();
        }
    }
}