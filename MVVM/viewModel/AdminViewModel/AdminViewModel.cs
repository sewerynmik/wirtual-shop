namespace bazy3.MVVM.viewModel.AdminViewModel;


public class AdminViewModel : ObservableObject, IMainViewModel
{
    private object _currentView;
    
    public AdminViewModel()
    {
        App.MainVm = this;

        HomeVM = new HomeViewModel();
        OrdersVM = new OrdersViewModel();
        ProducersVM = new ProducersViewModel();
        ProductsVM = new ProductsViewModel();
        UsersVM = new UsersViewModel();

        CurrentView = HomeVM;
        
        HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
        UsersViewCommand = new RelayCommand(o => { CurrentView = UsersVM; });
        ProducersViewCommand = new RelayCommand(o => { CurrentView = ProducersVM; });
        ProductsViewCommand = new RelayCommand(o => { CurrentView = ProductsVM; });
        OrdersViewCommand = new RelayCommand(o => { CurrentView = OrdersVM; });
    }
    
    public RelayCommand HomeViewCommand { set; get; }
    public RelayCommand UsersViewCommand { set; get; }
    public RelayCommand ProductsViewCommand { set; get; }
    public RelayCommand ProducersViewCommand { set; get; }
    public RelayCommand OrdersViewCommand { set; get; }

    public HomeViewModel HomeVM { get; set; }
    public OrdersViewModel OrdersVM { get; set; }
    public ProducersViewModel ProducersVM { get; set; }
    public ProductsViewModel ProductsVM { get; set; }
    public UsersViewModel UsersVM { get; set; }

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