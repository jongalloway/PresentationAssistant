using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationAssistant.ZoomEditorMargin
{
    public class DelegateCommand : ICommand
    {
        private Action _execute;
        private Func<bool> _canExecute;
        public event EventHandler CanExecuteChanged = delegate { };
        public DelegateCommand(Action execute)
        {
            this._canExecute = (() => true);
            this._execute = execute;
        }
        public DelegateCommand(Func<bool> canExecute, Action execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return this._canExecute();
        }
        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
