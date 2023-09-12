using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemWithSubItemsViewModel : ViewModelBase
    {
        public string ListItemTitle => _model.ListItemTitle;
        public string ListItemDescription => _model.ListItemDescription;

        private ListItemWithSubItemsModel _model;

        public ListItemWithSubItemsViewModel(ListItemWithSubItemsModel model)
        {
            _model = model;
        }
    }
}
