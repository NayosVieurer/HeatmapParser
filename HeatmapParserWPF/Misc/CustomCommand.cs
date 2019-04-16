using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{
    public class CustomCommand : ICommand
    {

        private Action execute;

        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public CustomCommand(Action exec, Func<bool> canExec)
        {


            execute = exec;

            canExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            
            execute();
        }
    }
}
