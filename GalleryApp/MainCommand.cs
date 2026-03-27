using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp
{
    internal class MainCommand
    {
        public event EventHandler? CanExecuteChanged;
        Action<object?> action;
        public MainCommand(Action<object?> action)
        {
            this.action = action;
        }
        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => action?.Invoke(parameter);
    }
}
