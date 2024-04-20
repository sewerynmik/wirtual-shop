namespace bazy3.MVVM.viewModel;

public class MainViewModel : ObservableObject, IMainViewModel
{
    private object _currentView;


    public MainViewModel()
    {
        App.MainVm = this;

        HomeVm = new HomeViewModel();
        ShopVm = new ShopViewModel();
        OptionsVm = new OptionsViewModel();
        ProfileVm = new ProfileViewModel();
        CardVm = new CardViewModel();

        CurrentView = HomeVm;

        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVm; });

        DiscoveryViewCommand = new RelayCommand(o => { CurrentView = ShopVm; });

        OptionsViewCommand = new RelayCommand(p => { CurrentView = OptionsVm; });

        ProfileViewCommand = new RelayCommand(p => { CurrentView = ProfileVm; });

        CardViewCommand = new RelayCommand(p => { CurrentView = CardVm; });
    }

    public RelayCommand HomeViewCommand { get; set; }

    public RelayCommand DiscoveryViewCommand { get; set; }

    public RelayCommand OptionsViewCommand { get; set; }

    public RelayCommand ProfileViewCommand { get; set; }

    public RelayCommand CardViewCommand { get; set; }

    public HomeViewModel HomeVm { get; set; }

    public ShopViewModel ShopVm { get; set; }

    public OptionsViewModel OptionsVm { get; set; }

    public ProfileViewModel ProfileVm { get; set; }

    public CardViewModel CardVm { get; set; }

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