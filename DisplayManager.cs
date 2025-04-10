using SingleTopOverrideWindowProblem.ViewModels;
using SingleTopOverrideWindowProblem.Views;

namespace SingleTopOverrideWindowProblem
{
    internal class DisplayManager
    {
        private readonly IAppWithMainPage application;
        public DisplayManager(IAppWithMainPage application) 
        { 
            this.application = application;
        }

        public void ShowMainPage()
        {
            var page = new HomePage();
            page.BindingContext = new HomePageVM();
            var navPage = new NavigationPage();
            navPage.PushAsync(page);

            this.application.CurrentPage = page;

            if (Application.Current!.Windows.Count > 0)
            {
                Application.Current!.Windows[0].Page = page;
            }
        }
    }
}
