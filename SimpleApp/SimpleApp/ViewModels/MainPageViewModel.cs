using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SimpleApp.Interfaces;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SimpleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private List<Idea> _list;
        public List<Idea> List
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }

        private IIdeaDatabase _database;
        private INavigationService _navigationService;
        public DelegateCommand GoToAddItemCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IIdeaDatabase ideaDatabase)
        {
            _database = ideaDatabase;
            _navigationService = navigationService;
            GoToAddItemCommand = new DelegateCommand(GoToItemPage);
            RefreshList();
        }

        public async void GoToItemPage()
        {
            await _navigationService.NavigateAsync("ItemPage");
        }

        public void RefreshList()
        {
            List = _database.GetAll();
        }

        #region DELETE_ITEM

        public Command<Idea> DeleteItemCommand
        {
            get
            {
              return new Command<Idea>((item) =>
              {
                  Delete(item.ID);
              });
            }
        }

        private void Delete(int id)
        {
            _database.Delete(id);
            RefreshList();
        }
        #endregion

        #region FOR_REFRESH_WHEN_BACK
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            RefreshList();
        }
        #endregion

        #region PULL_TO_REFRESH
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        private Command loadListViewCommand;
        public Command LoadListViewCommand
        {
            get
            {
                return loadListViewCommand ?? (loadListViewCommand = new Command(ExecuteLoadListViewCommand, () =>
                {
                    return !IsBusy;
                }));
            }
        }
        private async void ExecuteLoadListViewCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadListViewCommand.ChangeCanExecute();

            RefreshList();

            IsBusy = false;
            LoadListViewCommand.ChangeCanExecute();
        }
        #endregion
    }
}
