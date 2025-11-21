using MySteps.Repositories;
using MySteps.ViewModels;

namespace MySteps
{
    public partial class App : Application
    {
	public static ViewModels.WalksViewModel? MainViewModel { get; private set; }
        public static WalkRepository WalkRepo { get; private set; }

        public App(WalkRepository repo)
        {
            InitializeComponent();
            WalkRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            MainViewModel = new WalksViewModel(WalkRepo);
            MainViewModel.LoadAsync().ContinueWith((s) => { });
            var window = new Window(new AppShell());
            return window;
        }

    }
}