using LocalizationResourceManager.Maui.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MySteps.Repositories;
using MySteps.Models;
using MySteps.Helpers;


namespace MySteps.ViewModels;

public class WalksViewModel: ObservableObject
{
    private readonly WalkRepository _repo;
    private WalkViewModel? _selectedWalk;
    public ObservableCollection<WalkViewModel> Itens { get; set; }

    public WalkViewModel? SelectedWalk
    {
        get => _selectedWalk;
        set => SetProperty(ref _selectedWalk, value);
    }
    public WalksViewModel(WalkRepository repo)
    {
        _repo = repo;
        Itens = [];
        // DeleteWalkCommand = new Command<WalkViewModel>(DeleteWalk);
        // ImportWalksCommand = new Command(ImportWalks);
    }

    public async Task LoadAsync()
    {
        Itens.Clear();
        var lis = await _repo.GetAllWalks();
        System.Diagnostics.Debug.WriteLine($"[DEBUG] Walks carregados do DB: {lis.Count}");
        foreach (Walk item in lis) Itens.Add(new WalkViewModel(item));

    }

    public async Task<Walk?> GetAsync(int id)
    {
        return await _repo.GetWalk(id);
    }
    
    public async Task SaveWalk(Walk walk)
    {
        if(walk.Id is null)
        {
            await _repo.AddNewWalk(walk);
        } else
        {
            await _repo.UpdateWalk(walk);
        }
    }
    // public async void DeleteWalk(WalkViewModel walk)
    // {
    //     if (walk.Id is not null)
    //         await _repo.DeleteWalk(walk.Id);
    // }
        
    // public ICommand DeleteWalkCommand { get; private set; }

    // public async void ImportWalks()
    // {
    //     using Stream stream = await FileSystem.OpenAppPackageFileAsync("import.json");
    //     List<WalkImport> data = await System.Text.Json.JsonSerializer.DeserializeAsync<List<WalkImport>>(stream);
    //     foreach (WalkImport import in data)
    //     {
    //         Walk w = new Walk();
    //         w.Date = ConverterHelper.GetDateFromFormated(import.Date);
    //         w.DayPeriod = DayPeriod.Morning;
    //         w.DurationSec = ConverterHelper.GetSecondsFromTimeString(import.Duration);
    //         w.DistanceMeters = import.Distance*1000;
    //         w.Calories = import.Calories;
    //         w.AvgSpeedKmh = import.AvgSpeed;
    //         w.MaxSpeedKmh = import.MaxSpeed;
    //         w.AvgPaceSecPerKm = ConverterHelper.GetSecondsFromTimeString(import.AvgPace);
    //         w.MaxPaceSecPerKm = ConverterHelper.GetSecondsFromTimeString(import.MaxPace);
    //         w.WarmUpAbs = import.Abs;
    //         w.WarmUpArms = import.Arms;
    //         w.WarmUpBack = import.Back;
    //         w.WarmUpChest = import.Chest;
    //         w.WarmUpLegs = import.Legs;
    //         await _repo.AddNewWalk(w);
    //     }
    //     await LoadAsync();
    // }
        
    // public ICommand ImportWalksCommand { get; private set; }

}