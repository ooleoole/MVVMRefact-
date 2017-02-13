using System;
using System.Windows.Input;

namespace PointManager.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        protected Action _executeWhenButtonIsPressed;

        public void Execute(object parameter)
        {
            _executeWhenButtonIsPressed.Invoke();
        }
    }
}
