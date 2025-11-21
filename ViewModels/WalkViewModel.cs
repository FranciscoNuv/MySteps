using LocalizationResourceManager.Maui.ComponentModel;
using System.Collections.ObjectModel;
using MySteps.Models;

namespace MySteps.ViewModels;
public class WalkViewModel: ObservableObject
{
    private int? _id;
    private string _date;
    private DayOfWeek _weekDay;
    private DayPeriod _dayPeriod;
    private string _duration;
    private double _distance;
    private double _calories;
    private double _avgSpeed;
    private double _maxSpeed;
    private string _avgPace;
    private string _maxPace;
    private int _avgBpm;
    private int _maxBpm;
    private string _warmUp;

    public int? Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }
    public string Date
    {
        get => _date;
        set => SetProperty(ref _date, value);
    }
    public DayOfWeek WeekDay
    {
        get => _weekDay;
        set => SetProperty(ref _weekDay, value);
    }
    public DayPeriod DayPeriod
    {
        get => _dayPeriod;
        set => SetProperty(ref _dayPeriod, value);
    }
    public string Duration
    {
        get => _duration;
        set => SetProperty(ref _duration, value);
    }
    public double Distance
    {
        get => _distance;
        set => SetProperty(ref _distance, value);
    }
    public double Calories
    {
        get => _calories;
        set => SetProperty(ref _calories, value);
    }
    public double AvgSpeed
    {
        get => _avgSpeed;
        set => SetProperty(ref _avgSpeed, value);
    }
    public double MaxSpeed
    {
        get => _maxSpeed;
        set => SetProperty(ref _maxSpeed, value);
    }
    public string AvgPace
    {
        get => _avgPace;
        set => SetProperty(ref _avgPace, value);
    }
    public string MaxPace
    {
        get => _maxPace;
        set => SetProperty(ref _maxPace, value);
    }
    public int AvgBpm
    {
        get => _avgBpm;
        set => SetProperty(ref _avgBpm, value);
    }
    public int MaxBpm
    {
        get => _maxBpm;
        set => SetProperty(ref _maxBpm, value);
    }
    public string WarmUp
    {
        get => _warmUp;
        set => SetProperty(ref _warmUp, value);
    }
    public WalkViewModel(Walk walk)
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
        _warmUp = walk.WarmUp();
    }
}