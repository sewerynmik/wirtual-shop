using System;

namespace bazy3.MVVM.viewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        
        public RelayCommand DiscoveryViewCommand { get; set; }
        
        public RelayCommand OptionsViewCommand { get; set; }

        public RelayCommand ProfileViewCommand { get; set; }
        
        public HomeViewModel HomeVm { get; set; }
        
        public ShopViewModel ShopVm { get; set; }
        
        public OptionsViewModel OptionsVm { get; set; }

        public ProfileViewModel ProfileVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView;}
            set
            {
                _currentView = value; 
                OnPropertyChanged();
            }

        }
        
        
        public MainViewModel()
        {
            App.MainVm = this;
            
            HomeVm = new HomeViewModel();
            ShopVm = new ShopViewModel();
            OptionsVm = new OptionsViewModel();
            ProfileVm = new ProfileViewModel();
            
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });
            
            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = ShopVm;
            });

            OptionsViewCommand = new RelayCommand(p =>
            {
                CurrentView = OptionsVm;
            });

            ProfileViewCommand = new RelayCommand(p =>
            {
                CurrentView = ProfileVm;
            });
        }
    }
}