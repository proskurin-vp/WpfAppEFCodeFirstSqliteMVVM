using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppEF_MVVM_promUa.Utils
{
    public class CustomCommand : ICommand
    {
        Action<object> _execute; // обобщенный делегат, соответствующий сигнатуре метода: void Method(object parameter);
        Predicate<object> _canExecute; // обобщенный делегат, соответствующий сигнатуре метода bool Method(object parameter);

        public CustomCommand(Action<object> execute)
            : this(execute, null) // обращаемся к имеющемуся в классе конструктору 
                                  // public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        { }

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        // событие возникает, когда может поменяться условие применения команды
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

        // метод проверяет, может ли команда быть выполнена
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        // метод вызывается, когда команда выполняется
        public void Execute(object parameter)
        {
            _execute(parameter);
            //_execute.Invoke(parameter); 
        }
    }
}
