
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
                ListItemWithSubItemsModel item = new ListItemWithSubItemsModel($"Item {i}", $"Item has {i} sub items");
                for (int j = 1; j <= i; j++)
                    item.SubItems.Add(new ListItemSubItemModel($"Sub item {j} of item {i}"));
                ListItems.Add(new ListItemWithSubItemsViewModel(item));
            }
        }
    }
}
