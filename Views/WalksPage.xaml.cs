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
        var result = await this.ShowPopupAsync(new WalkFormPopup(new WalkViewModel()));
        if (result is Walk updatedWalk)
        {
            await _viewModel.SaveWalk(updatedWalk);
            reload();
        }
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
                
                var result = await this.ShowPopupAsync(new WalkFormPopup(dataContext));
                if (result is Walk updatedWalk)
                {
                    await _viewModel.SaveWalk(updatedWalk);
                    reload();
                }
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
                string newText = "10,30";
                var digits = new string(newText.Where(dig => char.IsDigit(dig) || dig=='0' || dig==0 ).ToArray()).TrimStart('0');
                string digitsStr = digits.Substring(digits.Length - 2, 2);
                string intStr = digits.Substring(0, digits.Length - 2);
                intStr = intStr.TrimStart('0');
                if (int.TryParse(digitsStr, out int dig))
                {
                    digitsStr = dig.ToString("00");
                }
                else
                {
                    digitsStr = "00";
                }
                var formatted = $"{intStr},{digitsStr}";
                await DisplayAlert("Delete", "Test { "+string.Join("|", digits)+","+digitsStr+","+intStr+", - "+formatted+"  }Delete walk "+dataContext.Id, "OK");
            }
        }
    }

}