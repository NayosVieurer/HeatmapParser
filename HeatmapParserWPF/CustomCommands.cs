using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeatmapParserWPF
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "Exit",
            "Exit",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F4, ModifierKeys.Alt)
            }
        );

        public static readonly RoutedUICommand CloseVisualizer = new RoutedUICommand
            (
                "X",
                "CloseVisualizer",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Escape)
                }
            );
    }
}
