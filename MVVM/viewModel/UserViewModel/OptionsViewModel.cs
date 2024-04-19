namespace bazy3.MVVM.viewModel;

public class OptionsViewModel : ObservableObject, IMainViewModel
{
    private readonly IMainViewModel _mainViewModel = App.MainVm;

    public OptionsViewModel()
    {
        ChangingPassVm = new ChangingPassViewModel();
        ChangingEmailVm = new ChangingEmailViewModel();
        ChangingPHVm = new ChangePhViewModel();

        ChangingPassCommand = new RelayCommand(o => { _mainViewModel.CurrentView = ChangingPassVm; });

        ChangingEmailCommand = new RelayCommand(o => { _mainViewModel.CurrentView = ChangingEmailVm; });

        ChangingPHCommand = new RelayCommand(o => { _mainViewModel.CurrentView = ChangingPHVm; });
    }

    public RelayCommand ChangingPassCommand { get; set; }

    public RelayCommand ChangingEmailCommand { get; set; }

    public RelayCommand ChangingPHCommand { get; set; }

    public ChangingPassViewModel ChangingPassVm { get; set; }

    public ChangingEmailViewModel ChangingEmailVm { get; set; }

    public ChangePhViewModel ChangingPHVm { get; set; }
    public object CurrentView { get; set; }
}