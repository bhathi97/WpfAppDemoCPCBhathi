using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


//this class is to delegate commands from the view to the viewModel ---> usually relayCommand or delegate command

namespace WpfAppDemoCPCBhathi.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //fields to execute the commands
        private readonly Action<object> _executeAction; //delegate to execute 
        private readonly Predicate<object> _canExecuteAction; //delegate to check can be ecuted or not

        //constructor
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        //Events
        //to subscribe or unsubscribe
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //methods
        public bool CanExecute(object? parameter)
        {
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
