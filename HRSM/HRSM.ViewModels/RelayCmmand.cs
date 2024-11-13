using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.ViewModels
{
    //命令实现类
    public class RelayCmmand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> executeAction;
        private Func<object, bool> canExecuteFunc;
        //构造函数
        public RelayCmmand() { }
        public RelayCmmand(Action<object> execute) : this(execute, null) { }
        public RelayCmmand(Action<object> execute,Func<object,bool> canExecute)
        {
            this.canExecuteFunc = canExecute;
            this.executeAction = execute;
        }
        //实现CanExecute
        public bool CanExecute(object parameter)
        {
            if (this.canExecuteFunc == null)
                return true;
            return this.canExecuteFunc(parameter);
        }
        //实现Execute
        public void Execute(object parameter)
        {
            if (executeAction == null)
                return;
            this.executeAction(parameter);
        }
    }
}
