namespace WpfApp1;

public class MainViewModel : ViewModelBase
{
    private int age;
    private string _input;

    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
            OnPropertyChanged();
        }
    }

    public string Input
    {
        get => _input;
        set { _input = value; OnPropertyChanged("Input"); }
    }

    public RelayCommand ParseCommand { get; set; }
    public RelayCommand ResetCommand { get; set; }

    public MainViewModel()
    {
        ParseCommand = new RelayCommand(
        o =>
        {
            bool success = int.TryParse(Input, out int result);
            if (success)
                Age = result;
        },
        o =>
        {
            return int.TryParse(Input, out int result);
        });

        ResetCommand = new RelayCommand(o =>
        {
            Age = 0;
        }, o =>
        {
            return Age != 0;
        });
    }
}