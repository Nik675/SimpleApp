using Prism.Unity;
using SimpleApp.Interfaces;
using SimpleApp.Services;
using SimpleApp.Views;
using Xamarin.Forms;
using Microsoft.Practices.Unity;

namespace SimpleApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<ItemPage>();
            Container.RegisterType<IIdeaDatabase, IdeaDatabase>();
        }
    }
}
