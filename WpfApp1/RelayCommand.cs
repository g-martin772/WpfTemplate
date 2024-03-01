using System.Windows.Input;

namespace WpfApp1;

public class RelayCommand : ICommand
{
    private Action<object?> execute;
    private Predicate<object?> canExecute;
    
    public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }
    
    public bool CanExecute(object? parameter)
    {
        return canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }
    

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}