
namespace xamarinListViewSizingExample.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public ButtonCommandBinding FillListsButtonCommandBinding { get; private set; }

        public string PageTitle => "This page will consist of several ListViews...";

        public MainPageViewModel()
        {
            FillListsButtonCommandBinding = new ButtonCommandBinding(fillListsButtonCommand, true);
        }

        private void fillListsButtonCommand()
        {
            //TODO
        }
    }
}
