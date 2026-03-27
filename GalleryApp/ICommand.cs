using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp
{
    internal interface ICommand
    {
        void Execute(object? arg);
        bool CanExecute(object? arg);
        event EventHandler? CanExecuteChanged;
    }
}
