using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using xamarinListViewSizingExample.Models;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ListItemWithSubItemsViewModel : ViewModelBase
    {
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
            // The rest of the frame's content has a static height of 40 (2 rows with Height="20")
            // => Define SubItemsListHeight + 40 as height for Frame
            FrameHeight = SubItemsListHeight + 40;
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
    }
}
