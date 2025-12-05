using MySteps.ViewModels;
using MySteps.Models;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;

namespace MySteps.Views;

public partial class WalksPage : ContentPage
{
    private readonly WalksViewModel _viewModel;
	public WalksPage()
	{
		InitializeComponent();
        _viewModel = new WalksViewModel(App.WalkRepo);
        reload();
	}

    public async void reload()
    {
        await _viewModel.LoadAsync();
        collectionView.ItemsSource = _viewModel.Itens;
    }

    private async void OnDetailClicked(object? sender, EventArgs e)
    {
        Grid clickedGrid = sender as Grid;
        if (clickedGrid != null)
        {
            WalkViewModel dataContext = clickedGrid.BindingContext as WalkViewModel;
            if (dataContext != null)
            {
                _viewModel.SelectedWalk = dataContext;
                await Navigation.PushAsync(new WalkPage(dataContext));
            }
        }
    }

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        // await DisplayAlert("Add", "Add New walk!", "OK");
        this.ShowPopup(new WalkFormPopup(new WalkViewModel()));
    }
    private async void OnEditClicked(object? sender, EventArgs e)
    {
        MenuFlyoutItem clickedMenuFlyoutItem = sender as MenuFlyoutItem;
        if (clickedMenuFlyoutItem != null)
        {
            WalkViewModel dataContext = clickedMenuFlyoutItem.BindingContext as WalkViewModel;
            if (dataContext != null)
            {
                _viewModel.SelectedWalk = dataContext;
                await DisplayAlert("Edit", "Edit walk "+dataContext.Id, "OK");
            }
        }
    }
    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        MenuFlyoutItem clickedMenuFlyoutItem = sender as MenuFlyoutItem;
        if (clickedMenuFlyoutItem != null)
        {
            WalkViewModel dataContext = clickedMenuFlyoutItem.BindingContext as WalkViewModel;
            if (dataContext != null)
            {
                _viewModel.SelectedWalk = dataContext;
                await DisplayAlert("Delete", "Delete walk "+dataContext.Id, "OK");
            }
        }
    }

}