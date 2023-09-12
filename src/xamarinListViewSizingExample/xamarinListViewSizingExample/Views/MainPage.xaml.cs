using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarinListViewSizingExample.ViewModels;

namespace xamarinListViewSizingExample.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            _viewModel = new MainPageViewModel();

            BindingContext = _viewModel;
        }

        private void Frame_SizeChanged(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            if (frame.BindingContext == null)
                return;

            (frame.BindingContext as ListItemSubItemViewModel).Parent.Frame_SizeChanged(sender, e);
        }
    }
}
