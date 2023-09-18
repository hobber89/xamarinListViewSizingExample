using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemWithSubItemsViewModel : ViewModelBase
    {
        public ButtonCommandBinding Subtract20FromSubItemsListHeightButtonCommandBinding { get; private set; }
        public ButtonCommandBinding Add20ToSubItemsListHeightButtonCommandBinding { get; private set; }

        public string ListItemTitle => _model.ListItemTitle;
        public string ListItemDescription => _model.ListItemDescription;
        public ObservableCollection<ListItemSubItemViewModel> SubItems { get; private set; } = new ObservableCollection<ListItemSubItemViewModel>();

        public double FrameHeight
        {
            get => _frameHeight;
            set => SetProperty(ref _frameHeight, value);
        }
        private double _frameHeight = 1;

        public double SubItemsListHeight
        {
            get => _subItemsListHeight;
            private set => SetProperty(ref _subItemsListHeight, value);
        }
        private double _subItemsListHeight = 1;

        public double SubItemsListHeightWithFixHeightPerItem
        {
            get => _subItemsListHeightWithFixHeightPerItem;
            private set => SetProperty(ref _subItemsListHeightWithFixHeightPerItem, value);
        }
        private double _subItemsListHeightWithFixHeightPerItem = 1;

        private ListItemWithSubItemsModel _model;
        private Dictionary<Guid, double> _viewsHeightMap = new Dictionary<Guid, double>();

        public ListItemWithSubItemsViewModel(ListItemWithSubItemsModel model)
        {
            _model = model;
            Subtract20FromSubItemsListHeightButtonCommandBinding = new ButtonCommandBinding(subtract20FromSubItemsListHeightButtonCommand, true);
            Add20ToSubItemsListHeightButtonCommandBinding = new ButtonCommandBinding(add20ToSubItemsListHeightButtonCommand, true);

            fillSubItems();

            Frame f = new Frame();
        }

        public void Frame_SizeChanged(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;

            if (frame != null)
            {
                if (_viewsHeightMap.ContainsKey(frame.Id))
                    _viewsHeightMap[frame.Id] = frame.Height;
                else
                    _viewsHeightMap.Add(frame.Id, frame.Height);
            }

            int totalHeight = 0;
            foreach (double height in _viewsHeightMap.Values)
            {
                totalHeight += (int)height;
            }

            SubItemsListHeight = Math.Max(1, totalHeight);
            FrameHeight = SubItemsListHeight + 60;
        }

        private void fillSubItems()
        {
            SubItems.Clear();
            foreach (ListItemSubItemModel subItem in _model.SubItems)
            {
                SubItems.Add(new ListItemSubItemViewModel(subItem, this));
            }

            SubItemsListHeightWithFixHeightPerItem = SubItems.Count * 60;
        }

        private void subtract20FromSubItemsListHeightButtonCommand()
        {
            SubItemsListHeight -= 20;
            SubItemsListHeightWithFixHeightPerItem -= 20;
        }

        private void add20ToSubItemsListHeightButtonCommand()
        {
            SubItemsListHeight += 20;
            SubItemsListHeightWithFixHeightPerItem += 20;
        }
    }
}
