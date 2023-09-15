using xamarinListViewSizingExample.ViewModels;
using Xamarin.Forms;

namespace xamarinListViewSizingExample.Views
{
    public class ListItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ListItemTemplate { get; set; }

        public DataTemplate SubListItemTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ListItemWithSubItemsViewModel)
                return ListItemTemplate;
            else
                return SubListItemTemplate;
        }
    }
}

