
using System.Collections.ObjectModel;
using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public ButtonCommandBinding FillListsButtonCommandBinding { get; private set; }

        public string PageTitle => "This page will consist of several ListViews...";

        public ObservableCollection<ListItemWithSubItemsViewModel> ListItems { get; private set; }

        public MainPageViewModel()
        {
            FillListsButtonCommandBinding = new ButtonCommandBinding(fillListsButtonCommand, true);
            ListItems = new ObservableCollection<ListItemWithSubItemsViewModel>();
        }

        private void fillListsButtonCommand()
        {
            ListItems.Clear();

            for (int i = 1; i < 5; i++)
            {
                ListItems.Add(new ListItemWithSubItemsViewModel(new ListItemWithSubItemsModel($"Item {i}", $"Description {i}")));
            }
        }
    }
}
