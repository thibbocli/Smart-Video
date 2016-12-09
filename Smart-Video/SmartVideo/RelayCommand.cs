using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartVideo
{
    class RelayCommand:ICommand
    {
        private readonly Predicate<Object> _predicate= p=>true;
        private readonly Action<object> _action;

        public RelayCommand(Action<object> execute)
        {
            _action = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }


        public event EventHandler CanExecuteChanged;
    }
}
