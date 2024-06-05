namespace bazy3.MVVM.viewModel.ProducentViewModel;

public class MyProductsViewModel
{
    private readonly IMainViewModel _mainViewModel = App.MainVm;

    public MyProductsViewModel()
    {
        AddProductVm = new AddProductViewModel();

        AddProductCommand = new RelayCommand(o => { _mainViewModel.CurrentView = AddProductVm; });
    }

    public RelayCommand AddProductCommand { get; set; }

    public AddProductViewModel AddProductVm { get; set; }
    
    public object CurrentView { get; set; }
}