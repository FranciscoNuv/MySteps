using MySteps.Models;
using MySteps.ViewModels;

namespace MySteps.Views;

public partial class WalkPage : ContentPage
{
    public WalkPage()
    {
        BindingContext = App.MainViewModel?.SelectedWalk;
        InitializeComponent();
    }
}