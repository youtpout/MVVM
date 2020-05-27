using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace MVVM.Tools
{
    /// <summary>
    /// Inspiré de https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        #region Fields 
        readonly Action<T> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields 
        #region Constructors 
        public RelayCommand(Action<T> execute) : this(execute, null) { }
        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; _canExecute = canExecute;
        }
        #endregion // Constructors 
        #region ICommand Members 
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter) { _execute((T)parameter); }
        #endregion // ICommand Members 
    }
}
