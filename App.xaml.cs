using SingleTopOverrideWindowProblem.Views;

namespace SingleTopOverrideWindowProblem
{
    public partial class App : Application, IAppWithMainPage
    {
        private DisplayManager displayManager;
        public App()
        {
            this.InitializeComponent();

            this.StartApp();
            Instance = this;
        }

        /// <summary>
        /// Gets the current app instance.
        /// </summary>
        public static App Instance { get; private set; }
        public Page CurrentPage { get; set; }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(this.CurrentPage);
        }
        private void StartApp()
        {
            this.displayManager = new DisplayManager(this);
            this.displayManager.ShowMainPage();
        }
    }
}