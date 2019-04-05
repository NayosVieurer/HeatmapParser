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

        private Action<object> execute;

        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public CustomCommand(Action<object> exec, Func<bool> canExec)
        {
            execute = exec;

            canExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter = null)
        {
            
            execute(parameter);
        }


        //public static readonly RoutedUICommand Exit = new RoutedUICommand
        //(
        //    "Exit",
        //    "Exit",
        //    typeof(CustomCommands),
        //    new InputGestureCollection()
        //    {
        //        new KeyGesture(Key.F4, ModifierKeys.Alt)
        //    }
        //);

        //public static readonly RoutedUICommand CloseVisualizer = new RoutedUICommand
        //(
        //    "X",
        //    "CloseVisualizer",
        //    typeof(CustomCommands),
        //    new InputGestureCollection()
        //    {
        //        new KeyGesture(Key.Escape)
        //    }
        //);

        //public static readonly RoutedUICommand Increase = new RoutedUICommand
        //(
        //    "",
        //    "Increase",
        //    typeof(CustomCommands),
        //    new InputGestureCollection()
        //    {
        //        new KeyGesture(Key.Right)
        //    }
        //);

        //public static readonly RoutedUICommand Decrease = new RoutedUICommand
        //(
        //    "",
        //    "Decrease",
        //    typeof(CustomCommands),
        //    new InputGestureCollection()
        //    {
        //        new KeyGesture(Key.Left)
        //    }
        //);

    }
}
