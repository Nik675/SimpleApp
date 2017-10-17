using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SimpleApp.Interfaces;
using Xamarin.Forms;

namespace SimpleApp.ViewModels
{
    public class ItemPageViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private IIdeaDatabase _database;
        private INavigationService _navigationService;
        public DelegateCommand AddItemCommand { get; set; }
        public ItemPageViewModel(INavigationService navigationService, IIdeaDatabase ideaDatabase)
        {
            _database = ideaDatabase;
            _navigationService = navigationService;
            AddItemCommand = new DelegateCommand(AddItemPageAsync);
        }

        public async void AddItemPageAsync()
        {
            _database.Add(Title, Description);
            await _navigationService.GoBackAsync();
        }
    }
}
