using System;
using System.Windows.Input;

namespace xamarinListViewSizingExample.ViewModels
{
    internal class ButtonCommandBinding : ICommand
    {
        private readonly Action _handler;

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (value != _isEnabled)
                {
                    _isEnabled = value;
                    if (CanExecuteChanged != null)
                    {
                        CanExecuteChanged(this, EventArgs.Empty);
                    }
                }
            }
        }
        private bool _isEnabled;

        public ButtonCommandBinding(Action handler)
        {
            _handler = handler;
        }

        public ButtonCommandBinding(Action handler, bool isEnabled)
        {
            _handler = handler;
            _isEnabled = isEnabled;
        }

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}