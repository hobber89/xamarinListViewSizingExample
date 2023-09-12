using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemSubItemViewModel : ViewModelBase
    {
        public string SubItemTitle => _model.SubItemTitle;

        public ListItemWithSubItemsViewModel Parent;

        private ListItemSubItemModel _model;

        public ListItemSubItemViewModel(ListItemSubItemModel model, ListItemWithSubItemsViewModel parent)
        {
            _model = model;
            Parent = parent;
        }
    }
}
