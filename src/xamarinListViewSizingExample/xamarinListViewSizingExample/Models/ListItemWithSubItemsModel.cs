
using System.Collections.Generic;

namespace xamarinListViewSizingExample.Models
{
    internal class ListItemWithSubItemsModel
    {
        public string ListItemTitle;
        public string ListItemDescription;
        public List<ListItemSubItemModel> SubItems;

        public ListItemWithSubItemsModel(string listItemTitle, string listItemDescription)
        {
            ListItemTitle = listItemTitle;
            ListItemDescription = listItemDescription;
            SubItems = new List<ListItemSubItemModel>();
        }
    }
}
