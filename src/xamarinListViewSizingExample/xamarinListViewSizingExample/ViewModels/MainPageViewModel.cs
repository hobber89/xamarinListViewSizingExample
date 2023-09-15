
using System.Collections.ObjectModel;
using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public ButtonCommandBinding FillListsButtonCommandBinding { get; private set; }

        public string PageTitle => "This page shows several variants of height definition on ListViews";

        public ObservableCollection<ListItemWithSubItemsViewModel> ListItems { get; private set; }
        public ObservableCollection<ViewModelBase> SingleLevelListItems { get; private set; }

        public MainPageViewModel()
        {
            FillListsButtonCommandBinding = new ButtonCommandBinding(fillListsButtonCommand, true);
            ListItems = new ObservableCollection<ListItemWithSubItemsViewModel>();
            SingleLevelListItems = new ObservableCollection<ViewModelBase>();
        }

        private void fillListsButtonCommand()
        {
            ListItems.Clear();

            for (int i = 1; i < 5; i++)
            {
                ListItemWithSubItemsModel item = new ListItemWithSubItemsModel($"Item {i}", $"Item has {i} sub items");
                ListItemWithSubItemsViewModel itemViewModel = new ListItemWithSubItemsViewModel(item);
                SingleLevelListItems.Add(new ListItemWithSubItemsViewModel(item));

                for (int j = 1; j <= i; j++)
                {
                    ListItemSubItemModel subItem = new ListItemSubItemModel($"Sub item {j} of item {i}");
                    item.SubItems.Add(subItem);
                    SingleLevelListItems.Add(new ListItemSubItemViewModel(subItem, itemViewModel));
                }

                ListItems.Add(new ListItemWithSubItemsViewModel(item)); //This ViewModel must be created after adding subItems to ensure they are known at time of construction!!
                                                                        //=> ToDo: add an updating mechanism to be able to use same ViewModel as added to SingleLevelListItems 
            }
        }
    }
}
