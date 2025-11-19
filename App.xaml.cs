using MySteps.Repositories;

namespace MySteps
{
    public partial class App : Application
    {
        public static WalkRepository WalkRepo { get; private set; }

        public App(WalkRepository repo)
        {
            InitializeComponent();
            WalkRepo = repo;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}