using System.Collections.ObjectModel;
using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemWithSubItemsViewModel : ViewModelBase
    {
        public string ListItemTitle => _model.ListItemTitle;
        public string ListItemDescription => _model.ListItemDescription;
        public ObservableCollection<ListItemSubItemViewModel> SubItems { get; private set; } = new ObservableCollection<ListItemSubItemViewModel>();

        private ListItemWithSubItemsModel _model;

        public ListItemWithSubItemsViewModel(ListItemWithSubItemsModel model)
        {
            _model = model;

            fillSubItems();
        }

        private void fillSubItems()
        {
            SubItems.Clear();
            foreach (ListItemSubItemModel subItem in _model.SubItems)
            {
                SubItems.Add(new ListItemSubItemViewModel(subItem));
            }
        }
    }
}
