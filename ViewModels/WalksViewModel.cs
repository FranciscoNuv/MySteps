using LocalizationResourceManager.Maui.ComponentModel;
using System.Collections.ObjectModel;
using MySteps.Repositories;
using MySteps.Models;

namespace MySteps.ViewModels;

public class WalsViewModel: ObservableObject
{
    private readonly WalkRepository _repo;
    public ObservableCollection<Walk> Itens { get;} = new();

    public WalsViewModel(WalkRepository repo)
    {
        _repo = repo;
    }

    public async Task LoadAsync()
    {
        Itens.Clear();
        foreach (var item in await _repo.GetAllWalks()) Itens.Add(item);
    }
}