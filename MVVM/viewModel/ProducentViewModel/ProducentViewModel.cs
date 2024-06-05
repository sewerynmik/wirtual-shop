namespace bazy3.MVVM.viewModel.ProducentViewModel;

public class ProducentViewModel : ObservableObject, IMainViewModel
{
    private object _currentView;


    public ProducentViewModel()
    {
        App.MainVm = this;

        HomeVm = new HomeViewModel();
        ProfileVm = new ProfileViewModel();
        MyProductsVm = new MyProductsViewModel();

        CurrentView = HomeVm;

        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });

        ProfileViewCommand = new RelayCommand(o => { CurrentView = ProfileVm; });

        MyProductsViewCommand = new RelayCommand(o => { CurrentView = MyProductsVm; });
    }

    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand ProfileViewCommand { get; set; }

    public RelayCommand MyProductsViewCommand { get; set; }

    public HomeViewModel HomeVm { get; set; }

    public ProfileViewModel ProfileVm { get; set; }

    public MyProductsViewModel MyProductsVm { get; set; }

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }
}