using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemSubItemViewModel : ViewModelBase
    {
        public string SubItemTitle => _model.SubItemTitle;

        private ListItemSubItemModel _model;

        public ListItemSubItemViewModel(ListItemSubItemModel model)
        {
            _model = model;
        }
    }
}
