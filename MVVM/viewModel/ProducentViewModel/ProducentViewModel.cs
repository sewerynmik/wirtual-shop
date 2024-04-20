namespace bazy3.MVVM.viewModel.ProducentViewModel;

public class ProducentViewModel : ObservableObject, IMainViewModel
{
    private object _currentView;


    public ProducentViewModel()
    {
        App.MainVm = this;

        HomeVm = new HomeViewModel();
        ProfieVM = new ProfileViewModel();
        MyProductsVM = new MyProductsViewModel();

        CurrentView = HomeVm;

        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });

        ProfileViewCommand = new RelayCommand(o => { CurrentView = ProfieVM; });

        MyProductsViewCommand = new RelayCommand(o => { CurrentView = MyProductsVM; });
    }

    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand ProfileViewCommand { get; set; }

    public RelayCommand MyProductsViewCommand { get; set; }

    public HomeViewModel HomeVm { get; set; }

    public ProfileViewModel ProfieVM { get; set; }

    public MyProductsViewModel MyProductsVM { get; set; }

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