using MySteps.ViewModels;

namespace MySteps.Views;

public partial class WalksPage : ContentPage
{
    private readonly WalksViewModel _viewModel;
	public WalksPage()
	{
		InitializeComponent();
        // _viewModel = new WalksViewModel(App.WalkRepo);
        // BindingContext = _viewModel;
	}
    // protected override async void OnAppearing()
    // {
    //     base.OnAppearing();
    //     await App.MainViewModel?.LoadAsync();
    //     // await _viewModel.LoadAsync();
    // }

    // private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    // {
    //     if (e.CurrentSelection.FirstOrDefault() is WalkViewModel selected)
    //     {
    //         await Navigation.PushAsync(new WalkPage());
    //     }
    // }


}